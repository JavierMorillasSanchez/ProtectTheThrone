using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Orco1 : Enemigo
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
        //Iniciamos con la primera estrutura y comparamos la distancia con el resto
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

        //Comprobamos si hay una estructura en el rango de accion
        if (Vector2.Distance(transform.position, destino) <= distanciaDeteccion)
            estructuraDetectada = true;
        else
            estructuraDetectada = false;

        //Comprobamos la distancia con el player y actuamos en consecuencia
        if (Vector2.Distance(transform.position, player.transform.position) <= distanciaDeteccion && !estructuraDetectada)
            destino = player.transform.position;
    }
}