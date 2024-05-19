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
    private Transform currentPoint;
    public float stoppingDistance = 0.01f;
    public float remainingDistance {
        get {
            return Vector2.Distance(transform.position, currentPoint.position);
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
        
        //UpdateAnimation();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SetDestination(Transform newPoint) {
        if (currentPoint == null) currentPoint = newPoint;
        
        if (currentPoint.position.x > newPoint.position.x) {
            rb.velocity = new Vector2(speed, 0);
            currentPoint = newPoint;
            Debug.Log(rb.velocity);
        }else {
            rb.velocity = new Vector2(-speed, 0);
            currentPoint = newPoint;
            Debug.Log(rb.velocity);
        }
        
    }
    /*void UpdateAnimation()
    {
        animator.SetFloat("LookAtX", lookAt.x);
        animator.SetFloat("LookAtY", lookAt.y);
        animator.SetFloat("Speed", rb.velocity.sqrMagnitude);
    }*/
}
