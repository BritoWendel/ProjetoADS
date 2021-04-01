using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool EstaAtivado;
    private Animator Animator;
    private void Start()
    {
        EstaAtivado = false;
        Animator = GetComponent<Animator>();
    }
    private void Animar()
    {
        Animator.SetTrigger("Ativar");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EstaAtivado = true;
            Animar();
        }
    }
}
