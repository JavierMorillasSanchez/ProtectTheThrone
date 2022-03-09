using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public GameObject[] oleada1;
    public GameObject[] oleada2;
    public GameObject[] oleada3;

    public int timer1 = 60;
    public int timer2 = 120;
    public int timer3 = 180;

    public int oleada = 0;
    public int orcos = 0;

    public Text survive;
    public Text wave;
    public Text txtTimer;
    float timer;

    private void Awake()
    {
        instance = this;
        Invoke("HideText", 3);
    }

    private IEnumerator Start()
    {
        oleada++;
        timer = timer1;
        yield return new WaitForSeconds(timer1);
        oleada++;
        timer = timer2;
        yield return new WaitForSeconds(timer2);
        oleada++;
    }

    private void Update()
    {
        wave.text = "Wave " + oleada.ToString() + "/3";
        timer -= Time.deltaTime;
        txtTimer.text = "Next Wave in: " + Mathf.CeilToInt(timer).ToString() + "s";
        if (oleada == 3) txtTimer.text = "";

        if (oleada==3 && orcos<=0)
        {
            uiController.instance.startYouWonMenu();
        }
    }

    void HideText()
    {
        survive.text = "";
    }
}
