using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiController : MonoBehaviour
{
    public static uiController instance;

    private void Awake()
    {
        instance = this;
    }
    public void startStartMenu()
    {

        SceneManager.LoadScene("startMenu");
    }

    public void startYouFailMenu()
    {

        SceneManager.LoadScene("youFailMenu");

    }

    public void startYouWonMenu()
    {

        SceneManager.LoadScene("youWonMenu");

    }

    public void startMainMenu()
    {

        SceneManager.LoadScene("mainMenu");

    }

    public void startCastle()
    {

        SceneManager.LoadScene("Castillo");

    }

    public void Exit()
    {

        Application.Quit();

    }
}
