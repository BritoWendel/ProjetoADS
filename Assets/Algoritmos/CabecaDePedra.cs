using UnityEngine;
using System.Collections;
public class CabecaDePedra : MonoBehaviour
{
    Rigidbody2D Rigidbody2D;
    Animator Animator;
    public float VelocidadeDaSubida, VelocidadeDaDescida, TempoDeEspera;
    private float timer;
    private EstadosDaCabecaDePedra Estado;
    Area Area;
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        timer = 0;
        Estado = EstadosDaCabecaDePedra.NoAlto;
        Area = GetComponentInChildren<Area>();
    }
    private void FixedUpdate()
    {
        float distanciadoraio = 0.014f;
        float offSetY = 0.162f;
        Vector3 posicaoinicialraiodecima = transform.position;
        posicaoinicialraiodecima.y += offSetY;
        Vector3 posicaoinicialraiodebaixo = transform.position;
        posicaoinicialraiodebaixo.y -= offSetY;
        RaycastHit2D RaioDeCimaAcertou = Physics2D.Raycast(posicaoinicialraiodecima, Vector2.up, distanciadoraio);
        RaycastHit2D RaioDeBaixoAcertou = Physics2D.Raycast(posicaoinicialraiodebaixo, Vector2.down, distanciadoraio);
        Debug.DrawRay(posicaoinicialraiodecima, Vector2.up, Color.green);
        Debug.DrawRay(posicaoinicialraiodebaixo, Vector2.down, Color.yellow);
        MudarEstado(RaioDeBaixoAcertou, RaioDeCimaAcertou);
        Mover();
    }
    void Mover()
    {
        if (Area.EstaEmContato && Estado == EstadosDaCabecaDePedra.NoAlto)
            timer += Time.deltaTime;
        if (Estado == EstadosDaCabecaDePedra.NoAlto) //então desce
        {
            bool descer = timer > TempoDeEspera;
            if (descer)
                Rigidbody2D.MovePosition(Rigidbody2D.transform.position += Vector3.down * VelocidadeDaDescida * Time.deltaTime);
                
        }
        else if (Estado == EstadosDaCabecaDePedra.EmBaixo) // sobe
        {
            timer = 0;
            Rigidbody2D.MovePosition(Rigidbody2D.transform.position += Vector3.up * VelocidadeDaSubida * Time.deltaTime);
        }
    }
    void MudarEstado(RaycastHit2D raiodebaixo, RaycastHit2D raiodecima)
    {
        if(raiodebaixo.collider != null)
        {
            if (raiodebaixo.collider.CompareTag("Chao"))
                Estado = EstadosDaCabecaDePedra.EmBaixo;
        }
        if (raiodecima.collider != null)
        {
            if (raiodecima.collider.CompareTag("Teto"))
                Estado = EstadosDaCabecaDePedra.NoAlto;
        }
    }
}
