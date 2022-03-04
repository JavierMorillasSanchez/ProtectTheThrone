using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    //Aqui está el script del movimiento del personaje en 2d Top-Down

    public float moveSpeed = 10f;
    float move = 0;

    public float runSpeed = 10f;
    public int fuerza = 3;
    public int defensa = 3;
    public int vida = 15;

    public float volteretaVelocidad = 40f;
    public float volteretaRecarga = 1f;
    bool voltereta = false;
    bool puedeVoltereta = true;

    public int impulso;

    public bool inmune = false;

    public Rigidbody2D rb;
    Vector2 movement;

    public Animator anim;
    public GameObject hacha;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        move = moveSpeed;
    }

    void Update()
    {
        if (voltereta) return;

        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque"))
        {
            Movimiento();
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }

        Combate();
    }

    private void Combate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque"))
            {
                anim.SetBool("Ataque", true);
            }
        }
    }

    private void Movimiento()
    {
        //Aqui ponemos el input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = Vector2.ClampMagnitude(movement, 1);

        if (Input.GetKey(KeyCode.LeftShift))
            moveSpeed = runSpeed;
        else
            moveSpeed = move;

        if (movement.x > 0.1f)
            transform.localScale = new Vector3(1, 1, 1);
        else if (movement.x < -0.1f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetMouseButtonDown(1) && puedeVoltereta)
        {
            voltereta = true;
            puedeVoltereta = false;
            moveSpeed = move;
            anim.SetBool("Voltereta", true);
            StartCoroutine(Voltereta());
        }

        /*animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y); 
        animator.SetFloat("Speed", movement.sqrMagnitude);*/
    }

    IEnumerator Voltereta()
    {
        moveSpeed += volteretaVelocidad;
        yield return new WaitForSeconds(0.1f);
        moveSpeed -= volteretaVelocidad;
        voltereta = false;
        anim.SetBool("Voltereta", false);
        yield return new WaitForSeconds(volteretaRecarga);
        puedeVoltereta = true;

    }

    private void FixedUpdate()
    {
        //Aqui ponemos el movimiento
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public IEnumerator daño(GameObject enemigo)
    {
        Vector3 dir = enemigo.transform.position - transform.position;
        dir = dir.normalized;
        enemigo.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        enemigo.GetComponent<Rigidbody2D>().angularVelocity = 0;
        enemigo.GetComponent<Rigidbody2D>().AddForce(dir * impulso);

        enemigo.GetComponent<Enemigo>().vida -= fuerza - enemigo.GetComponent<Enemigo>().defensa;


        enemigo.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        enemigo.GetComponent<NavMeshAgent>().enabled = false;
        enemigo.GetComponent<Animator>().Play("Hurt");
        enemigo.GetComponent<Enemigo>().inmune = true;
        yield return new WaitForSeconds(0.5f);
        enemigo.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
        if (enemigo.GetComponent<Enemigo>().vida <= 0)
        {
            enemigo.GetComponent<Animator>().Play("Die");
            enemigo.GetComponent<Collider2D>().enabled = false;
            yield break;
        }
        enemigo.GetComponent<NavMeshAgent>().enabled = true;
        enemigo.GetComponent<Enemigo>().inmune = false;
    }

    public void InicioAtaque()
    {
        hacha.GetComponentInChildren<Collider2D>().enabled = true;
    }
    public void FinAtaque()
    {
        hacha.GetComponentInChildren<Collider2D>().enabled = false;
        anim.SetBool("Ataque", false);
    }
}
