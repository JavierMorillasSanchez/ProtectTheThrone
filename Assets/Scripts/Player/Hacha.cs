using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacha : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemigo"))
            if(!collision.GetComponent<Enemigo>().inmune)
                StartCoroutine(GetComponentInParent<Player>().daño(collision.gameObject));
    }
}
