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
    [SerializeField] float VelocidadLateral;
    [SerializeField] float VelocidadSalto;
    [SerializeField] GameObject BoundingBox;
    public bool PlayerFuera;
    private bool isGrounded;

    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D)) {
            rbPlayer.AddForce(new Vector2(VelocidadLateral, 0));
            //Debug.Log("Aguacate");
        }
        if(Input.GetKeyUp(KeyCode.D)) {
            rbPlayer.velocity = Vector3.zero;
            //Debug.Log("Aguacate");
        }
        if(Input.GetKey(KeyCode.A)) {
            rbPlayer.AddForce(new Vector2(-VelocidadLateral, 0));
            //Debug.Log("Aguacate");
        }
         if(Input.GetKeyUp(KeyCode.A)) {
            rbPlayer.velocity = Vector3.zero;
            //Debug.Log("Aguacate");
        }
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rbPlayer.AddForce(new Vector2(0, VelocidadSalto));
            //Debug.Log("Salto");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
