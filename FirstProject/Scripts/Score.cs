using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int points=0;
    public TextMeshProUGUI score;
    private void Start()
    {
        score = GetComponent<TextMeshProUGUI>();
       
        score.text = "Score: " + points.ToString();
    }
       
    public void IncreaseScore()
    {
        points += 10;
        score.text = "Score: " + points.ToString();
    }

}
