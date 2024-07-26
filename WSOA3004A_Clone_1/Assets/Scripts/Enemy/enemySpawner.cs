using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    //Incendiary, Corrosive, Explosive
    public GameObject[] enemyTypes;
    public Transform spawnPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnEnemy()
    {
        int randomNumber = Random.Range(1, 3);
        Instantiate(enemyTypes[randomNumber], spawnPosition.position, Quaternion.identity);
    }
}
