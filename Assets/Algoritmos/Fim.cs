using UnityEngine;

public class Fim : MonoBehaviour
{
    private Animator Animator;
    private bool AtivarUmaVez;
    private void Start()
    {
        AtivarUmaVez = true;
        Animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && AtivarUmaVez)
        {
            Animator.SetTrigger("Ativar");
            AtivarUmaVez = false;
        }
    }
}
