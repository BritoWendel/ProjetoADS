using UnityEngine;

public class Slime : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private SpriteRenderer SpriteRenderer;
    private float timer, direcao;
    public float VelocidadeDeMovimento;
    private void Start()
    {
        direcao = 1;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Flipar()
    {
        if (direcao < 0)
            SpriteRenderer.flipX = false;
        else if (direcao > 0)
            SpriteRenderer.flipX = true;
    }
    void Mover()
    {
        if (SpriteRenderer.flipX)
            direcao = 1;
        else
            direcao = -1;
        Rigidbody2D.MovePosition(Rigidbody2D.position + new Vector2(direcao, 0) * Time.deltaTime * VelocidadeDeMovimento);
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
        Flipar();
    }
    private void FixedUpdate()
    {
        Mover();
    }
}
