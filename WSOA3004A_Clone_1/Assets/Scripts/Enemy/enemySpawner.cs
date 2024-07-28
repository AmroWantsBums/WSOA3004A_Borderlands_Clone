using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    //Incendiary, Slag, Explosive
    public GameObject[] enemyTypes;
    public Transform[] spawnPositions;
    private int numberOfEnemies;
    // Start is called before the first frame update
    void Start()
    {
        numberOfEnemies = 1;
        spawnEnemy(numberOfEnemies);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemy(int numberOfEnemiesToSpawn)
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            int randomNumber = Random.Range(0, 3);
            int spawnPosition = Random.Range(0, 4);
            //Debug.Log("Enemy type " + randomNumber  + " at position " + spawnPosition);
            Instantiate(enemyTypes[randomNumber], spawnPositions[spawnPosition].position, Quaternion.identity);
        }
        StartCoroutine(spawnCooldown());
    }

    IEnumerator spawnCooldown()
    {
        yield return new WaitForSeconds(6f);
        spawnEnemy(numberOfEnemies);
    }
}
