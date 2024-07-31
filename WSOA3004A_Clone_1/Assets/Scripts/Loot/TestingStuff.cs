using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestingStuff : MonoBehaviour, IPointerClickHandler
{

    public SpawnLoot.EnemyType.enemies enemy;
    //public List<GameObject> DropLoot;
    [SerializeField]
    private SpawnLoot spawnLootScript;
    
    
    
    public void OnPointerClick(PointerEventData eventData)
    {
        spawnLootScript.DetermineEnemy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
