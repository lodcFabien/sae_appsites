using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class FilterButtonView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] protected TMP_Text _text;
    [SerializeField] private Color _activatedColor;
    [SerializeField] private Color _deactivatedColor;
    [SerializeField] private TMP_FontAsset _activatedFont;
    [SerializeField] private TMP_FontAsset _deactivatedFont;

    public void SetText(string text)
    {
        _text.text = text;
    }


    public void SetActivated(bool activated)
    {
        _image.color = activated ? _activatedColor : _deactivatedColor;
        _text.font = activated? _activatedFont : _deactivatedFont;
    }

}
