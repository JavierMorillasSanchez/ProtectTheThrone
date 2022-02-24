using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    //Aqui está el script del movimiento del personaje en 2d Top-Down

    public float moveSpeed = 2f;

    public Rigidbody2D rb;

    Vector2 movement;

    //public Animator animator;

    // Update is called once per frame
    void Update()
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

}
