using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] enemigos;

    void Start()
    {
        InvokeRepeating("NuevoOrco", 2, 2);
    }

    private void NuevoOrco()
    {
        Instantiate(enemigos[Random.Range(0, enemigos.Length)], transform.position, transform.rotation);
    }
}
