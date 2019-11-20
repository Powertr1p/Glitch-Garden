using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStars : MonoBehaviour
{
    private int _starsCount
    {
        get
        {
            return _starsCount;
        }
        set
        {
            _starsCount = value;
            if (_starsCount <= 0)
                _starsCount = 0;
        }
    }
    private Text _starText;

    private void Update()
    {
        _starText = GetComponent<Text>();
    }

    public void AddStars(int amountStars)
    {
        _starText.text = (_starsCount + amountStars).ToString();
    }
    public void SpendStars(int amountStars)
    {
        _starText.text = (_starsCount - amountStars).ToString();
    }
}
