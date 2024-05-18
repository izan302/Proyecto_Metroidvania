using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour
{
    [SerializeField] public Transform player;

    [SerializeField] private float distance;

    [SerializeField] private float speed;

    [SerializeField] private float hp;
     
    public Vector3 initialPoint;

    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool alive = true;



    private void Start()
    {
        animator = GetComponent<Animator>();
        initialPoint = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (alive)
        {
            distance = Vector2.Distance(transform.position, player.position);
            animator.SetFloat("Distance", distance);

            if (distance < 9 && distance > 3)
            {
                if (facingRight)
                {
                    rb.velocity = new Vector2(speed, 0);
                }
                else { rb.velocity = new Vector2(-speed, 0); }
                animator.SetBool("Walking", true);
            }
            else if (distance < 3)
            {
                //a esta distancia deberia atacar
            }


            Voltear();
        }
    }

    public void TomarDano(float dano)
    {
        hp -= dano;

        if(hp < 0)
        {
            Muerte();
        }
    }

    public void Muerte()
    {
        animator.SetTrigger("Muerte");
        alive = false;
    }

    public void Voltear()
    {
        if (facingRight && player.position.x < transform.position.x || !facingRight && player.position.x > transform.position.x)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void Turn(Vector3 objective)
    {
        if (transform.position.x <objective.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

}
