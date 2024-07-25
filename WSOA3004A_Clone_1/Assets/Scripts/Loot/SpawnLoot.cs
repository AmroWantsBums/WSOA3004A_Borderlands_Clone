using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    [SerializeField]
    private EnemyType SwitchEnemy;
    [SerializeField]
    private bool SwitchTest = true;
    
   [Header("Enemy Possible Loot Drops")]
    public EnemyType regularEnemy, badAssEnemy;
    

    [Header("DropStats")]
    [SerializeField]
    private float dropOdd_GunsAndGear, dropOdd_Skin, dropOdd_Money, dropOdd_EridiumStick, dropOdd_Eriumbar, dropOdd_HealthRan, dropOdd_HealthAlways, dropOdd_HealthEmergency, dropOdd_AmmoRan, dropOdd_AmmoEmergency, dropOdd_AmmoAlways;

    [Header("Weights")]
    [SerializeField]
    private float Weight_Common, Weight_Uncommon, Adjust_Weight_Common, Adjust_Weight_Uncommon_1, Adjust_Weight_UnCommon_2;
  

    [SerializeField]
    [System.Serializable]
    public struct EnemyType
    {
        public enemies selectEnemyType_SL;
 
        public List<ItemPools> itemPools;
        public List<PoolGunsAndGear> poolGunsAdGear;


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
           
        [System.Serializable]
       public struct PoolGunsAndGear
        {
            public float Weight;
            public AvailableGunsAndGear selectGunsAndGear;

            public enum AvailableGunsAndGear
            {
                Weapons_All,
                Weapons_UncommonUp,
                Weapons_RareUp,
                Weapons_VeryRareUp,
                Weapons_Legendary,
                Shields,
                Relics
            }
        }    
       
       
        
    }

    


    // Start is called before the first frame update
    void Start()
    {

        SetRegularEnemyStats();
        SetBadassStats();
        
        
    }

   //Modifies BaseDrops for badAssEnemy
    private void SetBadassStats()
    {
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

        for (int i = 0; i < badAssEnemy.poolGunsAdGear.Count; i++)
        {
            EnemyType.PoolGunsAndGear modifyPool = badAssEnemy.poolGunsAdGear[i];

            switch (modifyPool.selectGunsAndGear)
            {
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_All:
                    modifyPool.Weight = Weight_Common;
                    badAssEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_UncommonUp:
                    modifyPool.Weight = Weight_Common * Adjust_Weight_Common;
                    badAssEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_RareUp:
                    modifyPool.Weight = Weight_Uncommon * Adjust_Weight_Uncommon_1;
                    badAssEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_VeryRareUp:
                    modifyPool.Weight = Weight_Uncommon * Adjust_Weight_UnCommon_2;
                    badAssEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_Legendary:
                    modifyPool.Weight = Weight_Uncommon;
                    badAssEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Shields:
                    modifyPool.Weight = Weight_Common * Adjust_Weight_Common;
                    badAssEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Relics:
                    modifyPool.Weight = Weight_Uncommon;
                    badAssEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
            }
        }
    }

    private void SetRegularEnemyStats()
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

        for (int i = 0; i < regularEnemy.poolGunsAdGear.Count; i++)
        {
            EnemyType.PoolGunsAndGear modifyPool = regularEnemy.poolGunsAdGear[i];

            switch (modifyPool.selectGunsAndGear)
            {
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_All:
                    modifyPool.Weight = Weight_Common;
                    regularEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_UncommonUp:
                    modifyPool.Weight = Weight_Common * Adjust_Weight_Common;
                    regularEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_RareUp:
                    modifyPool.Weight = Weight_Uncommon * Adjust_Weight_Uncommon_1;
                    regularEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_VeryRareUp:
                    modifyPool.Weight = Weight_Uncommon * Adjust_Weight_UnCommon_2;
                    regularEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_Legendary:
                    modifyPool.Weight = Weight_Uncommon;
                    regularEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Shields:
                    modifyPool.Weight = Weight_Common * Adjust_Weight_Common;
                    regularEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Relics:
                    modifyPool.Weight = Weight_Uncommon;
                    regularEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
            }
        }
    }
        

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            DetermineLootToSpawn(SwitchEnemy);
        }

        if (SwitchTest == true)
        {
            SwitchEnemy = regularEnemy;
        }
        else
        {
            SwitchEnemy = badAssEnemy;
        }
    }

    private void DetermineLootToSpawn(EnemyType typeKilled)
    {
        for (int i = 0; i  < typeKilled.itemPools.Count; i++)
        {
            float ranNum = UnityEngine.Random.Range(0, 100);

            EnemyType.ItemPools checkDrop = typeKilled.itemPools[i];
            
            if (ranNum <= checkDrop.dropRate)
            {
                switch (checkDrop.selectPool)
                {
                    case EnemyType.ItemPools.AvailablePools.GunsAndGear:
                        Debug.Log(checkDrop.selectPool);
                        DetermineGunsAndGear(typeKilled);
                        break;
                    case EnemyType.ItemPools.AvailablePools.Skin:
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.Money:
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.EridiumStick:
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.EridiumBar:
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.HealthRan:
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.HealthAlways:
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.HealthEmergency:
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.AmmoRan:
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.AmmoEmergency:
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.AmmoAlways:
                        Debug.Log(checkDrop.selectPool);
                        break;
                }
            }
        }
    
    }

    private void DetermineGunsAndGear(EnemyType Killed)
    {
        float maxValue = 0;
        for (int i = 0; i < Killed.poolGunsAdGear.Count; i++)
        {
            EnemyType.PoolGunsAndGear checkWeight = Killed.poolGunsAdGear[i];
            maxValue = maxValue + checkWeight.Weight;
        }

        float ranNum = UnityEngine.Random.Range(0, maxValue);
        float TotalTicketsInbowl = 0;
        for (int i = 0; i < Killed.poolGunsAdGear.Count; i++)
        {
             EnemyType.PoolGunsAndGear checkWeight = Killed.poolGunsAdGear[i];
            TotalTicketsInbowl = TotalTicketsInbowl + checkWeight.Weight;
            
            if (ranNum <= TotalTicketsInbowl)
            {
                switch (checkWeight.selectGunsAndGear)
                {
                    case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_All:
                        Debug.Log(checkWeight.selectGunsAndGear);
                        DetermineRarityOfWeapon(Killed);
                        break;
                    case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_UncommonUp:
                        break;
                    case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_RareUp:
                        break;
                    case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_VeryRareUp:
                        break;
                    case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_Legendary:
                        break;
                    case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Shields:
                        Debug.Log(checkWeight.selectGunsAndGear);
                        break;
                    case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Relics:
                        Debug.Log(checkWeight.selectGunsAndGear);
                        break;
                }

                return;
            }
        }
    }

    private void DetermineRarityOfWeapon(EnemyType killed)
    {
       
    }
}