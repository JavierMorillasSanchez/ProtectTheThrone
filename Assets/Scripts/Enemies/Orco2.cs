using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orco2 : Enemigo
{
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();

        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    void Start()
    {
        navMeshPath = new NavMeshPath();
    }

    void Update()
    {
        if (muerte) return;
        Vista();
        Movimiento();
        Vida();
    }

    private void Vista()
    {
        //Comprobamos la distancia con el player y decisimos el destino
        if(Vector2.Distance(transform.position, player.transform.position)<= distanciaDeteccion)
        {
            if(agent.isActiveAndEnabled)
            {
                agent.CalculatePath(player.transform.position, navMeshPath);
                if (navMeshPath.status == NavMeshPathStatus.PathComplete)
                    destino = player.transform.position;
            }
        }
        else
        {
            if (Estructuras.instance.estructuras[0] != null)
            {
                distancia = Vector2.Distance(transform.position, Estructuras.instance.estructuras[0].transform.position);
                destino = Estructuras.instance.estructuras[0].transform.position;
            }
            else
            {
                Estructuras.instance.estructuras.Remove(Estructuras.instance.estructuras[0].gameObject);
            }
                  
            foreach (var estructura in Estructuras.instance.estructuras)
            {
                if (estructura==null)
                {
                    Estructuras.instance.estructuras.Remove(estructura);
                    return;
                }
                else
                {
                    if (Vector2.Distance(transform.position, estructura.transform.position) < distancia)
                    {
                        distancia = Vector2.Distance(transform.position, estructura.transform.position);
                        destino = estructura.transform.position;
                    }
                }
            }
        }
    }
}
