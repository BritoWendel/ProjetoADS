using UnityEngine;

public class PlataformaCaindo : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    Animator Animator;
    Vector3 Direcao;
    const float Velocidade = 1.0f;
    const float TempoParaCair = 1.2f;
    bool PodeCair;
    float Timer;
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        Direcao = Vector3.down;
        PodeCair = false;
        Timer = 0;
    }
    private void FixedUpdate()
    {
        Cair();
    }
    void Cair()
    {
        if (PodeCair)
        {
            Timer -= -Time.deltaTime;
            bool cair = Timer > TempoParaCair;
            if (cair)
            {
                Rigidbody2D.MovePosition(Rigidbody2D.position + (Vector2)Direcao * Velocidade * Time.deltaTime);
                Animator.SetTrigger("Desligar");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PodeCair = true;
    }
}
