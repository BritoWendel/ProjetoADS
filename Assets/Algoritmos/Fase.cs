using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fase : MonoBehaviour
{
    Jogador Jogador;
    AudioSource AudioSource;
    Fim Fim;
    private float contador;
    private bool tocarUmaVez;
    public int NumeroDaFase;
    public AudioClip AudioClip;
    public AudioClip MusicaFinal;

    private void Start()
    {
        Jogador = FindObjectOfType<Jogador>();
        AudioSource = GetComponent<AudioSource>();
        Fim = FindObjectOfType<Fim>();
        AudioSource.clip = AudioClip;
        AudioSource.Play();
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
    private void Finalizar()
    {
        if (Fim.Ativado){
            if (!tocarUmaVez)
            {
                AudioSource.Stop();
                AudioSource.clip = MusicaFinal;
                AudioSource.Play();
                tocarUmaVez = true;
            }
            contador += Time.deltaTime;
            if(contador > 3)
                VoltarParaOMenu();
        }
    }
    private void Update()
    {
        Reiniciar();
        Finalizar();
    }
    public void Pausar()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            AudioSource.Pause();
        }
        else
        {
            Time.timeScale = 1;
            AudioSource.Play();
        }
    }
    public void VoltarParaOMenu()
    {
        SceneManager.LoadScene(1);
    }
}
