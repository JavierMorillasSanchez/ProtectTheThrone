using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public GameObject[] oleada1;
    public GameObject[] oleada2;
    public GameObject[] oleada3;

    public int timer1 = 60;
    public int timer2 = 120;
    public int timer3 = 180;

    public int oleada=0;
    public int orcos = 0;

    private void Awake()
    {
        instance = this;
    }

    private IEnumerator Start()
    {
        oleada++;
        yield return new WaitForSeconds(SpawnManager.instance.timer1);
        oleada++;
        yield return new WaitForSeconds(SpawnManager.instance.timer2);
        oleada++;
    }

    private void Update()
    {
        if (oleada==3 && orcos<=0)
        {
            uiController.instance.startYouWonMenu();
        }
    }
}
