using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] ScoreHandler scoreHandler;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] GameObject gameOverDisplay;
    [SerializeField] AsteroidSpawner asteroidSpawner;
    public void EndGame(){
        asteroidSpawner.enabled = false;
        
        int finalScore = scoreHandler.StopCounting();
        gameOverText.text = $"Your Score: {finalScore}";
        
        gameOverDisplay.gameObject.SetActive(true);
    }
    public void PlayAgain(){
        SceneManager.LoadScene("MainScene");
    }
    public void ReturnToMenu(){
        SceneManager.LoadScene("MenuScene");
    }
}
