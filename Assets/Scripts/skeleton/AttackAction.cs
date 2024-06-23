using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAgent : MonoBehaviour
{
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    [SerializeField] private float danoGolpe;
    [SerializeField] private float tiempoEntreAtaques;
    [SerializeField] private float tiempoSiguienteAtaque;
    private bool attack = false;
    private Animator animator;
    public skeleton skeleton;

    void Start()
    {
        animator = GetComponent<Animator>();

    }
    void Update()
    {
        if (skeleton.alive)
        {
            if (tiempoSiguienteAtaque > 0)
            {
                tiempoSiguienteAtaque -= Time.deltaTime;
            }
            if (tiempoSiguienteAtaque <= 0 && attack)
            {
                Golpe();
                tiempoSiguienteAtaque = tiempoEntreAtaques;
            }
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("Attack");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Player"))
            {
                colisionador.transform.GetComponent<PlayerMovement>().takeDamage(danoGolpe);
            }
        }
        attack = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }

    public void Ready()
    {
        attack = true;
    }
}
