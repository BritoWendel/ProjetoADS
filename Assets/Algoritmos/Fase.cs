using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fase : MonoBehaviour
{
    Jogador Jogador;
    public int NumeroDaFase;

    private void Start()
    {
        Jogador = FindObjectOfType<Jogador>();
    }
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
    public void Pausar()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    public void VoltarParaOMenu()
    {
        SceneManager.LoadScene(1);
    }
}
