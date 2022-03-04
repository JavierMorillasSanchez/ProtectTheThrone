using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public int daño;
    public int defensa;
    public int vida;
    public int distanciaDeteccion;
    public int impulso;

    protected Vector3 destino;
    protected float distancia = 0;
    public bool estructuraDetectada = false;

    public NavMeshAgent agent;
    public GameObject player;
    public Animator anim;

    public bool inmune = false;
    public bool ataque = false;

    public void Movimiento()
    {
        //Establecemos la ruta del enemigo y atacamos si estamos cerca
        if (Vector2.Distance(transform.position, destino) > 5 && !ataque)
        {
            if (GetComponent<NavMeshAgent>().isActiveAndEnabled)
            {
                agent.isStopped = false;    
                agent.SetDestination(destino);
                anim.Play("Walk");
            }

            if (agent.hasPath)
            {

                if (agent.path.corners[1].x > transform.position.x)
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                else if (agent.path.corners[1].x < transform.position.x)
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            if(!ataque)
                StartCoroutine(Ataque());
        }
    }

    IEnumerator Ataque()
    {
        ataque = true;
        if (GetComponent<NavMeshAgent>().isActiveAndEnabled)
            agent.isStopped = true;
        anim.Play("Attack");
        yield return new WaitForSecondsRealtime(0.5f);
        anim.Play("Idle");
        ataque = false;
    }
}