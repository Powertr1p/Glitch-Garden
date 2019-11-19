using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cactus;

    private void OnMouseDown()
    {
        Spawn(GetClickedPosition());
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
        GameObject newDefender = Instantiate(_cactus, spawnPosition, Quaternion.identity) as GameObject;
        Debug.Log(spawnPosition);
    }
}
