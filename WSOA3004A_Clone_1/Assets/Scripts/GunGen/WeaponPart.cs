using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPart : MonoBehaviour
{

    public enum WeaponStatType {
        Damage,
        Accuracy,
        AmmoPerClip,
        ReloadSpeed,
        FireRate,
        Slag, // 1
        Incediary, // 2
        Explosive // 3
    }

    public enum RarityLevel 
    {


        common,
        Uncommon,
        Rare,
        Epic,
        Legendary


    }


    [System.Serializable]
    public class WeaponStatPair
    {
        public WeaponStatType stat;

        public float minStatValue;
        public float maxStatValue;

        
        
    }

    public List<WeaponStatPair> rawStats;
    public Dictionary<WeaponStatType, float> stats = new Dictionary<WeaponStatType, float>();

    public RarityLevel rarityLevel;

    public SpawnLoot.EnemyType.WeaponTypePool.WeaponType selectWPN;
    public SpawnLoot.EnemyType.ManufactoresPool.AllManufacterus selectMF;


    private void Awake()
    {

        foreach (WeaponStatPair statPair in rawStats)
        {
            float chosenValue = Random.Range(statPair.minStatValue, statPair.maxStatValue);
             
            stats.Add(statPair.stat, chosenValue);
            
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }
}
