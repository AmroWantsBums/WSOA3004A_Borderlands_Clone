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
    public float fireRate;
    public GameObject bulletType;
    public float accuracy;
    public int ammoPerClip;
    public float reloadSpeed;
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
            if (children.Length > 1)
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
                    if (children[i].gameObject.name != "WeaponOneImage" && children[i].gameObject.layer == 14)
                    {
                        Vector3 spawnPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, -1f);
                        Weapon = Instantiate(children[i].gameObject, spawnPosition, Quaternion.identity, Player.transform);
                        Weapon.transform.localScale = new Vector2(1f, 0.2f);
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activeWeaponSlot = 2;
            Transform[] children = WeaponSlots[1].GetComponentsInChildren<Transform>();
            if (children.Length > 1)
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
                    if (children[i].gameObject.name != "WeaponTwoImage" && children[i].gameObject.layer == 14)
                    {
                        Vector3 spawnPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, -1f);
                        Weapon = Instantiate(children[i].gameObject, spawnPosition, Quaternion.identity, Player.transform);
                        Weapon.transform.localScale = new Vector2(1f, 0.2f);
                    }
                }
            }
        }

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Weapon != null)
        {
            Vector2 direction = mousePos - (Vector2)Weapon.transform.position;
            Weapon.transform.right = direction;
            shootDirection = (mousePos - (Vector2)Weapon.transform.position).normalized;
        }
        if (Input.GetMouseButton(0) && canFire)
        {
            var weaponPart = Weapon.GetComponent<WeaponPart>();

            if (weaponPart != null)
            {
                if (Weapon.CompareTag("Explosive_Weapon"))
                {
                    bulletType = Bullets[0];
                }
                else if (Weapon.CompareTag("Incendiary_Weapon"))
                {
                    bulletType = Bullets[1];
                }
                else if (Weapon.CompareTag("Slag_Weapon"))
                {
                    bulletType = Bullets[2];
                }

                // Retrieve weapon stats
                weaponDamage = Mathf.RoundToInt(weaponPart.stats.GetValueOrDefault(WeaponPart.WeaponStatType.Damage, 30)); // Default value
                fireRate = weaponPart.stats.GetValueOrDefault(WeaponPart.WeaponStatType.FireRate, 0.4f);
                ammoPerClip = Mathf.RoundToInt(weaponPart.stats.GetValueOrDefault(WeaponPart.WeaponStatType.AmmoPerClip, 1));
                accuracy = weaponPart.stats.GetValueOrDefault(WeaponPart.WeaponStatType.Accuracy, 0.2f);
                reloadSpeed = weaponPart.stats.GetValueOrDefault(WeaponPart.WeaponStatType.ReloadSpeed, 0.2f);
                // Call Fire method with updated parameters
                StartCoroutine(Fire(fireRate, 1, bulletType, accuracy, ammoPerClip, reloadSpeed));
                canFire = false;
            }
        }

        ammoText.text = $"{Ammo}";
    }

    IEnumerator Fire(float fireRate, int numberOfBullets, GameObject bulletType, float accuracy, int AmmoPerClip, float ReloadSpeed)
    {
        if (numberOfBullets <= Ammo)
        {
            for (int i = 0; i < numberOfBullets; i++)
            {
                var weaponBodyScript = Weapon.GetComponent<WeaponBody>();
                Vector2 spawnPoint = new Vector2(weaponBodyScript.barrelSocket.transform.position.x, weaponBodyScript.barrelSocket.transform.position.y);
                GameObject spawnedBullet = Instantiate(bulletType, spawnPoint, Quaternion.identity);
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
        Destroy(pickedUpWeapon);
        GameObject WeaponIcon = Instantiate(weaponObject, WeaponSlots[(weaponSlot - 1)].transform.position, Quaternion.identity, WeaponSlots[(weaponSlot - 1)].transform);
        WeaponIcon.transform.localScale = new Vector2(67.13f, 15.09f);

        Transform[] playerChildren = Player.GetComponentsInChildren<Transform>();
        for (int j = 0; j < playerChildren.Length; j++)
        {
            if (playerChildren[j].gameObject.name != "Player" && playerChildren[j].gameObject.name != "TriggerCollider")
            {
                Destroy(playerChildren[j].gameObject);
            }
        }

        Transform[] childrenP = WeaponSlots[(weaponSlot - 1)].GetComponentsInChildren<Transform>();
        for (int i = 0; i < childrenP.Length; i++)
        {
            if (childrenP[i].gameObject.name != "WeaponOneImage" && childrenP[i].gameObject.layer == 14)
            {
                Vector3 spawnPosition = new Vector3(Player.transform.position.x, Player.transform.position.y, -1f);
                Weapon = Instantiate(childrenP[i].gameObject, spawnPosition, Quaternion.identity, Player.transform);
                Weapon.transform.localScale = new Vector2(1f, 0.2f);
            }
            else
            {

            }
        }
    }

    void FetchWeaponStats(int Damage, int reloadSpeed, int Ammo, float fireRate, float Accuracy)
    {
        
    }
}
