using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    public int ataque = 5;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(!collision.GetComponentInParent<Player>().inmuneTrampa && !collision.GetComponentInParent<Player>().muerte)
            {
                StartCoroutine(collision.GetComponentInParent<Player>().trampa(ataque));
            }
        }

        if (collision.CompareTag("Enemigo"))
        {
            if (!collision.GetComponentInParent<Enemigo>().inmuneTrampa && !collision.GetComponentInParent<Enemigo>().muerte)
            {
                StartCoroutine(collision.GetComponentInParent<Enemigo>().trampa(ataque));
            }
        }
    }
}