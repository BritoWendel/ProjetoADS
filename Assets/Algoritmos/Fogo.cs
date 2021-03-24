using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogo : MonoBehaviour
{
    public CapsuleCollider2D CapsuleCollider2D;
    public Animator Animator;
    public float TimeOn, TimeOff;
    private float time;

    private void Start()
    {
        time = 0;
        TimeOn += TimeOff;
    }
    private void Update()
    {
        time += Time.deltaTime;
        if(time >= TimeOff)
        {
            Acender();
        }
        if(time >= TimeOn)
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
