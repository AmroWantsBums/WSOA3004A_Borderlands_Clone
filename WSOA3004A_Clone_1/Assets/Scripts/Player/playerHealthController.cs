using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerHealthController : MonoBehaviour
{
    public float playerHealthPoints = 500;
    public float playerShieldPoints = 100;
    public Slider healthBar;
    public Slider shieldBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateHealthBar();
        if (playerHealthPoints <= 0)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 6)
        {
            takeDamage(10f);
        }
        if (col.gameObject.layer == 9)
        {
            takeDamage(20f);
        }
        if (col.gameObject.layer == 10)
        {
            takeDamage(30f);
        }
        if (col.gameObject.layer == 11)
        {
            takeDamage(40f);
        }
        if (col.gameObject.layer == 12)
        {
            takeDamage(50f);
        }
        if (col.gameObject.layer == 13)
        {
            takeDamage(60f);
        }
    }

    public void takeDamage(float damageTaken)
    {
        if (playerShieldPoints > 0)
        {
            if (playerShieldPoints < 19)
            {
                playerShieldPoints = 0;
            }
            else
            {
                playerShieldPoints -= damageTaken;
            }
        }
        else
        {
            playerHealthPoints -= damageTaken;
        }
    }

    void updateHealthBar()
    {
        if (playerShieldPoints <= 0)
        {
            healthBar.value = playerHealthPoints / 500;
            shieldBar.value = 0;
        }
        else
        {
            shieldBar.value = playerShieldPoints / 100;
        }
    }
}
