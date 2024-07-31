using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyHealth : MonoBehaviour
{
    public float healthPoints = 200f;
    public bool enemyVulnerable = false;
    public GameObject criticalHitTxt;
    public GameObject Canvas;
    private Slider healthBar;
    private GameObject Enemy;
    
    // Start is called before the first frame update
    void Start()
    {
        Enemy = gameObject;
        Canvas = GameObject.Find("Canvas");
        criticalHitTxt = Resources.Load<GameObject>("Prefabs/CriticalHitTxt");
    }

    // Update is called once per frame
    void Update()
    {
        Slider[] children = GetComponentsInChildren<Slider>();
        
        for (int i = 0; i < children.Length; i++)
        {
            if (children[i].name == "enemyHealthPoints")
            {
                healthBar = children[i];
            }
        }

        if (healthPoints <= 0)
        {
            Die();
        }
        UpdateSlider();
    }

    public void takeDamage(float damageTaken)
    {
        if (enemyVulnerable)
        {
            healthPoints = healthPoints - (damageTaken * 2f);
            Vector2 SpawnPosition = new Vector2(transform.position.x, transform.position.y + 20);
            Instantiate(criticalHitTxt, transform.position, Quaternion.identity, Canvas.transform);
        }
        else
        {
            healthPoints = healthPoints - damageTaken;
        }
    }

    void Die()
    {
        Destroy(gameObject);
        Destroy(healthBar);
    }

    IEnumerator removeVulnerability()
    {
        yield return new WaitForSeconds(8f);
        enemyVulnerable = false;
    }

    void UpdateSlider()
    {
        float newHealthPoints = healthPoints / 200;
        healthBar.value = newHealthPoints;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(Enemy.transform.position + Vector3.up * 1.05f); 
        healthBar.transform.position = screenPosition;
    }
}
