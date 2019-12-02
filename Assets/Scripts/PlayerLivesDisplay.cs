using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerLivesDisplay : MonoBehaviour
{
    public UnityAction OnPlayerDeath;

    [SerializeField] private float _baseLives = 3;
    [SerializeField] private int _damageToPlayer = 1;

    private float _lives;
    private Text _livesText;

    private void Start()
    {
        _lives = _baseLives - PlayerPrefsController.GetDifficulty();
        _livesText = GetComponent<Text>();

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _livesText.text = _lives.ToString();
    }

    public void TakeLife()
    {
        _lives -= _damageToPlayer;
        UpdateDisplay();

        if (_lives <= 0)
            OnPlayerDeath.Invoke();
    }
}
