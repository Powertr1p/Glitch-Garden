using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStars : MonoBehaviour
{
    private int _starsCount = 500;
    private Text _starText;

    private void Start()
    {
        _starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _starText.text = _starsCount.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return _starsCount >= amount;
    }

    public void AddStars(int amountStars)
    {
        _starsCount += amountStars;
        UpdateDisplay();
    }

    public void SpendStars(int amountStars)
    {
        if (_starsCount >= amountStars)
        { 
            _starsCount -= amountStars;
            UpdateDisplay();
        }
    }
}
