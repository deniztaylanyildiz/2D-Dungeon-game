using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menumanager : MonoBehaviour
{
    public void StartButton()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
    public void ExitButton() 
    {
        Application.Quit();
    }
    public void tryagain()
    {
        SceneManager.LoadScene(0);
    }
}
