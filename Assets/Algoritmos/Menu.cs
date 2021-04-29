using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void CarregarFase(int faseID)
    {
        SceneManager.LoadScene(faseID);
    }
    public void Sair()
    {
        Application.Quit();
    }
}
