using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class weaponController : MonoBehaviour
{
    private GameObject Player;
    public GameObject Weapon;
    public GameObject[] Bullets; // slot 0 is explosive, 1 is incendiary and 2 is slag
    public Vector2 shootDirection;
    public float bulletSpeed;
    private bool canFire = true;
    public int Ammo;
    private TextMeshProUGUI ammoText;
    public int weaponDamage;
    public int activeWeaponSlot = 1;
    public GameObject[] WeaponSlots;
    
    // Start is called before the first frame update
    void Start()
    {
        weaponDamage = 30;
        Player = GameObject.Find("Player");
        Ammo = 20;
        Weapon = GameObject.Find("Gun");
        //Cursor.visible = false;
        ammoText = GameObject.Find("AmmoTxt").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeWeaponSlot = 1;
            Transform[] children = WeaponSlots[0].GetComponentsInChildren<Transform>();
            if (children.Length > 0)
            {
                Transform[] playerChildren = Player.GetComponentsInChildren<Transform>();
                for (int j = 0; j < playerChildren.Length; j++)
                {
                    if (playerChildren[j].gameObject.name != "Player" && playerChildren[j].gameObject.name != "TriggerCollider")
                    {
                        Destroy(playerChildren[j].gameObject);
                    }
                }

                for (int i = 0; i < children.Length; i++)
                {
                    if (children[i].gameObject.name != "WeaponOneImage")
                    {
                        Weapon = Instantiate(children[i].gameObject, Player.transform.position, Quaternion.identity, Player.transform);
                        Weapon.transform.localScale = new Vector2(0.19f, 0.62f);
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeWeaponSlot = 2;
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Weapon != null)
        {
            Vector2 direction = mousePos - (Vector2)Weapon.transform.position;
            Weapon.transform.up = direction;
        }
        shootDirection = (mousePos - (Vector2)Weapon.transform.position).normalized;
        if (Input.GetMouseButton(0) && canFire)
        {
            if (Weapon.CompareTag("Explosive_Weapon"))
            {
                //insert the type of weapon here and put in the firerate, bullet type and number of bullets parameters
                // eg. if (activeWeapon.name == "pistol") {
                StartCoroutine(Fire(0.4f, 1, Bullets[0], 0.0f));
                canFire = false;
                // }
            }
            else if (Weapon.CompareTag("Incendiary_Weapon"))
            {
                //insert the type of weapon here and put in the firerate, bullet type and number of bullets parameters
                // eg. if (activeWeapon.name == "pistol") {
                StartCoroutine(Fire(0.4f, 1, Bullets[1], 0.2f));
                canFire = false;
                // }
            }
            else if (Weapon.CompareTag("Slag_Weapon"))
            {
                //insert the type of weapon here and put in the firerate, bullet type and number of bullets parameters
                // eg. if (activeWeapon.name == "pistol") {
                StartCoroutine(Fire(0.4f, 1, Bullets[2], 0.2f));
                canFire = false;
                // }
            }
        }
        ammoText.text = $"{Ammo}";
    }

    IEnumerator Fire(float fireRate, int numberOfBullets, GameObject bulletType, float accuracy)
    {
        if (numberOfBullets <= Ammo)
        {
            for (int i = 0; i < numberOfBullets; i++)
            {
                GameObject spawnedBullet = Instantiate(bulletType, Weapon.transform.position, Quaternion.identity);
                Rigidbody2D bulletRb = spawnedBullet.GetComponent<Rigidbody2D>();
                Vector2 bulletOffset = new Vector2(Random.Range(-accuracy, accuracy), Random.Range(-accuracy, accuracy));
                shootDirection = (shootDirection + bulletOffset).normalized;
                bulletRb.AddForce(shootDirection * bulletSpeed, ForceMode2D.Impulse);
                Ammo = Ammo - numberOfBullets;
            }
            yield return new WaitForSeconds(fireRate);
            canFire = true;
        }
        else
        {
            StartCoroutine(reloadWeapon(2f));
        }        
    }

    IEnumerator reloadWeapon(float reloadSeconds)
    {
        yield return new WaitForSeconds(reloadSeconds);
        Ammo = 20;
        canFire = true;
    }

    public void pickupWeapon(GameObject pickedUpWeapon, int weaponSlot)
    {
        Transform[] children = WeaponSlots[(weaponSlot - 1)].GetComponentsInChildren<Transform>();
        if (children.Length > 0)
        {
            for (int i = 0; i < children.Length; i++)
            {
                if (children[i].gameObject.name != "WeaponOneImage" && children[i].gameObject.name != "WeaponTwoImage")
                {
                    Destroy(children[i].gameObject);
                }
            }
        }
        GameObject weaponObject = pickedUpWeapon;
        GameObject WeaponIcon = Instantiate(weaponObject, WeaponSlots[(weaponSlot - 1)].transform.position, Quaternion.identity, WeaponSlots[(weaponSlot - 1)].transform);
        WeaponIcon.transform.localScale = new Vector2(90.0f, 90.0f);
    }
}
