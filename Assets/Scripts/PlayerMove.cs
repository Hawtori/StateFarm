using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float speed;

    private Vector2 movement;
    private bool canMove;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        canMove = true;
    }

    private void Update()
    {
        if (canMove) GetInputs();
        Anims();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void GetInputs()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void Anims()
    {
        if (movement.y > 0) anim.SetBool("Front", false);
        if (movement.y < 0) anim.SetBool("Front", true);
    }

    private void MovePlayer()
    {
        movement.Normalize();

        rb.velocity = movement * speed;
    }
}
