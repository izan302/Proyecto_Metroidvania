using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrollingAgent : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Rigidbody2D rb;
    Animator animator;
    private Vector2 destination;
    public Transform currentPoint;
    public float stoppingDistance = 1f;
    Vector2 moveDirection;

    public skeleton skeleton;

    public float remainingDistance
    {
        get
        {
            return (destination - new Vector2(transform.position.x, transform.position.y)).magnitude;
        }
    }
    public Vector2 velocity
    {
        get
        {
            return rb.velocity;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (skeleton.alive)
        {
            rb.velocity = moveDirection * speed;
            UpdateAnimation();
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (skeleton.alive)
        {

            moveDirection = Vector2.zero;

            if (remainingDistance > stoppingDistance)
            {
                moveDirection = (destination - new Vector2(transform.position.x, transform.position.y)).normalized;
            }

            Vector3 localScale = transform.localScale;
            if (destination.x > transform.position.x)
            {
                localScale.x = 4.5f;
                transform.localScale = localScale;
            }
            else
            {
                localScale.x = -4.5f;
                transform.localScale = localScale;
            }
        }
    }

    public void SetDestination(Vector2 newDestination)
    {
        destination = newDestination;
    }

    void UpdateAnimation()
    {

    }
}
