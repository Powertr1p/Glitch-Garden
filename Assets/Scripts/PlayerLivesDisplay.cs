using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerLivesDisplay : MonoBehaviour
{
    public UnityAction OnPlayerDeath;

    [SerializeField] private int _lives = 10;
    [SerializeField] private int _damageToPlayer = 1;
    private Text _livesText;

    private void Start()
    {
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
