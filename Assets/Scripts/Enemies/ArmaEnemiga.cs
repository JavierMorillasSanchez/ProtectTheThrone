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
    }

    IEnumerator Impacto(Collider2D collision, int objetivo)
    {
        collision.GetComponent<Player>().vida -= GetComponentInParent<Enemigo>().daño - collision.GetComponent<Player>().defensa;
        collision.GetComponent<Player>().enabled = false;
        Vector3 dir = collision.transform.position - transform.parent.position;
        dir = dir.normalized;
        collision.GetComponent<Rigidbody2D>().AddForce(dir * GetComponentInParent<Enemigo>().impulso);
        collision.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);

        yield return new WaitForSeconds(0.2f);
        collision.GetComponent<Player>().enabled = true; 
        collision.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);

        yield return new WaitForSeconds(0.1f);
        collision.GetComponent<Player>().inmune = false;
    }
}
