using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
   
    public EnemyType regularEnemy;
    public EnemyType badAssEnemy;

    [Header("DropStats")]
    [SerializeField]
    private float dropOdd_GunsAndGear, dropOdd_Skin, dropOdd_Money, dropOdd_EridiumStick, dropOdd_Eriumbar, dropOdd_HealthRan, dropOdd_HealthAlways, dropOdd_HealthEmergency, dropOdd_AmmoRan, dropOdd_AmmoEmergency, dropOdd_AmmoAlways;

    [SerializeField]

    [System.Serializable]
    public struct EnemyType
    {
        //[SerializeField]
        //private ItemPools itemPool;
        public List<ItemPools> itemPools;

        public enemies selectEnemyType_SL;

        public enum enemies
        {
            Chumps,
            Badass,
            SuperBadass,
            Chubby,
            RaidBosses,
            NamedBosses
        }

        [System.Serializable]
       public struct ItemPools
        {
            public float dropRate;
            public AvailablePools selectPool;

            public enum AvailablePools
            {
                GunsAndGear,
                Skin,
                Money,
                EridiumStick,
                EridiumBar,
                HealthRan,
                HealthAlways,
                HealthEmergency,
                AmmoRan,
                AmmoEmergency,
                AmmoAlways,

            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < regularEnemy.itemPools.Count; i++)
        {
            EnemyType.ItemPools modifyPool = regularEnemy.itemPools[i];

            switch (modifyPool.selectPool)
            {
                case EnemyType.ItemPools.AvailablePools.GunsAndGear:
                    modifyPool.dropRate = dropOdd_GunsAndGear;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.Skin:
                    modifyPool.dropRate = dropOdd_Skin;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.Money:
                    modifyPool.dropRate = dropOdd_Money;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.EridiumStick:
                    modifyPool.dropRate = dropOdd_EridiumStick;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.EridiumBar:
                    modifyPool.dropRate = dropOdd_Eriumbar;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.HealthRan:
                    modifyPool.dropRate = dropOdd_HealthRan;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.HealthAlways:
                    modifyPool.dropRate = dropOdd_HealthAlways;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.HealthEmergency:
                    modifyPool.dropRate = dropOdd_HealthEmergency;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.AmmoRan:
                    modifyPool.dropRate = dropOdd_AmmoRan;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.AmmoEmergency:
                    modifyPool.dropRate = dropOdd_AmmoEmergency;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.AmmoAlways:
                    modifyPool.dropRate = dropOdd_AmmoAlways;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
            }

        }

        for (int i = 0; i < badAssEnemy.itemPools.Count; i++)
        {
            EnemyType.ItemPools modifyPool = regularEnemy.itemPools[i];

            switch (modifyPool.selectPool)
            {
                case EnemyType.ItemPools.AvailablePools.GunsAndGear:
                    modifyPool.dropRate = dropOdd_GunsAndGear * 1.5f;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.Skin:
                    modifyPool.dropRate = dropOdd_Skin * 1.5f;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.Money:
                    modifyPool.dropRate = dropOdd_Money * 1.5f;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.EridiumStick:
                    modifyPool.dropRate = dropOdd_EridiumStick * 1.5f;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.EridiumBar:
                    modifyPool.dropRate = dropOdd_Eriumbar * 1.5f;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.HealthRan:
                    modifyPool.dropRate = dropOdd_HealthRan;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.HealthAlways:
                    modifyPool.dropRate = dropOdd_HealthAlways * 1.5f;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.HealthEmergency:
                    modifyPool.dropRate = dropOdd_HealthEmergency * 1.5f;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.AmmoRan:
                    modifyPool.dropRate = dropOdd_AmmoRan;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.AmmoEmergency:
                    modifyPool.dropRate = dropOdd_AmmoEmergency * 1.5f;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.AmmoAlways:
                    modifyPool.dropRate = dropOdd_AmmoAlways * 1.5f;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
            }

        }
    }
      
    
    // Update is called once per frame
        void Update()
    {
        
    }
    
}