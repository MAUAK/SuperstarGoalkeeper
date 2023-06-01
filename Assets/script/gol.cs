using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gol : MonoBehaviour
{
    public GameObject telaGol;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("gol");
            ActivateObjectForDuration(5f);
            Destroy(collision.gameObject);
        }
    }

    void ActivateObjectForDuration(float duration)
    {
        telaGol.SetActive(true); // Ativa o GameObject

        // Aguarda a duração especificada antes de desativar o GameObject
        Invoke("DeactivateObject", duration);
    }

    void DeactivateObject()
    {
        telaGol.SetActive(false); // Desativa o GameObject
    }
}
