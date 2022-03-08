using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Slider HealthPoints;
    public HealthController healthBar;

    private void Update()
    {
        HealthPoints.value = Player.instance.vida;
    }
}
