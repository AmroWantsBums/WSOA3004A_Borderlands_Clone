using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollectable : MonoBehaviour
{

    [SerializeField]
    private int RestoreAmmo = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            weaponController WCScript = collision.gameObject.GetComponent<weaponController>();
            WCScript.Ammo = WCScript.Ammo + RestoreAmmo;
        }
    }
}
