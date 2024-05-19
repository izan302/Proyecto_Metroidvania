using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeleton : MonoBehaviour
{
    [SerializeField] private float hp;
    private Animator animator;
    private bool alive = true;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
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

}
