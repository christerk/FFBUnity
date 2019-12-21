using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(TMP_InputField))]
[ExecuteAlways]
[DisallowMultipleComponent]
/// <summary>
///   Unfortunately the Canvas Scaler misses to scale the caret width of the TextMeshPro Input Fields.
///   The TMP Input Field Caret Width Scaler component simply takes care of the caret width when the scale of the canvas has changes.
/// </summary>
/// <remarks>
/// The caret width is determined by the scale factor of the canvas, the font size, and the custom WidthFactor which is an arbitrary float.!--
/// The default value of WidthFactor is 1f.
/// </remarks>
public class TMP_InputField_CaretWidthScaler : UIBehaviour
{
    public float WidthFactor = 1f;
    public Canvas Canvas;

    private TMP_InputField InputField;
    private TextMeshProUGUI Placeholder;
    private TextMeshProUGUI Text;

    protected override void OnEnable()
    {
        base.OnEnable();
        InputField = GetComponent<TMP_InputField>();
        var TextArea =  this.gameObject.transform.GetChild(0);
        Placeholder = TextArea.GetChild(0).GetComponent<TextMeshProUGUI>();
        Text = TextArea.GetChild(1).GetComponent<TextMeshProUGUI>();
        OnRectTransformDimensionsChange();
    }

    protected override void OnDisable()
    {
        InputField = null;
        Placeholder = null;
        Text = null;
        base.OnDisable();
    }

    protected override void OnRectTransformDimensionsChange()
    {
        base.OnRectTransformDimensionsChange();

        // MonoBehaviour doesn't support the null-conditional operator (?.) and the null-coalescing operator (??).
        float scalefactor, fontsize;
        if (Canvas == null) { scalefactor = 1f; } else { scalefactor = Canvas.scaleFactor; };
        if (Text == null) { fontsize = 1f; } else { fontsize = Text.fontSize; };

        if (InputField != null) {
            InputField.caretWidth = (int)(scalefactor * fontsize * WidthFactor / 10);
        }
    }
}
