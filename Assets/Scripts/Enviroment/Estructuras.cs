using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estructuras : MonoBehaviour
{
    public static Estructuras instance;
    public List<GameObject> estructuras = new List<GameObject>();

    private void Awake()
    {
        instance = this;
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Estructura"))
        {
            estructuras.Add(e);
        }
    }
}
