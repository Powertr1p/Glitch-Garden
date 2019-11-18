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

        return worldPos;
    }

    private void Spawn(Vector2 spawnPosition)
    {
        GameObject newDefender = Instantiate(_cactus, spawnPosition, Quaternion.identity) as GameObject;
    }
}
