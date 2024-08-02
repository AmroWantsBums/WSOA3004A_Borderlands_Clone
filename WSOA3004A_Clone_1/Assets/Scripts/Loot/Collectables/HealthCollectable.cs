using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
    [SerializeField]
    private float healPercantage = 0.25f;
    [SerializeField]
    [TextArea]
    private string Description;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
          CurrencyController currencyController = collision.GetComponent<CurrencyController>();
            currencyController.DisplayCollectableInfo(Description);

            playerHealthController PlHScript = collision.GetComponent<playerHealthController>();
            PlHScript.playerHealthPoints = PlHScript.playerHealthPoints + (PlHScript.playerHealthPoints * healPercantage);

            Destroy(gameObject);
        }
    }
}
