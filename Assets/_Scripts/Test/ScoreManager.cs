using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    public int Score => _score;

    public void AddScore(int amount)
    {
        _score += amount;
    }
}
