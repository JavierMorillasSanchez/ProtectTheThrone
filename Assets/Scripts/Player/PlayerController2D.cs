using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController2D : MonoBehaviour
{
    //Aqui está el script del movimiento del personaje en 2d Top-Down

    public float moveSpeed = 2f;

    public Rigidbody2D rb;

    Vector2 movement;

    public GameObject[] enemigos;

    //public Animator animator;

    void Update()
    {
        Movimiento();
        Combate();
    }

    private void Combate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach (var enemigo in enemigos)
            {
                Vector3 dir = enemigo.transform.position - transform.position;
                dir = dir.normalized;
                enemigo.GetComponent<Rigidbody2D>().AddForce(dir * 30000);
                StartCoroutine(daño(enemigo));
            }
        }
    }

    private void Movimiento()
    {
        //Aqui ponemos el input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        /*animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y); 
        animator.SetFloat("Speed", movement.sqrMagnitude);*/
    }

    private void FixedUpdate()
    {
        //Aqui ponemos el movimiento
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator daño(GameObject enemigo)
    {
        enemigo.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        enemigo.GetComponent<NavMeshAgent>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        enemigo.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        enemigo.GetComponent<NavMeshAgent>().enabled = true;
    }

}
