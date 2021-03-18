using UnityEngine;

public class Jogador : MonoBehaviour
{
    //variaveis publicas
    public Rigidbody2D Rigidbody2D;
    public float VelocidadeDeMovimento;
    public SpriteRenderer SpriteRenderer;
    public float ForcaDoPulo;
    public Animator Animator;
    public float ForcaDoTrampolin;
    //Variaveis privadas
    private bool podePular;
    EstadosDoJogador Estado;
    void Start()
    {
        Estado = EstadosDoJogador.Ocioso;
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
    private void FixedUpdate()
    {
        Andar();
        Pular();
    }
    void Andar()
    {
        float eixohorizintal = Input.GetAxis("Horizontal");
        Flipar(eixohorizintal);
        eixohorizintal *= VelocidadeDeMovimento * Time.deltaTime;
        Vector2 forca = new Vector2(eixohorizintal, 0);
        Rigidbody2D.AddForce(forca, ForceMode2D.Force);
    }
    void Flipar(float valordoeixox)
    {
        if (valordoeixox > 0)
            SpriteRenderer.flipX = false;
        else if (valordoeixox < 0)
            SpriteRenderer.flipX = true;
    }
    void Pular()
    {
        if (podePular)
        {
            float eixodopulo = Input.GetAxis("Jump");
            eixodopulo *= ForcaDoPulo * Time.fixedDeltaTime;
            Vector2 forca = new Vector2(0, eixodopulo); 
            Rigidbody2D.AddForce(forca, ForceMode2D.Impulse);
        }
    }
    void Animar()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampolin"))
        {
            Vector2 forca = Vector2.up;
            Rigidbody2D.AddForce(forca * ForcaDoTrampolin * Time.deltaTime, ForceMode2D.Impulse);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
            podePular = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
            podePular = false;
    }
}