using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaEnemiga : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            if(!collision.GetComponent<Player>().inmune)
            {
                collision.GetComponent<Player>().inmune = true;
                StartCoroutine(Impacto(collision, 1));
            }
        }
        if (collision.CompareTag("Estructura"))
        {
            StartCoroutine(Impacto(collision, 0));
        }
    }

    IEnumerator Impacto(Collider2D collision, int objetivo)
    {
        if(objetivo==0)
        {
            collision.GetComponent<Estructura>().vida-= GetComponentInParent<Enemigo>().daño - collision.GetComponent<Estructura>().defensa;
            if (collision.GetComponent<Estructura>().vida <= 0)
            {
                Estructuras.instance.estructuras.Remove(collision.gameObject);
                Destroy(collision.gameObject);
            }
                
        }
        else
        {
            collision.GetComponent<Player>().vida -= GetComponentInParent<Enemigo>().daño - collision.GetComponent<Player>().defensa;
            collision.GetComponent<Player>().enabled = false;
            Vector3 dir = collision.transform.position - transform.parent.position;
            dir = dir.normalized;
            collision.GetComponent<Rigidbody2D>().AddForce(dir * GetComponentInParent<Enemigo>().impulso);
            collision.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
            collision.GetComponent<Animator>().Play("Hurt");

            yield return new WaitForSeconds(0.2f);
            collision.GetComponent<Player>().enabled = true;
            collision.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
            collision.GetComponent<Animator>().Play("Idle");

            yield return new WaitForSeconds(0.1f);

            if (!collision.GetComponent<Player>().muerte)
                collision.GetComponent<Player>().inmune = false;
        }
    }
}
