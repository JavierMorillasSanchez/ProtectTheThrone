using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Troll : Enemigo
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
        if (muerte) return;
        Vista();
        Movimiento();
        Vida();
    }

    private void Vista()
    {
        //Iniciamos con la primera estrutura y comparamos la distancia con el resto
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
            if (estructura == null)
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
