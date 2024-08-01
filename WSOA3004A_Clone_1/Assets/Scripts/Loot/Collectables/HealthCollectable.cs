using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    [SerializeField]
    private float healPercantage = 0.25f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealthController PlHScript = collision.GetComponent<playerHealthController>();
            PlHScript.playerHealthPoints = PlHScript.playerHealthPoints + (PlHScript.playerHealthPoints * healPercantage);

            Destroy(gameObject);
        }
    }
}
