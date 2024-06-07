using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject enemyContainer;

    [SerializeField]
    private GameObject[] powerUpPrefab;

    [SerializeField]
    private GameObject powerUpContainer;


    private bool stopSpawning = false;
    
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator SpawnEnemyRoutine()
    {
        while (stopSpawning == false)
        {
            float randomX = Random.Range(-9.5f, 9.5f);
            Vector3 position = new Vector3(randomX, 8f, 0);

            GameObject newEnemy = Instantiate(enemyPrefab,position, Quaternion.identity);
            newEnemy.transform.parent = enemyContainer.transform;
            yield return new WaitForSeconds(3);
        }
        
    }

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(10f);
        while (stopSpawning == false)
        {
            float randomX = Random.Range(-9.5f, 9.5f);
            Vector3 position = new Vector3(randomX, 8f, 0);

            GameObject newPowerUp = Instantiate(powerUpPrefab[Random.Range(0,3)], position, Quaternion.identity);
            newPowerUp.transform.parent = powerUpContainer.transform;
            yield return new WaitForSeconds(15f);
        }

    }
    public void OnPlayerDead()
    {
        stopSpawning = true;
    }
}
