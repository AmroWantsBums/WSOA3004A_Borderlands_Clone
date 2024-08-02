using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollectable : MonoBehaviour
{

    [SerializeField]
    private int RestoreAmmo = 20;
    [SerializeField]
    [TextArea]
    private string Description;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CurrencyController currencyController = collision.GetComponent<CurrencyController>();
            currencyController.DisplayCollectableInfo(Description);
            weaponController WCScript = collision.gameObject.GetComponent<weaponController>();
            WCScript.Ammo = WCScript.Ammo + RestoreAmmo;
            Destroy(gameObject);
        }
    }
}
