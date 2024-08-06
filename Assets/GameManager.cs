using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TMPro.TMP_Text ScoreText;
    public TMPro.TMP_Text YourScore;

    public TMPro.TMP_Text HelpingText;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] float remainingTime;

    [SerializeField] public GameObject PauseMenuPanel;
    [SerializeField] public GameObject GameOverPanel;
    
    private int score;

    void Start()
    {
        PlayerPrefs.GetInt("HighScore", 0);
    }


    public void Pause(){
        PauseMenuPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Resume(){
        PauseMenuPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Game Scene");
    }

    public void Main(){
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    public void Scores(){
        score++;
        this.ScoreText.text = score.ToString();
        this.YourScore.text = score.ToString();
        if(score > PlayerPrefs.GetInt("HighScore", 0)){
            PlayerPrefs.SetInt("HighScore", score);
            HelpingText.text = "New High Score";
        }
        else{
            HelpingText.text = "High Score " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        }
        Debug.Log("player1");
    }


    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }

    
    void Update(){
        if(remainingTime > 0){
            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime < 0){
            GameOverPanel.SetActive(true);
        }
        int minutes = Mathf.FloorToInt(remainingTime/60);
        int seconds = Mathf.FloorToInt(remainingTime%60);
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
   }


}
