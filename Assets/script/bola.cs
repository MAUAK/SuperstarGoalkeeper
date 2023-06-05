using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bola : MonoBehaviour
{
    public Transform startPoint; // Ponto de partida da bola
    public Transform endPoint; // Ponto de destino da bola
    public float speed = 5f; // Velocidade da bola

    private bool isMoving = false;
    public GameObject good;

    public gol laa;

    void Start()
    {
        transform.position = startPoint.position; // Define a posição inicial da bola
        isMoving = true;
        StartCoroutine(MoveToDestination());
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray))
                {
                    laa.defesas++;
                    Destroy(gameObject); // Destroi o objeto
                    InstantiatePrefab();
                }
            }
        }
        if (Input.GetMouseButtonDown(0)) // Verifica se o botão esquerdo do mouse foi clicado
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            // Lança um raio a partir da posição do mouse na tela

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                laa.defesas++;
                // Verifica se o raio atingiu um objeto e se esse objeto é o próprio objeto do script
                Destroy(gameObject); // Destroi o objeto
                InstantiatePrefab();
            }
        }

    }

    IEnumerator MoveToDestination()
    {
        while (transform.position != endPoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }

    void InstantiatePrefab()
    {
        GameObject newObject = Instantiate(good, transform.position, transform.rotation);
        // Instancia o prefab na posição e rotação do objeto que possui esse script

        Destroy(newObject, 1f);
    }
}
