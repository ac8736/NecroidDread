using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    public GameObject pauseScreen;

    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void SetPause()
    {
        //pauseScreen.SetActive(true);   
        if(pauseScreen.activeSelf){
            pauseScreen.SetActive(false);
        }else{
            pauseScreen.SetActive(true);
        }
    }
        public void DisablePause()
    {
        pauseScreen.SetActive(false);
        
    }
}
