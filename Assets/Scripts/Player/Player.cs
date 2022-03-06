using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Aqui est� el script del movimiento del personaje en 2d Top-Down
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
    bool run = false;

    public int impulso;

    public bool inmune = false;
    public bool muerte = false;

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
        if (muerte) return;
        if (voltereta) return;

        if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Movimiento();
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }

        Combate();
        Vida();
    }

    private void Vida()
    {
        if (vida<=0)
        {
            inmune = true;
            muerte = true;
            movement.x = 0;
            movement.y = 0;
            anim.Play("Die");
            StartCoroutine(Fin());
        }
    }

    IEnumerator Fin()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Combate()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.P))
        {
            if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                anim.Play("Attack");
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
        {
            moveSpeed = runSpeed;
            run = true;
        }
        else
        {
            moveSpeed = move;
            run = false;
        }

        if (movement.x > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            if (!run)
                anim.Play("Walk");
            else
                anim.Play("Run");
        }
        else if (movement.x < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            if (!run)
                anim.Play("Walk");
            else
                anim.Play("Run");
        }
        else if (movement.y < -0.1f || movement.y > 0.1f)
        {
            if (!run)
                anim.Play("Walk");
            else
                anim.Play("Run");
        }
        else
        {
            anim.Play("Idle");
        }
            

        if ((Input.GetMouseButtonDown(1) ||Input.GetKeyDown(KeyCode.O)) && puedeVoltereta)
        {
            voltereta = true;
            puedeVoltereta = false;
            moveSpeed = move;
            anim.Play("Dodge");
            inmune = true;
            StartCoroutine(Voltereta());
        }

        /*animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y); 
        animator.SetFloat("Speed", movement.sqrMagnitude);*/
    }

    IEnumerator Voltereta()
    {
        moveSpeed += volteretaVelocidad;
        yield return new WaitForSeconds(0.4f);
        moveSpeed -= volteretaVelocidad;
        voltereta = false;
        inmune = false;
        anim.Play("Idle");
        yield return new WaitForSeconds(volteretaRecarga);
        puedeVoltereta = true;
    }

    private void FixedUpdate()
    {
        //Aqui ponemos el movimiento
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public IEnumerator da�o(GameObject enemigo)
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
        
    }
    public void FinAtaque()
    {
        anim.Play("Idle");
    }
}
