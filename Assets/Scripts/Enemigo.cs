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

    protected Vector3 destino;
    protected float distancia = 0;
    public bool estructuraDetectada = false;

    public NavMeshAgent agent;
    public GameObject player;
}
