using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour
{
    [SerializeField] public Transform player;

    [SerializeField] private float distance;

    public Vector3 initialPoint;

    private Animator animator;

    private SpriteRenderer spriteRenderer;


    private void Start()
    {
        animator = GetComponent<Animator>();
        initialPoint = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        animator.SetFloat("Distance", distance);
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
