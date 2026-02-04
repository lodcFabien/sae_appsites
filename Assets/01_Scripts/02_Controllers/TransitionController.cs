using UnityEngine;

public class TransitionController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void StartTransition()
    {
        _animator.SetTrigger("Transition");
    }

    public void OnTransitionMiddle()
    {
        GameManager.Instance.OnTransitionMiddle();
    }
}
