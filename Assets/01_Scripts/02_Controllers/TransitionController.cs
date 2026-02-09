using UnityEngine;
using UnityEngine.EventSystems;

public class TransitionController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EventSystem _eventSystem;

    public void StartTransition()
    {
        _animator.SetTrigger("Transition");
    }

    public void OnTransitionMiddle()
    {
        GameManager.Instance.OnTransitionMiddle();
    }

    public void SetInputEnabled(int enabled)
    {
        _eventSystem.enabled = enabled == 1;
    }
}
