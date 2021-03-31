using UnityEngine;
using UnityEngine.SceneManagement;

public class Fase : MonoBehaviour
{
    public Jogador Jogador;
    public int NumeroDaFase;
   private void Reiniciar()
    {
        if (Jogador.Morreu)
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(NumeroDaFase);
            Time.timeScale = 1;
        }
    }
    private void Update()
    {
        Reiniciar();
    }
}
