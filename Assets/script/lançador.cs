using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lançador : MonoBehaviour
{
    public GameObject prefabToSpawn; // Prefab a ser instanciado
    public float spawnInterval = 1f; // Intervalo de tempo entre as instâncias
    public int maxInstances = 10; // Número máximo de instâncias a serem criadas

    private float timer;
    private int instanceCount;

    public float minX = -10f; // Valor mínimo para a posição X
    public float maxX = 10f; // Valor máximo para a posição X
    public float minY = -5f; // Valor mínimo para a posição Y
    public float maxY = 5f; // Valor máximo para a posição Y

    

    void Start()
    {
        timer = spawnInterval;
        instanceCount = 0;
    }

    void Update()
    {
        if (instanceCount >= maxInstances)
        {
            // Verifica se já atingiu o número máximo de instâncias
            
            return;
        }        

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnPrefab();
            timer = spawnInterval;
        }
    }

    void SpawnPrefab()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 randomPosition = new Vector3(transform.position.x + randomX, transform.position.y + randomY, 0f);

        GameObject newObject = Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        // Instancia o prefab na posição e rotação do objeto que possui esse script

        instanceCount++;
    }

    
}
