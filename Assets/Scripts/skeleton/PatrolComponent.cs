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
    public float stoppingDistance = 0.0001f;
    Vector2 moveDirection;
    public float remainingDistance {
        get {
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
        rb.velocity = moveDirection * speed;
        //UpdateAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Vector2.zero;

       if (remainingDistance > stoppingDistance) {
            Debug.Log(remainingDistance);
            moveDirection = (destination - new Vector2(transform.position.x, transform.position.y)).normalized;
       }
    }

    public void SetDestination(Vector2 newDestination) {
        destination = newDestination;
        Debug.Log(destination);
    }
    /*void UpdateAnimation()
    {
        animator.SetFloat("LookAtX", lookAt.x);
        animator.SetFloat("LookAtY", lookAt.y);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }*/
}
