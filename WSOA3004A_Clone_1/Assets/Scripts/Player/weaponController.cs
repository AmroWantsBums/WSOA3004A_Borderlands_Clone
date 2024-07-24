using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject Weapon;
    public GameObject Bullet;
    public Vector2 shootDirection;
    public float bulletSpeed;
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
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    void Fire()
    {
        GameObject spawnedBullet = Instantiate(Bullet, Weapon.transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = spawnedBullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(shootDirection * bulletSpeed, ForceMode2D.Impulse);
    }
}
