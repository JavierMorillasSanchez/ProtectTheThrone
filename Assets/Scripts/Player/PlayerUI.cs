using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider healthPoints;
    public Text ataque;
    public Text defensa;

    private void Update()
    {
        healthPoints.value = Player.instance.vida;
        ataque.text = Player.instance.fuerza.ToString();
        defensa.text = Player.instance.defensa.ToString();
    }
}
