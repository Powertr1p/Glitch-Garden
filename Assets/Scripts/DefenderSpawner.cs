﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender _defender;
    private GameObject _defenderParent;

    private const string _DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        _defenderParent = GameObject.Find(_DEFENDER_PARENT_NAME);

        if (!_defenderParent)
            _defenderParent = new GameObject(_DEFENDER_PARENT_NAME);
    }

    private void OnMouseDown()
    {
        if (_defender != null)
           AttempToPlaceDefenderAt(GetClickedPosition());
    }

    private void AttempToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<ScoreStars>();
        int defenderCost = _defender.GetStarCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            Spawn(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        _defender = defenderToSelect;
    }

    private Vector2 GetClickedPosition()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 roundedPos = SnapToGrid(worldPos);

        return roundedPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    private void Spawn(Vector2 spawnPosition)
    {
        Defender newDefender = Instantiate(_defender, spawnPosition, Quaternion.identity) as Defender;
        newDefender.transform.parent = _defenderParent.transform;
    }
}
