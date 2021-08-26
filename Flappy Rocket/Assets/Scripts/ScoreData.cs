using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ScoreData : MonoBehaviour
{
    public float maxScore;

    public ScoreData(GameOverScreen gameOver)
    {
        maxScore = gameOver.highScore;
    }
}
