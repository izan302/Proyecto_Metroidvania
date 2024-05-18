using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;
using UnityEngine.UIElements;
using System;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rbPlayer;
    private float inputLateral;
     public bool PlayerFuera;
    private bool isGrounded;
    private bool mirandoDerecha;


    [SerializeField] float velocidad = 8f; 
    [SerializeField] float potenciaSalto = 16f;
    [SerializeField] GameObject BoundingBox;
    
    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        inputLateral = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, potenciaSalto);
        }

        if(Input.GetKeyUp(KeyCode.Space) && rbPlayer.velocity.y > 0f) {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, rbPlayer.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        Voltear();
    }

    private void FixedUpdate() {
        rbPlayer.velocity = new Vector2(inputLateral*velocidad, rbPlayer.velocity.y);
    }

    public void Voltear() {
        if (mirandoDerecha && inputLateral > 0f || !mirandoDerecha && inputLateral < 0f) {
            mirandoDerecha = !mirandoDerecha;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other == BoundingBox.GetComponent<Collider2D>()) {
            PlayerFuera = false;
        }

        if (other.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other == BoundingBox.GetComponent<Collider2D>()) {
            PlayerFuera = true;
        }

        if (other.gameObject.tag == "Ground") {
            isGrounded = false;
        }
    }
}
