using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{
    public void Quit(){
        Debug.Log("Quit button has been pushed!");
        Application.Quit();
    }

    public void GoToMenu(){
        SceneManager.LoadScene(0);
    }
}
