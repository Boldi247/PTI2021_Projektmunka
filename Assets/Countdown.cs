using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;
    public GameObject GameOver;

    private void Start() {
        GameOver.SetActive(false);
        timerIsRunning = true;
    }

    private void Update() {
        if (timerIsRunning){
            if (timeRemaining > 0){
                timeRemaining -= Time.deltaTime;
            }
            else{
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;

                GameOver.SetActive(true);
                Invoke("Restart", 2.167f);
            }
            DisplayTime(timeRemaining);
        }
    }

    private void DisplayTime(float timeToDisplay){
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
