using UnityEngine;

public class Cogumelo : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    SpriteRenderer SpriteRenderer;
    CapsuleCollider2D CapsuleCollider2D;
    Animator Animator;
    float direcao, timer, timer2, velocidade;
    public float VelocidadeDeMovimento;
    bool EstaMovendo, EstaMorrendo;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        CapsuleCollider2D = GetComponentInChildren<CapsuleCollider2D>();
        Animator = GetComponent<Animator>();
        direcao = 1;
        timer = 0;
        timer2 = 0;
        velocidade = VelocidadeDeMovimento;
        CapsuleCollider2D.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Flipar();
        Animar();
        Parar();
        Morrer();
        ControlarTimer();
    }
    private void FixedUpdate()
    {
        Mover();
    }
    void Mover()
    {
        if(timer > 3 && timer < 8)
        {
            if (!EstaMorrendo)
            {
                VelocidadeDeMovimento = velocidade;
                if (SpriteRenderer.flipX)
                    direcao = 1;
                else
                    direcao = -1;
                Rigidbody2D.MovePosition(Rigidbody2D.position + new Vector2(direcao, 0) * Time.deltaTime * VelocidadeDeMovimento);
                EstaMovendo = true;
            }
        }
    }
    void Flipar()
    {
        if (direcao < 0)
            SpriteRenderer.flipX = false;
        else if (direcao > 0)
            SpriteRenderer.flipX = true;
    }
    void Animar()
    {
        if (EstaMovendo && !EstaMorrendo)
            Animator.SetBool("Andando", true);
        else if (!EstaMorrendo && !EstaMovendo)
            Animator.SetBool("Andando", false);
        else
        {
            Animator.SetBool("Andando", false);
            Animator.SetBool("Morrendo", true);
        }

    }
    void Parar()
    {
        if(timer < 2)
        {
            VelocidadeDeMovimento = 0;
            EstaMovendo = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (direcao == 1)
            direcao = -1;
        else
            direcao = 1;
        if (collision.gameObject.CompareTag("Player"))
            EstaMorrendo = true;
    }
    void Morrer()
    {
        if(EstaMorrendo)
        {
            CapsuleCollider2D.enabled = false;
            VelocidadeDeMovimento = 0;
            direcao = 0;
            EstaMovendo = false;
        }
    }
    void ControlarTimer()
    {
        if (!EstaMorrendo)
        {
            timer += Time.deltaTime;
            if (timer > 8)
                timer = 0;
        }
        else
        {
            timer2 += Time.deltaTime;
            if(timer2 > 1)
                Destroy(gameObject);
        }
    }
}
