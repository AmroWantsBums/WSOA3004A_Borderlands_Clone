using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    //Incendiary, Slag, Explosive
    public GameObject[] chumpEnemies; //14
    public GameObject[] chubbyEnemies;//9
    public GameObject[] badassEnemies;//3
   
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
            int randomEnemyTypeNumber = Random.Range(1, 26);
            if (randomEnemyTypeNumber < 15)                             //1 to 14 
            {
                int randomNumber = Random.Range(0, 3);
                int spawnPosition = Random.Range(0, 4);
                Instantiate(chumpEnemies[randomNumber], spawnPositions[spawnPosition].position, Quaternion.identity);
            }
            else if (randomEnemyTypeNumber > 14 && randomEnemyTypeNumber < 25) //15 to 24
            {
                int randomNumber = Random.Range(0, 3);
                int spawnPosition = Random.Range(0, 4);
                Instantiate(chubbyEnemies[randomNumber], spawnPositions[spawnPosition].position, Quaternion.identity);
            }
            else if (randomEnemyTypeNumber > 24 && randomEnemyTypeNumber < 27)  //25 to 31
            {
                int randomNumber = Random.Range(0, 3);
                int spawnPosition = Random.Range(0, 4);
                Instantiate(badassEnemies[randomNumber], spawnPositions[spawnPosition].position, Quaternion.identity);
            }
        }
        StartCoroutine(spawnCooldown());
    }

    IEnumerator spawnCooldown()
    {
        yield return new WaitForSeconds(6f);
        spawnEnemy(numberOfEnemies);
    }
}
