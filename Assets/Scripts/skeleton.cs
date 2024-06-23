using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour
{
    [SerializeField] private float hp;
    private Animator animator;
    public bool alive = true;
    public int damage;
    private Rigidbody rbSkeleton;
    public PlayerMovement playerHealth;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rbSkeleton = gameObject.GetComponent<Rigidbody>();
    }
    public void TomarDano(float dano)
    {
        hp -= dano;

        if (hp <= 0)
        {
            if (alive) { Muerte(); }
        }
        else animator.SetTrigger("Hit");
    }

    public void Muerte()
    {
        animator.SetTrigger("Muerte");
        alive = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (alive)
        {
            if (collision.gameObject.tag == "Player")
            {
                playerHealth.takeDamage(damage);
            }
        }
    }
}
