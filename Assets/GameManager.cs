using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int FPS = 60;

    public GameObject trono;

    void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = FPS;
    }

    private IEnumerator Start()
    {
        yield return null;
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (!trono)
            uiController.instance.startYouFailMenu();
    }
}
