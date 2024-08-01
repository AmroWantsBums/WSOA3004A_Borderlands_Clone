using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemyHealth : MonoBehaviour
{
    public float healthPoints;
    private float beginningHealth;
    public bool enemyVulnerable = false;
    public GameObject criticalHitTxt;
    public GameObject resistanceHitTxt;
    public GameObject Canvas;
    private Slider healthBar;
    private GameObject Enemy;
    public SpawnLoot.EnemyType.enemies enemy;
    [SerializeField]
    private SpawnLoot spawnLootScript;

    void Awake()
    {
        spawnLootScript = GameObject.Find("SpawnLoot").GetComponent<SpawnLoot>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Enemy = gameObject;
        Canvas = GameObject.Find("Canvas");
        criticalHitTxt = Resources.Load<GameObject>("Prefabs/CriticalHitTxt");
        resistanceHitTxt = Resources.Load<GameObject>("Prefabs/ResistanceHitTxt");
        beginningHealth = healthPoints;
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

        UpdateSlider();

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
            Vector2 SpawnPosition = new Vector2(transform.position.x, transform.position.y + 0.8f);
            Instantiate(criticalHitTxt, SpawnPosition, Quaternion.identity, Canvas.transform);
        }
        else
        {
            healthPoints -= damageTaken;
        }
    }

    public void ShowResistanceTxt()
    {
        Vector2 SpawnPosition = new Vector2(transform.position.x, transform.position.y + 0.8f);
        Instantiate(resistanceHitTxt, SpawnPosition, Quaternion.identity, Canvas.transform);
    }

    void Die()
    {
        spawnLootScript.DetermineEnemy(gameObject);
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
        float newHealthPoints = healthPoints / beginningHealth;
        healthBar.value = newHealthPoints;
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(Enemy.transform.position + Vector3.up * 1.001f); 
        healthBar.transform.position = screenPosition;
    }
}
