using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class gol : MonoBehaviour
{
    public GameObject telaGol;
    public int gols = 0;

    public GameObject gameover;
    public GameObject gamewin;
    public int defesas = 0;

    public MonoBehaviour lanca;

    public TextMeshProUGUI pontosText;

    private void Start()
    {
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (gols == 1)
        {
            gameover.SetActive(true);
            Time.timeScale = 0f;
            //lanca.enabled = false;            
        }

        if (defesas == 10)
        {
            gamewin.SetActive(true);
        }
        pontosText.text = "Defesas: " + defesas.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gols++;
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

    public void reiniciarFase()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void sair()
    {
        Application.Quit();
    }

}
