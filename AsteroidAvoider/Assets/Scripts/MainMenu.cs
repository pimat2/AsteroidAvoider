using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    void Start() {
        OnApplicationFocus(true); 
    } 
    private void OnApplicationFocus(bool focusStatus) {
        int highScore = PlayerPrefs.GetInt(ScoreHandler.HighScoreKey, 0);
        highScoreText.text = $"Your highest score is: {highScore}";
    }
    public void PlayGame(){
        SceneManager.LoadScene("MainScene");
    }
}
