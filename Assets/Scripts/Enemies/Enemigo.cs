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

    public bool muerte = false;
    public bool inmune = false;
    public bool inmuneTrampa = false;
    public bool ataque = false;

    public AudioClip hurt;
    public AudioClip die;

    protected NavMeshPath navMeshPath;

    public void Movimiento()
    {
        //Establecemos la ruta del enemigo y atacamos si estamos cerca
        if (Vector2.Distance(transform.position, destino) > 6 && !ataque)
        {
            if (GetComponent<NavMeshAgent>().isActiveAndEnabled)
            {
                agent.isStopped = false;    
                agent.SetDestination(destino);
                anim.Play("Walk");
            }

            if (agent.hasPath)
            {
                if(agent.path.corners.Length>0)
                {
                    if (agent.path.corners[1].x > transform.position.x)
                        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                    else if (agent.path.corners[1].x < transform.position.x)
                        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
                }
            }
        }
        else
        {
            if(!ataque)
                StartCoroutine(Ataque());
        }
    }

    public void Vida()
    {
        if (vida <= 0)
        {
            muerte = true;
            anim.Play("Die");
            SoundManager.instance.SoundPlay(GetComponent<AudioSource>(), die);
            SpawnManager.instance.orcos--;
            if(agent.isActiveAndEnabled)
                agent.isStopped = true;
            foreach (var c in GetComponents<Collider2D>())
            {
                c.enabled = false;
            }
        }
    }

    IEnumerator Ataque()
    {
        ataque = true;
        if (GetComponent<NavMeshAgent>().isActiveAndEnabled)
            agent.isStopped = true;
        anim.Play("Attack");
        yield return new WaitForSecondsRealtime(0.5f);
        if (!muerte)
            anim.Play("Idle");
        ataque = false;
    }

    public IEnumerator trampa(int ataque)
    {
        vida -= Mathf.Clamp(ataque - defensa,3,1000);
        SoundManager.instance.SoundPlay(GetComponent<AudioSource>(), hurt);
        inmuneTrampa = true;
        GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        yield return new WaitForSeconds(0.75f);
        inmuneTrampa = false;
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }
}