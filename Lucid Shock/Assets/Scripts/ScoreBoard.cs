using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    
    public void IncreaseScore(int amountToIncrease)
    {
        score += amountToIncrease;
    }

    void Update()
    {
       scoreText.text = score.ToString();        
    }

}
