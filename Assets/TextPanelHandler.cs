using Fumbbl;
using Fumbbl.Ffb.Dto;
using Fumbbl.UI;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextPanelHandler : MonoBehaviour
{
    public FFB.LogPanelType panelType;

    public TMPro.TextMeshProUGUI LogTextPrefab;
    public bool EnableOclusion;

    private GameObject Content;
    private RectTransform ContentRect;
    private ScrollRect scrollRect;

    private List<TMPro.TextMeshProUGUI> Items;

    private bool Dirty = false;
    private float contentHeight;

    private ReflectedFactory<LogTextGenerator<Report>, Type> LogTextFactory;

    private void Awake()
    {
        LogTextFactory = new ReflectedFactory<LogTextGenerator<Report>, Type>();
    }

    void Start()
    {
        Items = new List<TextMeshProUGUI>();
        Content = transform.Find("Viewport/Content").gameObject;
        scrollRect = GetComponentInChildren<ScrollRect>();
        FFB.Instance.OnReport += AddReport;
        FFB.Instance.OnChat += AddChat;
        ContentRect = Content.GetComponent<RectTransform>();

        scrollRect.onValueChanged.AddListener(OnScroll);
    }

    public static string SanitizeText(string text)
    {
        return text?.Replace("<", "<noparse><</noparse>");
    }

    public void OnScroll(Vector2 pos)
    {
        float height = ((RectTransform)this.gameObject.transform).rect.height;
        float viewportTop = Content.transform.localPosition.y - height / 2;
        float viewportBottom = viewportTop + height;

        foreach (var item in Items)
        {
            float itemPos = -item.rectTransform.localPosition.y;
            float itemHeight = item.rectTransform.rect.height;
            item.enabled = !EnableOclusion || (itemPos + itemHeight >= viewportTop && itemPos <= viewportBottom);
        }
    }

    void AddChat(string text)
    {
        if (this.panelType == FFB.LogPanelType.Chat)
        {
            AddText(text, 0);
        }
    }

    void AddReport(Report report)
    {
        if (this.panelType == FFB.LogPanelType.Log)
        {
            var handler = LogTextFactory.GetReflectedInstance(report.GetType());
            if (handler != null)
            {
                foreach (var logRecord in handler.HandleReport(report))
                {
                    AddText(logRecord.Text, logRecord.Indent);
                }
            } else
            {
                AddText($"<b>* * * Unhandled report {report.GetType().Name} * * *</b>", 0);
            }
        }
    }

    private void AddText(string text, int indent)
    {
        if (ContentRect != null)
        {
            float panelWidth = ContentRect.rect.width;

            if (text != null)
            {
                TMPro.TextMeshProUGUI obj = Instantiate(LogTextPrefab);
                var margin = obj.margin;
                margin.x = indent * 10;
                obj.margin = margin;
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
        FFB.Instance.OnReport -= AddReport;
    }
}
