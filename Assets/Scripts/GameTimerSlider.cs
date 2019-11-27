using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimerSlider : MonoBehaviour
{
    [Tooltip("Level duration in seconds")]
    [SerializeField] private float _levelTime = 10f;

    private void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / _levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= _levelTime);
        if (timerFinished)
            Debug.Log("Timer Finished");
    }
}
