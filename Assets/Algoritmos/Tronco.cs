using UnityEngine;

public class Tronco : MonoBehaviour
{
    public Area AreaEsquerda, AreaDireita;
    public GameObject OrigemDaBala, BalaDireita, BalaEsquerda;
    public float IntervaloDeDisparo;
    private SpriteRenderer SpriteRenderer;
    private DirecaoDoAlvo DirecaoDoAlvo;
    private float Timer;
    private Animator Animator;

    private void Start()
    {
        Timer = 0;
        DirecaoDoAlvo = DirecaoDoAlvo.ForaDeAlcance;
        SpriteRenderer = GetComponent<SpriteRenderer>();
        Animator = GetComponent<Animator>();
    }
    private void Update()
    {
        DefinirDirecaoDoAlvo();
        Flipar();
        Disparar();
    }

    private void Flipar()
    {
        switch (DirecaoDoAlvo)
        {
            case DirecaoDoAlvo.ADireita:
                SpriteRenderer.flipX = true;
                break;
            case DirecaoDoAlvo.AEsquerda:
                SpriteRenderer.flipX = false;
                break;
        }
    }
    private void DefinirDirecaoDoAlvo()
    {
        if (AreaDireita.EstaEmContato)
            DirecaoDoAlvo = DirecaoDoAlvo.ADireita;
        else if (AreaEsquerda.EstaEmContato)
            DirecaoDoAlvo = DirecaoDoAlvo.AEsquerda;
        else
            DirecaoDoAlvo = DirecaoDoAlvo.ForaDeAlcance;
    }
    private void Disparar()
    {
        if (DirecaoDoAlvo == DirecaoDoAlvo.ADireita)
        {
            Timer += Time.deltaTime;
            if (Timer > IntervaloDeDisparo)
            {
                Timer = IntervaloDeDisparo;
                Instantiate(BalaDireita, OrigemDaBala.transform);
                Timer = 0;
                this.Animator.SetTrigger("Atacando");
            }
        }
        if (DirecaoDoAlvo == DirecaoDoAlvo.AEsquerda)
        {
            Timer += Time.deltaTime;
            if (Timer > IntervaloDeDisparo)
            {
                Timer = IntervaloDeDisparo;
                Instantiate(BalaEsquerda, OrigemDaBala.transform);
                Timer = 0;
                this.Animator.SetTrigger("Atacando");
            }
        }
    }
}
