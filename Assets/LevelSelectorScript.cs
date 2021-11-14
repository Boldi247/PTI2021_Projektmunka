using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorScript : MonoBehaviour
{
    public void Quit(){
        Debug.Log("Quit button has been pushed!");
        Application.Quit();
    }

    public void LoadLevel1(){
        SceneManager.LoadScene(1);
    }

    public void LoadLevel2(){
        SceneManager.LoadScene(2);
    }

    public void LoadLevel3(){
        SceneManager.LoadScene(3);
    }
}
