using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollectable : MonoBehaviour
{
    [SerializeField]
    private int StickValue = 1;
    [SerializeField]
    [TextArea]
    private string Description;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CurrencyController currencyController = collision.GetComponent<CurrencyController>();
            currencyController.DisplayCollectableInfo(Description);
            CurrencyController CCScript = collision.GetComponent<CurrencyController>();
            CCScript.GainedEridium(StickValue);

            Destroy(gameObject);
        }
    }
}
