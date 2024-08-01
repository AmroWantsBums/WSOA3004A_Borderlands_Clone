using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicPrefab : MonoBehaviour
{

    [SerializeField]
    private float AdjustValueCommon, AdjustValueUncommon;
    [SerializeField]
    private SpawnLoot spawnLootScript;

    private void Start()
    {
        spawnLootScript = GameObject.FindGameObjectWithTag("LootManager").GetComponent<SpawnLoot>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //for (int i = 0; i < spawnLootScript.regularEnemy.rarityPools.Count; i++)
            // {
            //  if( spawnLootScript.regularEnemy.rarityPools[i].selectRarities == SpawnLoot.EnemyType.RarityPool.AvailableRarities.Common &&
            //       spawnLootScript.regularEnemy.rarityPools[i].Weight > 0 )
            //     {
            //         SpawnLoot.EnemyType.RarityPool modifyPool = spawnLootScript.regularEnemy.rarityPools[i];

            //         modifyPool.Weight =  spawnLootScript.regularEnemy.rarityPools[i].Weight - AdjustValueCommon;
            //         spawnLootScript.regularEnemy.rarityPools[i] = modifyPool;

            //     }

            //  else if ()
            //     {
            //         SpawnLoot.EnemyType.RarityPool modifyPoolBA = spawnLootScript.badAssEnemy.rarityPools[i];
            //         modifyPoolBA.Weight = spawnLootScript.badAssEnemy.rarityPools[i].Weight - AdjustValueUncommon;
            //         spawnLootScript.badAssEnemy.rarityPools[i] = modifyPoolBA;
            //     }
            // }

            Destroy(gameObject);
        }
    }
}
