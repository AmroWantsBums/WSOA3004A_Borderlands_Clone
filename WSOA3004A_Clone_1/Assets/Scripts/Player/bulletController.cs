using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    public GameObject sparkParticleEffect;
    public weaponController weaponController;
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        weaponController = Player.GetComponent<weaponController>();
        int playerLayer = LayerMask.NameToLayer("Player");
        int bulletLayer = LayerMask.NameToLayer("Bullet");

        Physics2D.IgnoreLayerCollision(playerLayer, bulletLayer, true);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (gameObject.CompareTag("Explosive_Bullet"))
        {
            if (col.gameObject.CompareTag("Explosive_Enemy"))
            {   
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage((weaponController.weaponDamage * 0.3f));
                enemyHealth.ShowResistanceTxt();
                Instantiate(sparkParticleEffect, gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else if (col.gameObject.CompareTag("Incendiary_Enemy") || col.gameObject.CompareTag("Slag_Enemy"))
            {
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage(weaponController.weaponDamage);
                Destroy(gameObject);
                Instantiate(sparkParticleEffect, gameObject.transform.position, Quaternion.identity);
            }
            else
            {

            }
        }

        if (gameObject.CompareTag("Slag_Bullet"))
        {
            if (col.gameObject.CompareTag("Slag_Enemy"))
            {
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage((weaponController.weaponDamage * 0.3f));
                enemyHealth.ShowResistanceTxt();
                Destroy(gameObject);
                Instantiate(sparkParticleEffect, gameObject.transform.position, Quaternion.identity);
                enemyHealth.enemyVulnerable = true;
            }
            else if (col.gameObject.CompareTag("Incendiary_Enemy") || col.gameObject.CompareTag("Explosive_Enemy"))
            {
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage(weaponController.weaponDamage);
                Destroy(gameObject);
                Instantiate(sparkParticleEffect, gameObject.transform.position, Quaternion.identity);
                enemyHealth.enemyVulnerable = true;
            }
            else
            {

            }
        }

        if (gameObject.CompareTag("Incendiary_Bullet"))
        {
            if (col.gameObject.CompareTag("Incendiary_Enemy"))
            {
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage((weaponController.weaponDamage * 0.3f));
                enemyHealth.ShowResistanceTxt();
                Destroy(gameObject);
                Instantiate(sparkParticleEffect, gameObject.transform.position, Quaternion.identity);
            }
            else if (col.gameObject.CompareTag("Slag_Enemy") || col.gameObject.CompareTag("Explosive_Enemy"))
            {
                var enemyHealth = col.gameObject.GetComponent<enemyHealth>();
                enemyHealth.takeDamage(weaponController.weaponDamage);
                Destroy(gameObject);
                Instantiate(sparkParticleEffect, gameObject.transform.position, Quaternion.identity);
            }
            else
            {

            }
        }
    }
}
