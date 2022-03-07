using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class uiController : MonoBehaviour
{
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

        SceneManager.LoadScene("Castle");

    }

    public void Exit()
    {

        Application.Quit();

    }











}
