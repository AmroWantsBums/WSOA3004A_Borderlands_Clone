using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoCollectable : MonoBehaviour
{

    [SerializeField]
    private float RestoreAmmo = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            weaponController WCScript = collision.transform.GetChild(0).gameObject.GetComponent<weaponController>();
           // WCScript.Ammo = WCScript.Ammo + (WCScript.Ammo * RestoreAmmo);
        }
    }
}
