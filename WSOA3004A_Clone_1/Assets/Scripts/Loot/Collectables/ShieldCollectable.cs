using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollectable : MonoBehaviour
{
    [SerializeField]
    private int ShieldValue = 100;
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
            PlHScript.playerShieldPoints = ShieldValue;

            Destroy(gameObject);
        }
    }
}
