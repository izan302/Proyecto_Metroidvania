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
    private Animator animator;
    public float playerHealth = 100;
    public float currentHealth;
    private bool alive = true;

    public HealthBar healthBar;

    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float danoGolpe;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;
    [SerializeField] float velocidad = 8f; 
    [SerializeField] float potenciaSalto = 16f;
    [SerializeField] GameObject BoundingBox;

    void Start()
    {
        rbPlayer = gameObject.GetComponent<Rigidbody2D>(); 
        animator = GetComponent<Animator>();
        currentHealth = playerHealth;
        healthBar.setMaxHealth(playerHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            inputLateral = Input.GetAxisRaw("Horizontal");

            if (isGrounded)
            {
                animator.SetBool("Falling", false);
                animator.SetBool("Grounded", true);
            }
            else
            {
                animator.SetBool("Grounded", false);
            }

            if (rbPlayer.velocity.y < 0f)
            {
                animator.SetBool("Falling", true);
            }

            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, potenciaSalto);
                animator.SetTrigger("Jump");
            }


            if (Input.GetKeyUp(KeyCode.Space) && rbPlayer.velocity.y > 0f)
            {
                rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, rbPlayer.velocity.y * 0.5f);

            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if(tiempoSiguienteAtaque > 0)
            {
                tiempoSiguienteAtaque -= Time.deltaTime;
            }
            if (Input.GetButtonDown("Fire1") && tiempoSiguienteAtaque <= 0)
            {
                Golpe();
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }
            Voltear();
        }
    }

    private void FixedUpdate() {
        if (alive)
        {
            rbPlayer.velocity = new Vector2(inputLateral * velocidad, rbPlayer.velocity.y);
            animator.SetBool("Walking", true);
            if (inputLateral == 0)
            {
                animator.SetBool("Walking", false);
            }
        }
    }

    public void Voltear() {
        if (mirandoDerecha && inputLateral > 0f || !mirandoDerecha && inputLateral < 0f) {
            mirandoDerecha = !mirandoDerecha;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private void Golpe()
    {
        animator.SetTrigger("Attack1");
        
        Collider2D[] objetos = Physics2D.OverlapCircleAll (controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.GetComponent<skeleton>().TomarDano(danoGolpe);
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
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

     public void takeDamage(float damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("Hurt");

        healthBar.setHealth(currentHealth);

        if (currentHealth < 0)
        {
            healthBar.setHealth(0);
            animator.SetTrigger("Death");
            alive = false;
        }
    }
}
