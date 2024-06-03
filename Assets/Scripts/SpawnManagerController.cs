using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerController : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private GameObject enemyContainer;

    private bool stopSpawning = false;
    
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    IEnumerator SpawnRoutine()
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
    public void OnPlayerDead()
    {
        stopSpawning = true;
    }
}
