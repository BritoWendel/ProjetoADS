using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma : MonoBehaviour
{
    private PolygonCollider2D PolygonCollider2D;
    private Animator Animator;
    private SpriteRenderer SpriteRenderer;
    private float timer = 0;
    private void Start()
    {
        PolygonCollider2D = GetComponent<PolygonCollider2D>();
        Animator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3 && timer < 6)
            Animator.SetTrigger("Desaparecendo");
        else if (timer > 6 && timer < 9)
            Animator.SetTrigger("Aparecendo");           
        else if (timer > 9)
            timer = 0;
    }
}
