using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garra : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float LimiteBaixoOuEsquerda, LimiteCimaOuDireita, Velocidade;
    public EixoDeMovimento EixoDeMovimento;
    Vector3 direction;
    private void Start()
    {
        if (EixoDeMovimento == EixoDeMovimento.Vertical)
            direction = Vector3.up;
        else
            direction = Vector3.right;
    }
    private void FixedUpdate()
    {
        Rigidbody2D.MovePosition(Rigidbody2D.position + (Vector2)direction * Velocidade * Time.fixedDeltaTime);
        if (EixoDeMovimento == EixoDeMovimento.Vertical)
        {
            if (Rigidbody2D.position.y < LimiteBaixoOuEsquerda)
                direction = Vector3.up;
            else if (Rigidbody2D.position.y > LimiteCimaOuDireita)
                direction = Vector3.down;
        }
        else
        {
            if (Rigidbody2D.position.x < LimiteBaixoOuEsquerda)
                direction = Vector3.right;
            else if (Rigidbody2D.position.x > LimiteCimaOuDireita)
                direction = Vector3.left;
        }

    }
}
