using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRarityOnSpawn : MonoBehaviour
{
    public void SetColour(SpawnLoot.EnemyType.RarityPool.AvailableRarities rarities)
    {

        switch (rarities)
        {
            case SpawnLoot.EnemyType.RarityPool.AvailableRarities.Common:
                gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
                
                break;
            case SpawnLoot.EnemyType.RarityPool.AvailableRarities.Uncommon:
                gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case SpawnLoot.EnemyType.RarityPool.AvailableRarities.Rare:
                gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case SpawnLoot.EnemyType.RarityPool.AvailableRarities.VeryRare:
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case SpawnLoot.EnemyType.RarityPool.AvailableRarities.Legendary:
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
        }
    }
}