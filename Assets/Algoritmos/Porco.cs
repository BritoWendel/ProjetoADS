using UnityEngine;

public class Porco : MonoBehaviour
{
    bool andando = false;
    float timer, direcao, velocidade = 0;
    private Rigidbody2D Rigidbody2D;
    private SpriteRenderer SpriteRenderer;
    private Animator Animator;

    public float VelocidadeDeMovimento;
    private void Start()
    {
        direcao = 1;
        velocidade = VelocidadeDeMovimento;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
    }
    void ControlarTime()
    {
        timer += Time.deltaTime;
        if (timer > 8)
            timer = 0;
    }
    void Mover()
    {
        if(timer > 3 && timer < 8)
        {
            VelocidadeDeMovimento = velocidade;
            if (SpriteRenderer.flipX)
                direcao = 1;
            else
                direcao = -1;
            Rigidbody2D.MovePosition(Rigidbody2D.position + new Vector2(direcao, 0) * Time.deltaTime * VelocidadeDeMovimento);
            andando = true;
        }
    }
    void Parar()
    {
        if(timer < 2)
        {
            VelocidadeDeMovimento = 0;
            andando = false;
        }
    }
    void Animar()
    {
        if (!andando)
            Animator.SetBool("Andando", false);
        else
            Animator.SetBool("Andando", true);
    }
    void Flipar()
    {
        if (direcao < 0)
            SpriteRenderer.flipX = false;
        else if (direcao > 0)
            SpriteRenderer.flipX = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (direcao == 1)
            direcao = -1;
        else
            direcao = 1;
    }
    private void Update()
    {
        ControlarTime();
        Parar();
        Animar();
    }
    private void FixedUpdate()
    {
        Flipar();
        Mover();
    }
}
