using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string Level1;
    public string Level2;

    public void StartLevel1()
    {
        SceneManager.LoadScene(Level1);
    }
    public void StartLevel2()
    {
        SceneManager.LoadScene(Level2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
