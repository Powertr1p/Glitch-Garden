using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameTimerSlider : MonoBehaviour
{
    public event UnityAction OnTimesOut;

    [Tooltip("Level duration in seconds")]
    [SerializeField] private float _levelTime = 10f;

    private void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / _levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= _levelTime -2f);
        if (timerFinished)
            OnTimesOut?.Invoke();
    }
}
