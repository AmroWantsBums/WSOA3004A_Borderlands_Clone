using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponPickup : MonoBehaviour
{
    public GameObject pickupWeaponText;
    public GameObject Canvas;
    private GameObject Message;
    public weaponController weaponController;
    private bool canPickup = false;
    public GameObject pickedUpWeapon;
    // Start is called before the first frame update
    void Start()
    {
        Canvas = GameObject.Find("Canvas");
        weaponController = GameObject.Find("Gun").GetComponent<weaponController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickup)
        {
            if (Input.GetKeyDown("f"))
            {
                weaponController.pickupWeapon(pickedUpWeapon, 1);
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.layer == 14 && Message == null)
        {
            Vector2 spawnPosition = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y + 0.5f);
            Message = Instantiate(pickupWeaponText, spawnPosition, Quaternion.identity, Canvas.transform);
            canPickup = true;
            pickedUpWeapon = col.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == 14)
        {
            Destroy(Message);
            canPickup = false;
            pickedUpWeapon = null;
        }
    }
}
