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

    [Header("Weights for Guns and Gear")]
    [SerializeField]
    private float Weight_Common, Weight_Uncommon, Adjust_Weight_Common, Adjust_Weight_Uncommon_1, Adjust_Weight_UnCommon_2;

    [Header("Weights for Rarity")]
    [SerializeField]
    private float Common, Uncommon, AdjustToRare, AdjustToVeryRare, AdjustToLegendary;

    [Header("Weights for Type")]
    [SerializeField]
    private float Pistol, Group, Sniper, Launcher;

    [Header("weights for Manufacture")]
    [SerializeField]
    private float StandardWeight;

    [Header("Who makes What")]
    [SerializeField]
    private List<EnemyType.ManufactoresPool> PistolBrands, ARBrands, SMGBrands, ShotGunBrands, SniperBrands, LuancherBrands;
    


    [SerializeField]
    [System.Serializable]
    public struct EnemyType
    {
        public enemies selectEnemyType_SL;
 
        public List<ItemPools> itemPools;
        public List<PoolGunsAndGear> poolGunsAdGear;
        public List<RarityPool> rarityPools;
        public List<WeaponTypePool> weaponTypePools;
        public List<ManufactoresPool> manufactoresPools;

        public RarityPool.AvailableRarities produceRarity;
        public WeaponTypePool.WeaponType produceWeaponType;
        public ManufactoresPool.AllManufacterus produceManufacture;

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
       
        [System.Serializable]
        public struct RarityPool
        {
            public float Weight;
            public AvailableRarities selectRarities;

            public enum AvailableRarities
            {
                Common,
                Uncommon,
                Rare,
                VeryRare,
                Legendary
            }
        }
       
        [System.Serializable]
        public struct WeaponTypePool
        {
            public float Weight;
            public WeaponType selectWeaponType;

            public enum WeaponType
            {
                Pistol,
                AssualtRifle,
                SMG,
                ShotGun,
                Sniper,
                Luancher
            }
        }
        
        [System.Serializable]
        public struct ManufactoresPool
        {
            public float Weight;
            public AllManufacterus selectManufacturer;

            public enum AllManufacterus
            {
               Bandit,
               Tediore,
               Dahl,
               Vladoff,
               Torgue,
               Maliwan,
               Jacobs,
               Hyperion
            }
        }
    }

    


    // Start is called before the first frame update
    void Start()
    {

        SetRegularEnemyStats();
        SetBadassStats();
        
        
    }
    

    //Assigns the base value of global values to RegularEnemy
    private void SetRegularEnemyStats()
    {
        //Sets Stats ItemPools
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

        //Sets Stats for GunsAndGearPool
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

        //Sets Stats for RarityPool
        for (int i = 0; i < regularEnemy.rarityPools.Count; i++)
        {
            EnemyType.RarityPool modifyPool = regularEnemy.rarityPools[i];

            switch (modifyPool.selectRarities)
            {
                case EnemyType.RarityPool.AvailableRarities.Common:
                    modifyPool.Weight = Common;
                    break;
                case EnemyType.RarityPool.AvailableRarities.Uncommon:
                    modifyPool.Weight = Uncommon / AdjustToRare;
                    break;
                case EnemyType.RarityPool.AvailableRarities.Rare:
                    modifyPool.Weight = Uncommon / AdjustToVeryRare;
                    break;
                case EnemyType.RarityPool.AvailableRarities.VeryRare:
                    modifyPool.Weight = Uncommon / AdjustToVeryRare;
                    break;
                case EnemyType.RarityPool.AvailableRarities.Legendary:
                    modifyPool.Weight = Uncommon / AdjustToLegendary;
                    break;
            }

            regularEnemy.rarityPools[i] = modifyPool;
           
        }

        //Sets stats for weaponTypePool
        for (int i = 0; i < regularEnemy.weaponTypePools.Count; i++)
        {
            EnemyType.WeaponTypePool modifyPool = regularEnemy.weaponTypePools[i];

            switch (modifyPool.selectWeaponType)
            {
                case EnemyType.WeaponTypePool.WeaponType.Pistol:
                    modifyPool.Weight = Pistol;
                    break;
                case EnemyType.WeaponTypePool.WeaponType.AssualtRifle:
                    modifyPool.Weight = Group;
                    break;
                case EnemyType.WeaponTypePool.WeaponType.SMG:
                    modifyPool.Weight = Group;
                    break;
                case EnemyType.WeaponTypePool.WeaponType.ShotGun:
                    modifyPool.Weight = Group;
                    break;
                case EnemyType.WeaponTypePool.WeaponType.Sniper:
                    modifyPool.Weight = Sniper;
                    break;
                case EnemyType.WeaponTypePool.WeaponType.Luancher:
                    modifyPool.Weight = Launcher;
                    break;
            }

            regularEnemy.weaponTypePools[i] = modifyPool;
        }
        //Sets Stats for ManufacturesPool
        SetWeightsFormanufacturers(PistolBrands);
        SetWeightsFormanufacturers(SMGBrands);
        SetWeightsFormanufacturers(ARBrands);
        SetWeightsFormanufacturers(ShotGunBrands);
        SetWeightsFormanufacturers(SniperBrands);
        SetWeightsFormanufacturers(LuancherBrands);
    }

       private void SetWeightsFormanufacturers(List<EnemyType.ManufactoresPool> manufactoresPools)
    {
        for (int i = 0; i < manufactoresPools.Count; i++)
        {
            EnemyType.ManufactoresPool modifyPool = manufactoresPools[i];
            modifyPool.Weight = StandardWeight;
            manufactoresPools[i] = modifyPool;
        }
    }
    
    
    
    //Modifies BaseDrops for badAssEnemy
        private void SetBadassStats()
    {
        //Sets Stats ItemPools
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

        //Sets Stats for GunsAndGearPool
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
        float maxValue = 0;
        for (int i = 0; i < killed.rarityPools.Count; i++)
        {
            EnemyType.RarityPool checkWeight = killed.rarityPools[i];
            maxValue = maxValue + checkWeight.Weight;
        }
        
        float ranNum = UnityEngine.Random.Range(0, maxValue);
        
        float TotalTicketsInbowl = 0;
        for (int i = 0; i < killed.rarityPools.Count; i++)
        {
            EnemyType.RarityPool checkWeight = killed.rarityPools[i];
            TotalTicketsInbowl = TotalTicketsInbowl + checkWeight.Weight;

            if (ranNum <= TotalTicketsInbowl)
            {
                switch (checkWeight.selectRarities)
                {
                    case EnemyType.RarityPool.AvailableRarities.Common:
                        killed.produceRarity = EnemyType.RarityPool.AvailableRarities.Common;
                        break;
                    case EnemyType.RarityPool.AvailableRarities.Uncommon:
                        killed.produceRarity = EnemyType.RarityPool.AvailableRarities.Uncommon;
                        break;
                    case EnemyType.RarityPool.AvailableRarities.Rare:
                        killed.produceRarity = EnemyType.RarityPool.AvailableRarities.Rare;
                        break;
                    case EnemyType.RarityPool.AvailableRarities.VeryRare:
                        killed.produceRarity = EnemyType.RarityPool.AvailableRarities.VeryRare;
                        break;
                    case EnemyType.RarityPool.AvailableRarities.Legendary:
                        killed.produceRarity = EnemyType.RarityPool.AvailableRarities.Legendary;
                        break;
                }

                Debug.Log(killed.produceRarity);
                DetermineWeaponType(killed);
                return;
            }
        }
        
    }

    private void DetermineWeaponType(EnemyType killed)
    {
        float maxValue = 0;
        for (int i = 0; i < killed.weaponTypePools.Count; i++)
        {
            EnemyType.WeaponTypePool checkWeight = killed.weaponTypePools[i];
            maxValue = maxValue + checkWeight.Weight;
        }

        float ranNum = UnityEngine.Random.Range(0, maxValue);
        
        float TotalTicketsInbowl = 0;
        for (int i = 0; i < killed.weaponTypePools.Count; i++)
        {
            EnemyType.WeaponTypePool checkWeight = killed.weaponTypePools[i];
            TotalTicketsInbowl = TotalTicketsInbowl + checkWeight.Weight;

            if (ranNum <= TotalTicketsInbowl)
            {
                switch (checkWeight.selectWeaponType)
                {
                    case EnemyType.WeaponTypePool.WeaponType.Pistol:
                        killed.produceWeaponType = EnemyType.WeaponTypePool.WeaponType.Pistol;
                        break;
                    case EnemyType.WeaponTypePool.WeaponType.AssualtRifle:
                        killed.produceWeaponType = EnemyType.WeaponTypePool.WeaponType.AssualtRifle;
                        break;
                    case EnemyType.WeaponTypePool.WeaponType.SMG:
                        killed.produceWeaponType = EnemyType.WeaponTypePool.WeaponType.SMG;
                        break;
                    case EnemyType.WeaponTypePool.WeaponType.ShotGun:
                        killed.produceWeaponType = EnemyType.WeaponTypePool.WeaponType.ShotGun;
                        break;
                    case EnemyType.WeaponTypePool.WeaponType.Sniper:
                        killed.produceWeaponType = EnemyType.WeaponTypePool.WeaponType.Sniper;
                        break;
                    case EnemyType.WeaponTypePool.WeaponType.Luancher:
                        killed.produceWeaponType = EnemyType.WeaponTypePool.WeaponType.Luancher;
                        break;
                }

                 Debug.Log(killed.produceWeaponType);
                DetermineManufacturer(killed);
                return;
            }
        }
    }

    private void DetermineManufacturer(EnemyType killed)
    {
        switch (killed.produceWeaponType)
        {
            case EnemyType.WeaponTypePool.WeaponType.Pistol:
              
                float maxValue = 0;
                for (int i = 0; i < PistolBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = PistolBrands[i];
                    maxValue = maxValue + checkWeight.Weight;
                }

                float ranNum = UnityEngine.Random.Range(0, maxValue);

                float TotalTicketsInbowl = 0;
                for (int i = 0; i < PistolBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = PistolBrands[i];
                    TotalTicketsInbowl = TotalTicketsInbowl + checkWeight.Weight;

                    if (ranNum <= TotalTicketsInbowl)
                    {
                        switch (checkWeight.selectManufacturer)
                        {
                            case EnemyType.ManufactoresPool.AllManufacterus.Bandit:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Bandit;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Tediore:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Tediore;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Dahl:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Dahl;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Vladoff:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Vladoff;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Torgue:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Torgue;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Maliwan:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Maliwan;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Jacobs:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Jacobs;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Hyperion:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Hyperion;
                                break;
                        }

                       Debug.Log(killed.produceRarity + " " + killed.produceManufacture + " " + killed.produceWeaponType);
                        return;
                    }
                }
                break;
            case EnemyType.WeaponTypePool.WeaponType.AssualtRifle:

                float maxValueAR = 0;
                for (int i = 0; i < ARBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = ARBrands[i];
                    maxValue = maxValueAR + checkWeight.Weight;
                }

                float ranNumAR = UnityEngine.Random.Range(0, maxValueAR);

                float TotalTicketsInbowlAR = 0;
                for (int i = 0; i < ARBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = ARBrands[i];
                    TotalTicketsInbowlAR = TotalTicketsInbowlAR + checkWeight.Weight;

                    if (ranNumAR <= TotalTicketsInbowlAR)
                    {
                        switch (checkWeight.selectManufacturer)
                        {
                            case EnemyType.ManufactoresPool.AllManufacterus.Bandit:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Bandit;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Tediore:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Tediore;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Dahl:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Dahl;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Vladoff:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Vladoff;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Torgue:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Torgue;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Maliwan:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Maliwan;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Jacobs:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Jacobs;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Hyperion:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Hyperion;
                                break;
                        }

                        Debug.Log(killed.produceRarity + " " + killed.produceManufacture + " " + killed.produceWeaponType);
                        return;
                    }
                }
                 break;
            case EnemyType.WeaponTypePool.WeaponType.SMG:
                float maxValueSMG = 0;
                for (int i = 0; i < SMGBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = SMGBrands[i];
                    maxValue = maxValueSMG + checkWeight.Weight;
                }

                float ranNumSMG = UnityEngine.Random.Range(0, maxValueSMG);

                float TotalTicketsInbowlSMG = 0;
                for (int i = 0; i < SMGBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = SMGBrands[i];
                    TotalTicketsInbowlSMG = TotalTicketsInbowlSMG + checkWeight.Weight;

                    if (ranNumSMG <= TotalTicketsInbowlSMG)
                    {
                        switch (checkWeight.selectManufacturer)
                        {
                            case EnemyType.ManufactoresPool.AllManufacterus.Bandit:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Bandit;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Tediore:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Tediore;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Dahl:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Dahl;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Vladoff:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Vladoff;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Torgue:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Torgue;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Maliwan:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Maliwan;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Jacobs:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Jacobs;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Hyperion:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Hyperion;
                                break;
                        }

                        Debug.Log(killed.produceRarity + " " + killed.produceManufacture + " " + killed.produceWeaponType);
                        return;
                    }
                }

                break;
            case EnemyType.WeaponTypePool.WeaponType.ShotGun:
                float maxValueSG = 0;
                for (int i = 0; i < ShotGunBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = ShotGunBrands[i];
                    maxValue = maxValueSG + checkWeight.Weight;
                }

                float ranNumSG = UnityEngine.Random.Range(0, maxValueSG);

                float TotalTicketsInbowlSG = 0;
                for (int i = 0; i < ShotGunBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = ShotGunBrands[i];
                    TotalTicketsInbowlSG = TotalTicketsInbowlSG + checkWeight.Weight;

                    if (ranNumSG <= TotalTicketsInbowlSG)
                    {
                        switch (checkWeight.selectManufacturer)
                        {
                            case EnemyType.ManufactoresPool.AllManufacterus.Bandit:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Bandit;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Tediore:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Tediore;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Dahl:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Dahl;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Vladoff:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Vladoff;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Torgue:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Torgue;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Maliwan:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Maliwan;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Jacobs:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Jacobs;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Hyperion:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Hyperion;
                                break;
                        }

                       Debug.Log(killed.produceRarity + " " + killed.produceManufacture + " " + killed.produceWeaponType);
                        return;
                    }
                }
                break;
            case EnemyType.WeaponTypePool.WeaponType.Sniper:
                float maxValueSR = 0;
                for (int i = 0; i < SniperBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = SniperBrands[i];
                    maxValue = maxValueSR + checkWeight.Weight;
                }

                float ranNumSR = UnityEngine.Random.Range(0, maxValueSR);

                float TotalTicketsInbowlSR = 0;
                for (int i = 0; i < SniperBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = SniperBrands[i];
                    TotalTicketsInbowlSR = TotalTicketsInbowlSR + checkWeight.Weight;

                    if (ranNumSR <= TotalTicketsInbowlSR)
                    {
                        switch (checkWeight.selectManufacturer)
                        {
                            case EnemyType.ManufactoresPool.AllManufacterus.Bandit:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Bandit;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Tediore:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Tediore;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Dahl:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Dahl;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Vladoff:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Vladoff;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Torgue:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Torgue;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Maliwan:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Maliwan;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Jacobs:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Jacobs;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Hyperion:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Hyperion;
                                break;
                        }

                        Debug.Log(killed.produceRarity + " " + killed.produceManufacture + " " + killed.produceWeaponType);
                        return;
                    }
                }
                break;
            case EnemyType.WeaponTypePool.WeaponType.Luancher:
                float maxValueL = 0;
                for (int i = 0; i < LuancherBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = LuancherBrands[i];
                    maxValue = maxValueL + checkWeight.Weight;
                }

                float ranNumL = UnityEngine.Random.Range(0, maxValueL);

                float TotalTicketsInbowlL = 0;
                for (int i = 0; i < LuancherBrands.Count; i++)
                {
                    EnemyType.ManufactoresPool checkWeight = LuancherBrands[i];
                    TotalTicketsInbowlL = TotalTicketsInbowlL + checkWeight.Weight;

                    if (ranNumL <= TotalTicketsInbowlL)
                    {
                        switch (checkWeight.selectManufacturer)
                        {
                            case EnemyType.ManufactoresPool.AllManufacterus.Bandit:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Bandit;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Tediore:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Tediore;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Dahl:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Dahl;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Vladoff:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Vladoff;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Torgue:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Torgue;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Maliwan:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Maliwan;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Jacobs:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Jacobs;
                                break;
                            case EnemyType.ManufactoresPool.AllManufacterus.Hyperion:
                                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Hyperion;
                                break;
                        }

                       Debug.Log(killed.produceRarity + " " + killed.produceManufacture + " " + killed.produceWeaponType);
                        return;
                    }
                }
                break;

                
        }

       

        //float maxValue = 0;
        //for (int i = 0; i < killed.manufactoresPools.Count; i++)
        //{
        //    EnemyType.ManufactoresPool checkWeight = killed.manufactoresPools[i];
        //    maxValue = maxValue + checkWeight.Weight;
        //}

        //float ranNum = UnityEngine.Random.Range(0, maxValue);

        //float TotalTicketsInbowl = 0;
        //for (int i = 0; i < killed.manufactoresPools.Count; i++)
        //{
        //    EnemyType.ManufactoresPool checkWeight = killed.manufactoresPools[i];
        //    TotalTicketsInbowl = TotalTicketsInbowl + checkWeight.Weight;

        //    if (ranNum <= TotalTicketsInbowl)
        //    {
        //        switch (checkWeight.selectManufacturer)
        //        {
        //            case EnemyType.ManufactoresPool.AllManufacterus.Bandit:
        //                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Bandit;
        //                break;
        //            case EnemyType.ManufactoresPool.AllManufacterus.Tediore:
        //                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Tediore;
        //                break;
        //            case EnemyType.ManufactoresPool.AllManufacterus.Dahl:
        //                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Dahl;
        //                break;
        //            case EnemyType.ManufactoresPool.AllManufacterus.Vladoff:
        //                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Vladoff;
        //                break;
        //            case EnemyType.ManufactoresPool.AllManufacterus.Torgue:
        //                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Torgue;
        //                break;
        //            case EnemyType.ManufactoresPool.AllManufacterus.Maliwan:
        //                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Maliwan;
        //                break;
        //            case EnemyType.ManufactoresPool.AllManufacterus.Jacobs:
        //                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Jacobs;
        //                break;
        //            case EnemyType.ManufactoresPool.AllManufacterus.Hyperion:
        //                killed.produceManufacture = EnemyType.ManufactoresPool.AllManufacterus.Hyperion;
        //                break;
        //        }

        //        Debug.Log(killed.produceRarity + " " + killed.produceManufacture + " " + killed.produceWeaponType);
        //        return;
        //    }
        //}
    }
}
