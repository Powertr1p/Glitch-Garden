using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesDisplay : MonoBehaviour
{
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
    }
}
