using UnityEngine;

public class Area : MonoBehaviour
{
    public bool EstaEmContato;
    private void Start()
    {
        EstaEmContato = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EstaEmContato = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EstaEmContato = false;
        }
    }
}
