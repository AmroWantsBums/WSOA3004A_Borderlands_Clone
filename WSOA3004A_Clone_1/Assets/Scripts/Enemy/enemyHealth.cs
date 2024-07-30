using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyHealth : MonoBehaviour
{
    public float healthPoints = 200f;
    public bool enemyVulnerable = false;
    public TextMeshProUGUI criticalHitTxt;
    public GameObject Canvas;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0)
        {
            Die();
        }
    }

    public void takeDamage(float damageTaken)
    {
        if (enemyVulnerable)
        {
            healthPoints = healthPoints - (damageTaken * 2f);
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
    }

    IEnumerator removeVulnerability()
    {
        yield return new WaitForSeconds(8f);
        enemyVulnerable = false;
    }
}
