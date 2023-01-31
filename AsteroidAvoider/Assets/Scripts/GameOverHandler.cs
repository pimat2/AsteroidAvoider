using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Button continueButton;
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
    public void ContinueButton(){
        AdManager.instance.ShowAd(this);
        continueButton.interactable = false;
    }
    public void PlayAgain(){
        SceneManager.LoadScene("MainScene");
    }
    public void ReturnToMenu(){
        SceneManager.LoadScene("MenuScene");
    }
    public void ContinueGame(){
        scoreHandler.StartCounting();//starts the score again
        
        //sets the player active and puts him back in the middle of the screen
        player.transform.position = Vector3.zero;
        player.SetActive(true);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        
        //enables the asteroid spawner and disables the gameover UI Canvas
        asteroidSpawner.enabled = true;
        gameOverDisplay.gameObject.SetActive(false);
    }
}
