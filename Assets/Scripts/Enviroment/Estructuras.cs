using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estructuras : MonoBehaviour
{
    public static Estructuras instance;
    public GameObject[] estructuras;

    private void Awake()
    {
        instance = this;
        estructuras = GameObject.FindGameObjectsWithTag("Estructura");
    }
}
