using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scorePerHit = 10;

    int score;
    TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;       
        scoreText = GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }
    

    public void ScoreHit()
    {
        score += scorePerHit;
        scoreText.text = score.ToString();
    }
}
