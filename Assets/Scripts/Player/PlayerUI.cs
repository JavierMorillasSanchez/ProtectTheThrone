using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider healthPoints;
    public Slider healthPointsTrono;
    public Text ataque;
    public Text defensa;
    public GameObject trono;

    private void Awake()
    {
        //healthPointsTrono.maxValue = trono.GetComponent<Estructura>().vida;
        //healthPoints.maxValue = Player.instance.vida;
    }
    private void Update()
    {
        healthPoints.value = Player.instance.vida;
        healthPointsTrono.value = trono.GetComponent<Estructura>().vida;
        ataque.text = Player.instance.fuerza.ToString();
        defensa.text = Player.instance.defensa.ToString();
    }
}
