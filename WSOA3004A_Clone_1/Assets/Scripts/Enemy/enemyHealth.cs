using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float healthPoints = 200f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints < 0)
        {
            Die();
        }
    }

    public void takeDamage(float damageTaken)
    {
        healthPoints = healthPoints - damageTaken;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
