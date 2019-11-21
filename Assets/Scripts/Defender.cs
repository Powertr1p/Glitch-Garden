using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] private int _starCost = 100;

    public void AddStars(int amount)
    {
        FindObjectOfType<ScoreStars>().AddStars(amount);
    }

    public int GetStarCost()
    {
        return _starCost;
    }

}
