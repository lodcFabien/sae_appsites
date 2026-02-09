using TMPro;
using UnityEngine;

public class PopupJobButtonController : MonoBehaviour
{
    [SerializeField] private FilterButtonView _view;

    private SiteJob _job;
    public SiteJob Job => _job;

    public void Init(SiteJob job)
    {
        _job = job;
        _view.SetText(job.Type.ToString());
    }

    public void Click()
    {
        PopupManager.Instance.SetSelectedJob(this);
    }

    public void SetSelected(bool selected)
    {
        _view.SetActivated(selected);
    }
}
