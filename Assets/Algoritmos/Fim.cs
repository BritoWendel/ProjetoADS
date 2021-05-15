using UnityEngine;

public class Fim : MonoBehaviour
{
    private Animator Animator;
    private bool _ativarUmaVez;
    public bool Ativado
    {
        get { return !_ativarUmaVez; }
        private set { } 
    }
    private void Start()
    {
        _ativarUmaVez = true;
        Animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && _ativarUmaVez)
        {
            Animator.SetTrigger("Ativar");
            _ativarUmaVez = false;
        }
    }
}
