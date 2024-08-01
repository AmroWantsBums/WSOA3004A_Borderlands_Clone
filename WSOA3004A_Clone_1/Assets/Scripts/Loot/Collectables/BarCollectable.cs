using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarCollectable : MonoBehaviour
{
    [SerializeField]
    private int BarValue = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CurrencyController CCScript = collision.GetComponent<CurrencyController>();
            CCScript.GainCurrency(BarValue);

            Destroy(gameObject);
        }
    }
}
