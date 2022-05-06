using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }
    public void GoBack()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
