using UnityEngine;

public class SeguirJogador : MonoBehaviour
{
    Jogador Jogador;
    Vector3 CameraOffset;
    [Range(0.01f,1.0f)]
    public float FatorDeSuavidade = 1f;

    void Start()
    {
        Jogador = FindObjectOfType<Jogador>();
        transform.position = new Vector3(Jogador.transform.position.x, Jogador.transform.position.y, -10);
        CameraOffset = transform.position - Jogador.transform.position;
        CameraOffset.y = CameraOffset.y + 0.5f;
    }
    private void FixedUpdate()
    {
        Seguir();
    }
    void Seguir()
    {
        Vector3 novaPosicao = Jogador.transform.position + CameraOffset;
        transform.position = Vector3.Slerp(transform.position, novaPosicao, FatorDeSuavidade);
    }
}
