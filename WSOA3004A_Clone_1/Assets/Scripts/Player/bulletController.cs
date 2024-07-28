using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.CompareTag("Explosive_Bullet"))
        {
            if (col.gameObject.CompareTag("Explosive_Enemy"))
            {
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage(100);
                Destroy(gameObject);
            }
            else
            {
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage(30);
                Destroy(gameObject);
            }
        }

        if (gameObject.CompareTag("Slag_Bullet"))
        {
            if (col.gameObject.CompareTag("Slag_Enemy"))
            {
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage(100);
                Destroy(gameObject);
            }
            else
            {
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage(30);
                Destroy(gameObject);
            }
        }

        if (gameObject.CompareTag("Incendiary_Bullet"))
        {
            if (col.gameObject.CompareTag("Incendiary_Enemy"))
            {
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage(100);
                Destroy(gameObject);
            }
            else
            {
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage(30);
                Destroy(gameObject);
            }
        }
    }
}
