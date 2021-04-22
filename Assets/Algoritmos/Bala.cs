using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocidade;
    public Vector3 Direcao;
    float timer;
    private void Update()
    {
        Mover();
    }
    private void Mover()
    {
        timer += Time.deltaTime;
        if(timer >0.4)
            transform.position += Direcao * Velocidade * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
