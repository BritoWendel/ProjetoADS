using UnityEngine;

public class Abelha : MonoBehaviour
{
    public GameObject OrigemDaBala, Bala;
    public float IntervaloDeDisparo;
    public float timer1, timer2;
    public Area Area;
    public Animator Animator;
    public bool Morrendo;

    // Update is called once per frame
    void Update()
    {
        Disparar();
        Morrer();
    }
    void Disparar()
    {
        if (Area.EstaEmContato)
        {
            timer1 += Time.deltaTime;
            if(timer1 > IntervaloDeDisparo)
            {
                this.Animator.SetTrigger("Atacando");
                Instantiate(Bala, OrigemDaBala.transform);
                timer1 = 0;
            }
        }
    }
    void Morrer()
    {
        if (Morrendo)
        {
            Animator.SetBool("Morrendo", true);
            transform.Translate(0, -0.01f, 0);
            timer2 += Time.deltaTime;
            if(timer2 > 1)
                Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Morrendo = true;
    }
}
