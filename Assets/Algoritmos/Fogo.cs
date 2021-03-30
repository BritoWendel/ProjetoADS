using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogo : MonoBehaviour
{
    public CapsuleCollider2D CapsuleCollider2D;
    public Animator Animator;
    public float TempoAceso, TempoApagado;
    private float time;

    private void Start()
    {
        CapsuleCollider2D = GetComponentInChildren<CapsuleCollider2D>();
        time = 0;
        TempoAceso += TempoApagado;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time >= TempoApagado)
        {
            Acender();
        }
        if(time >= TempoAceso)
        {
            time = 0;
            Apagar();
        }
    }
    private void Acender()
    {
        Animator.SetBool("Apagando", false);
        Animator.SetBool("Acendendo", true);
        CapsuleCollider2D.enabled = true;
    }
    private void Apagar()
    {
        Animator.SetBool("Acendendo", false);
        Animator.SetBool("Apagando", true);
        CapsuleCollider2D.enabled = false;
    }
}
