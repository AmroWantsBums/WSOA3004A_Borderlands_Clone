using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private int MoneyWorth = 5;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CurrencyController CCScript = collision.GetComponent<CurrencyController>();
            CCScript.GainCurrency(MoneyWorth);

            Destroy(gameObject);
        }
    }
}
