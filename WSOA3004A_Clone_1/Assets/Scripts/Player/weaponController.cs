using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject Weapon;
    public GameObject[] Bullets; // slot 0 is explosive, 1 is incendiary and 2 is slag
    public Vector2 shootDirection;
    public float bulletSpeed;
    private bool canFire = true;
    // Start is called before the first frame update
    void Start()
    {
        Weapon = GameObject.Find("Gun");
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Weapon.transform.up = mousePos;
        shootDirection = (mousePos - (Vector2)Weapon.transform.position).normalized;
        if (Input.GetMouseButton(0) && canFire)
        {
            if (Weapon.CompareTag("Explosive_Weapon"))
            {
                //insert the type of weapon here and put in the firerate and number of bullets parameters
                // eg. if (activeWeapon.name == "pistol") {
                StartCoroutine(Fire(0.4f, 1, Bullets[0]));
                canFire = false;
                // }
            }
            else if (Weapon.CompareTag("Incendiary_Weapon"))
            {
                //insert the type of weapon here and put in the firerate and number of bullets parameters
                // eg. if (activeWeapon.name == "pistol") {
                StartCoroutine(Fire(0.4f, 1, Bullets[1]));
                canFire = false;
                // }
            }
            else if (Weapon.CompareTag("Slag_Weapon"))
            {
                //insert the type of weapon here and put in the firerate and number of bullets parameters
                // eg. if (activeWeapon.name == "pistol") {
                StartCoroutine(Fire(0.4f, 1, Bullets[2]));
                canFire = false;
                // }
            }
        }
    }

    IEnumerator Fire(float fireRate, int numberOfBullets, GameObject bulletType)
    {
        for (int i = 0; i < numberOfBullets; i++)
        {
            GameObject spawnedBullet = Instantiate(bulletType, Weapon.transform.position, Quaternion.identity);
            Rigidbody2D bulletRb = spawnedBullet.GetComponent<Rigidbody2D>();
            Vector2 bulletOffset = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            shootDirection = (shootDirection + bulletOffset).normalized;
            bulletRb.AddForce(shootDirection * bulletSpeed, ForceMode2D.Impulse);
        }
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }
}
