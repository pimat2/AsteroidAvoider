using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float scoreMultiplier;
    public const string HighScoreKey = "HighScore";
    bool isCounting = true;
    float score;
    void Update()
    {
        if(isCounting){
            score += Time.deltaTime * scoreMultiplier;
            scoreText.text = Mathf.FloorToInt(score).ToString();
        }
        else{
            return;
        }
        
    }
    public int StopCounting(){
        isCounting = false;
        scoreText.text = string.Empty;
        return Mathf.FloorToInt(score);
    }
    void OnDestroy() {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if(score > currentHighScore){
            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }    
    }
    public void StartCounting(){
        isCounting = true;
    }
}
