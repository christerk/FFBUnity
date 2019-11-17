using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextPanelHandler : MonoBehaviour
{
    public FFB.LogPanelType panelType;

    public TMPro.TextMeshProUGUI LogTextPrefab;
    public bool EnableOclusion;

    private GameObject Content;
    private RectTransform ContentRect;
    private ScrollRect scrollRect;

    private List<TMPro.TextMeshProUGUI> Items;
    private const float DisableMargin = 10f;

    private bool Dirty = false;
    private float contentHeight;

    void Start()
    {
        Items = new List<TextMeshProUGUI>();
        Content = transform.Find("Viewport/Content").gameObject;
        scrollRect = GetComponentInChildren<ScrollRect>();
        FFB.Instance.OnText += AddText;
        ContentRect = Content.GetComponent<RectTransform>();

        scrollRect.onValueChanged.AddListener(OnScroll);
    }

    public static string SanitizeText(string text)
    {
        return text.Replace("<", "<noparse><</noparse>");
    }

    public void OnScroll(Vector2 pos)
    {
        float viewportTop = Content.transform.localPosition.y;
        float height = ((RectTransform)this.gameObject.transform).rect.height;
        float viewportBottom = viewportTop + height;

        foreach (var item in Items)
        {
            float itemPos = -item.rectTransform.localPosition.y;
            float itemHeight = item.rectTransform.rect.height;
            item.enabled = !EnableOclusion || (itemPos + itemHeight >= viewportTop && itemPos <= viewportBottom);
        }
    }

    void AddText(FFB.LogPanelType panelType, string text)
    {
        if (this.panelType == panelType)
        {
            float panelWidth = ContentRect.rect.width;

            TMPro.TextMeshProUGUI obj = Instantiate(LogTextPrefab);
            obj.SetText(text);
            obj.transform.SetParent(Content.transform);
            float preferredHeight = obj.GetPreferredValues(panelWidth, 0f).y;
            obj.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, preferredHeight);
            this.contentHeight += preferredHeight;
            ContentRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, this.contentHeight);
            Items.Add(obj);
            Dirty = true;
        }
    }

    void OnGUI()
    {
        if (Dirty)
        {
            Dirty = false;
            scrollRect.normalizedPosition = Vector2.zero;
        }
    }

    void OnDisable()
    {
        FFB.Instance.OnText -= AddText;
    }
}
