using UnityEngine;
using UnityEngine.UI;

public class Jogador : MonoBehaviour
{
    //variaveis publicas
    public Rigidbody2D Rigidbody2D;
    public float VelocidadeDeMovimento;
    public SpriteRenderer SpriteRenderer;
    public float ForcaDoPulo;
    public Animator Animator;
    public float ForcaDoTrampolin;
    public Vector2 Velocidade;
    public bool Morreu { get { return morreu; } set { morreu = value; } }
    //Variaveis privadas
    public bool podePular, morreu, estanaplataforma, tocounoteto, tocounochao;
    private float frutas;
    private EstadosDoJogador Estado;
    private Text QuantidadeDeFrutas;
    float eixohorizintal, eixodopulo;
    private void Start()
    {
        QuantidadeDeFrutas = FindObjectOfType<Text>();
        frutas = 0;
        morreu = false;
        Estado = EstadosDoJogador.NoAr;
    }
    private void Update()
    {
        eixohorizintal = Input.GetAxis("Horizontal");
        eixodopulo = Input.GetAxis("Jump");
        Animar(eixohorizintal);
        Morrer();
    }
    private void FixedUpdate()
    {
        Velocidade = Rigidbody2D.velocity;
        Andar(eixohorizintal);
        Pular(eixodopulo);
    }
    void Andar(float eixohorizintal)
    {
        Flipar(eixohorizintal);
        eixohorizintal *= VelocidadeDeMovimento * Time.deltaTime;
        Vector2 direcao = new Vector2(eixohorizintal, 0);
        Rigidbody2D.transform.Translate(direcao);
    }
    void Flipar(float valordoeixox)
    {
        if (valordoeixox > 0)
            SpriteRenderer.flipX = false;
        else if (valordoeixox < 0)
            SpriteRenderer.flipX = true;
    }
    void Pular(float eixodopulo)
    {
        if (podePular && eixodopulo > 0 && Velocidade.y == 0)
        {
            eixodopulo *= ForcaDoPulo * Time.fixedDeltaTime;
            Vector2 forca = new Vector2(0, eixodopulo);
            Rigidbody2D.AddForce(forca, ForceMode2D.Impulse);
            podePular = false;
        }
    }
    void Animar(float eixohorizontal)
    {
        if(Estado == EstadosDoJogador.NoAr && Velocidade.y < 0)
        {
            Animator.SetBool("Andando", false);
            Animator.SetBool("Subindo", false);
            Animator.SetBool("Descendo", true);
        }
        if (Estado == EstadosDoJogador.NoAr && Velocidade.y > 0)
        {
            Animator.SetBool("Andando", false);
            Animator.SetBool("Subindo", true);
            Animator.SetBool("Descendo", false);
        }
        if (Estado == EstadosDoJogador.NoChao && (eixohorizontal > 0 || eixohorizontal < 0))
        {
            Animator.SetBool("Andando", true);
            Animator.SetBool("Subindo", false);
            Animator.SetBool("Descendo", false);
        }
        if (Estado == EstadosDoJogador.NoChao && Mathf.Approximately(eixohorizontal, 0))
        {
            Animator.SetBool("Andando", false);
            Animator.SetBool("Subindo", false);
            Animator.SetBool("Descendo", false);
        }
    }
    void ImpulsionarNoTrampolin()
    {
        Vector2 forca = Vector2.up;
        Rigidbody2D.AddForce(forca * ForcaDoTrampolin * Time.deltaTime, ForceMode2D.Impulse);
    }
    private void ColetarFrutas()
    {
        frutas++;
        QuantidadeDeFrutas.text = frutas.ToString();
    }
    void Morrer()
    {
        morreu = estanaplataforma && tocounoteto;
        morreu = estanaplataforma && tocounochao;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampolin"))
            ImpulsionarNoTrampolin();
        if (collision.gameObject.CompareTag("Chao") || collision.gameObject.CompareTag("Plataforma"))
            podePular = true;
        if (collision.gameObject.CompareTag("Teto"))
            tocounoteto = true;
        if (collision.gameObject.CompareTag("Chao"))
            tocounochao = true;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao") || collision.gameObject.CompareTag("Plataforma"))
            Estado = EstadosDoJogador.NoChao;

        if (collision.gameObject.CompareTag("Plataforma"))
            estanaplataforma = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao") || collision.gameObject.CompareTag("Plataforma"))
            Estado = EstadosDoJogador.NoAr;
        if (collision.gameObject.CompareTag("Plataforma"))
            estanaplataforma = false;
        if (collision.gameObject.CompareTag("Teto"))
            tocounoteto = false;
        if (collision.gameObject.CompareTag("Chao"))
            tocounochao = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Armadilha") || collision.gameObject.CompareTag("Inimigo"))
            morreu = true;
        if (collision.gameObject.CompareTag("Fruta"))
            ColetarFrutas();
    }
}