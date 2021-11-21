using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject PauseUI;

    private void Start() {
        PauseUI.SetActive(false);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isPaused == false){
                isPaused = true;
                AudioListener.pause = true;
                Time.timeScale = 0f;
                PauseUI.SetActive(true);
            }
            else{
                isPaused = false;
                AudioListener.pause = false;
                Time.timeScale = 1f;
                PauseUI.SetActive(false);
            }
        }
    }    
}
