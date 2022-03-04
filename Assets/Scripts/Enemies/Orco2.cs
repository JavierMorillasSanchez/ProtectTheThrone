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
        
    }

    void Update()
    {
        if (vida > 0)
        {
            Vista();
            Movimiento();
        }
    }

    private void Vista()
    {
        //Comprobamos la distancia con el player y decisimos el destino
        if(Vector2.Distance(transform.position, player.transform.position)<= distanciaDeteccion)
            destino = player.transform.position;
        else
        {
            distancia = Vector2.Distance(transform.position, Estructuras.instance.estructuras[0].transform.position);
            destino = Estructuras.instance.estructuras[0].transform.position;
            foreach (var estructura in Estructuras.instance.estructuras)
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
