using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float Velocidade;
    public Vector3 Direcao;
    private void Update()
    {
        Mover();
    }
    private void Mover()
    {
        transform.position += Direcao * Velocidade * Time.deltaTime;
    }
}
