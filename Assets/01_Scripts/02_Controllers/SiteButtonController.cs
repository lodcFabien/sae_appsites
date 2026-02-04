using UnityEngine;

public class SiteButtonController : MonoBehaviour
{
    [SerializeField] private SiteModel _model;

    public void OnClick()
    {
        PopupManager.Instance.SetContent(_model);
    }
}
