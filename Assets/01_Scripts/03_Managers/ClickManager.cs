using System.Collections;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField] private float _timer;

    private Coroutine _timerCoroutine;

    private void Start()
    {
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartTimer();
        }
    }

    private void StartTimer()
    {
        StopAllCoroutines();
        StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_timer);
        GameManager.Instance.Init();
    }
}
