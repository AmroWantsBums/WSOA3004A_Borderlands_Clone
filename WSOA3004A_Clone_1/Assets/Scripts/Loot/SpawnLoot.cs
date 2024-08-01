using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLoot : MonoBehaviour
{
    [SerializeField]
    private playerHealthController playerHealth;
    [SerializeField]
    private weaponController weaponControllerScript;
    [SerializeField]
    private WeaponGenerator weaponGenerator;
    
   [Header("Enemy Possible Loot Drops")]
    public EnemyType regularEnemy, badAssEnemy, chubbyEnemy;
    

    [Header("DropStats")]
    [SerializeField]
    private float dropOdd_GunsAndGear, dropOdd_Money, dropOdd_EridiumStick, dropOdd_Eridiumbar, dropOdd_HealthRan, dropOdd_AmmoRan;

    [Header("ScaleBadAssStats")]
    [SerializeField]
    private float bA_SGaG, bA_SM, bA_SES, bA_SEB, bA_SHR, bA_SAR, bA_SCommon, bA_SUncommon, bA_SRare, bA_SVeryRare, bA_SLegendary;

    [Header("ScaleChubbyStats")]
    [SerializeField]
    private float c_SGaG, c_SM, c_SES, c_SEB, c_SHR, c_SAR, c_SCommon, c_SUncommon, c_SRare, c_SVeryRare, c_SLegendary;

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

    [Header("Prefabs for Drops")]
    [SerializeField]
    private GameObject GunsPrefab, ShieldPrefab, RelicPrefab, MoneyPrefab, EridiumStickPrefab, EridiumBarPrefab, HealthPrefab, AmmoPrefab, ExperiencePrefab;

    [SerializeField]
    private float min, max, minF, maxF;


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


    private void Awake()
    {
        SetRegularEnemyStats();
        SetBadassStats();
        SetChubbyStats();
    }

    // Start is called before the first frame update
    void Start()
    {

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
                case EnemyType.ItemPools.AvailablePools.Money:
                    modifyPool.dropRate = dropOdd_Money;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.EridiumStick:
                    modifyPool.dropRate = dropOdd_EridiumStick;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.EridiumBar:
                    modifyPool.dropRate = dropOdd_Eridiumbar;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.HealthRan:
                    modifyPool.dropRate = dropOdd_HealthRan;
                    regularEnemy.itemPools[i] = modifyPool;
                    break;
                
                case EnemyType.ItemPools.AvailablePools.AmmoRan:
                    modifyPool.dropRate = dropOdd_AmmoRan;
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
                    modifyPool.Weight = Uncommon;
                    break;
                case EnemyType.RarityPool.AvailableRarities.Rare:
                    modifyPool.Weight = Uncommon / AdjustToRare;
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
            EnemyType.ItemPools modifyPool = badAssEnemy.itemPools[i];

            switch (modifyPool.selectPool)
            {
                case EnemyType.ItemPools.AvailablePools.GunsAndGear:
                    modifyPool.dropRate = dropOdd_GunsAndGear*bA_SGaG;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.Money:
                    modifyPool.dropRate = dropOdd_Money*bA_SM;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.EridiumStick:
                    modifyPool.dropRate = dropOdd_EridiumStick*bA_SES;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.EridiumBar:
                    modifyPool.dropRate = dropOdd_Eridiumbar*bA_SEB;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.HealthRan:
                    modifyPool.dropRate = dropOdd_HealthRan*bA_SHR;
                    badAssEnemy.itemPools[i] = modifyPool;
                    break;
                
                case EnemyType.ItemPools.AvailablePools.AmmoRan:
                    modifyPool.dropRate = dropOdd_AmmoRan*bA_SAR;
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

        //Sets Stats for RarityPool
        for (int i = 0; i < badAssEnemy.rarityPools.Count; i++)
        {
            EnemyType.RarityPool modifyPool = badAssEnemy.rarityPools[i];

            switch (modifyPool.selectRarities)
            {
                case EnemyType.RarityPool.AvailableRarities.Common:
                    modifyPool.Weight = Common - Common;
                    break;
                case EnemyType.RarityPool.AvailableRarities.Uncommon:
                    modifyPool.Weight = Uncommon;
                    break;
                case EnemyType.RarityPool.AvailableRarities.Rare:
                    modifyPool.Weight = Uncommon / AdjustToRare;
                    break;
                case EnemyType.RarityPool.AvailableRarities.VeryRare:
                    modifyPool.Weight = Uncommon / AdjustToVeryRare;
                    break;
                case EnemyType.RarityPool.AvailableRarities.Legendary:
                    modifyPool.Weight = Uncommon / AdjustToLegendary;
                    break;
            }

            badAssEnemy.rarityPools[i] = modifyPool;

        }

        //Sets stats for weaponTypePool
        for (int i = 0; i < badAssEnemy.weaponTypePools.Count; i++)
        {
            EnemyType.WeaponTypePool modifyPool = badAssEnemy.weaponTypePools[i];

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

            badAssEnemy.weaponTypePools[i] = modifyPool;
        }
        //Sets Stats for ManufacturesPool
        SetWeightsFormanufacturers(PistolBrands);
        SetWeightsFormanufacturers(SMGBrands);
        SetWeightsFormanufacturers(ARBrands);
        SetWeightsFormanufacturers(ShotGunBrands);
        SetWeightsFormanufacturers(SniperBrands);
        SetWeightsFormanufacturers(LuancherBrands);
    }

    
        private void SetChubbyStats()
    {
        //Sets Stats ItemPools
        for (int i = 0; i < chubbyEnemy.itemPools.Count; i++)
        {
            EnemyType.ItemPools modifyPool = chubbyEnemy.itemPools[i];

            switch (modifyPool.selectPool)
            {
                case EnemyType.ItemPools.AvailablePools.GunsAndGear:
                    modifyPool.dropRate = dropOdd_GunsAndGear * c_SGaG;
                    chubbyEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.Money:
                    modifyPool.dropRate = dropOdd_Money*c_SM;
                    chubbyEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.EridiumStick:
                    modifyPool.dropRate = dropOdd_EridiumStick*c_SES;
                    chubbyEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.EridiumBar:
                    modifyPool.dropRate = dropOdd_Eridiumbar*c_SEB;
                    chubbyEnemy.itemPools[i] = modifyPool;
                    break;
                case EnemyType.ItemPools.AvailablePools.HealthRan:
                    modifyPool.dropRate = dropOdd_HealthRan*c_SHR;
                    chubbyEnemy.itemPools[i] = modifyPool;
                    break;
                
                case EnemyType.ItemPools.AvailablePools.AmmoRan:
                    modifyPool.dropRate = dropOdd_AmmoRan*c_SAR;
                    chubbyEnemy.itemPools[i] = modifyPool;
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
                    chubbyEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_UncommonUp:
                    modifyPool.Weight = Weight_Common * Adjust_Weight_Common;
                    chubbyEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_RareUp:
                    modifyPool.Weight = Weight_Uncommon * Adjust_Weight_Uncommon_1;
                    chubbyEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_VeryRareUp:
                    modifyPool.Weight = Weight_Uncommon * Adjust_Weight_UnCommon_2;
                    chubbyEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Weapons_Legendary:
                    modifyPool.Weight = Weight_Uncommon;
                    chubbyEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Shields:
                    modifyPool.Weight = Weight_Common * Adjust_Weight_Common;
                    chubbyEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
                case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Relics:
                    modifyPool.Weight = Weight_Uncommon;
                    chubbyEnemy.poolGunsAdGear[i] = modifyPool;
                    break;
            }
        }

        //Sets Stats for RarityPool
        for (int i = 0; i < chubbyEnemy.rarityPools.Count; i++)
        {
            EnemyType.RarityPool modifyPool = chubbyEnemy.rarityPools[i];

            switch (modifyPool.selectRarities)
            {
                case EnemyType.RarityPool.AvailableRarities.Common:
                    modifyPool.Weight = Common - Common;
                    break;
                case EnemyType.RarityPool.AvailableRarities.Uncommon:
                    modifyPool.Weight = Uncommon - Uncommon;
                    break;
                case EnemyType.RarityPool.AvailableRarities.Rare:
                    modifyPool.Weight = c_SRare;
                    break;
                case EnemyType.RarityPool.AvailableRarities.VeryRare:
                    modifyPool.Weight = c_SVeryRare;
                    break;
                case EnemyType.RarityPool.AvailableRarities.Legendary:
                    modifyPool.Weight = c_SLegendary;
                    break;
            }

            chubbyEnemy.rarityPools[i] = modifyPool;

        }

        //Sets stats for weaponTypePool
        for (int i = 0; i < chubbyEnemy.weaponTypePools.Count; i++)
        {
            EnemyType.WeaponTypePool modifyPool = chubbyEnemy.weaponTypePools[i];

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

            chubbyEnemy.weaponTypePools[i] = modifyPool;
        }
        //Sets Stats for ManufacturesPool
        SetWeightsFormanufacturers(PistolBrands);
        SetWeightsFormanufacturers(SMGBrands);
        SetWeightsFormanufacturers(ARBrands);
        SetWeightsFormanufacturers(ShotGunBrands);
        SetWeightsFormanufacturers(SniperBrands);
        SetWeightsFormanufacturers(LuancherBrands);
    }

        // Update is called once per frame
        void Update()
    {
       
    }

    public void DetermineEnemy(GameObject enemyDied)
    {
        // EnemyType.enemies enemy = enemyDied.GetComponent<en
        EnemyType.enemies enemy = enemyDied.GetComponent<enemyHealth>().enemy;

        switch (enemy)
        {
            case EnemyType.enemies.Chumps:
                 DetermineLootToSpawn(regularEnemy, enemyDied);
                break;
            case EnemyType.enemies.Badass:
                DetermineLootToSpawn(badAssEnemy, enemyDied);
                break;
            case EnemyType.enemies.SuperBadass:
                break;
            case EnemyType.enemies.Chubby:
                DetermineLootToSpawn(chubbyEnemy, enemyDied);
                break;
            case EnemyType.enemies.RaidBosses:
                break;
            case EnemyType.enemies.NamedBosses:
                break;
        }

        
        
    }


        private void DetermineLootToSpawn(EnemyType typeKilled, GameObject enemyDied_DLTS) //DLTS=DetermineLootToSpawn
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
                        DetermineGunsAndGear(typeKilled, enemyDied_DLTS);
                        //enemyDied_DLTS.GetComponent<TestingStuff>().DropLoot.Add(GunsPrefab);
                        break;
                    case EnemyType.ItemPools.AvailablePools.Money:
                        CreateLoot(MoneyPrefab, enemyDied_DLTS, typeKilled);
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.EridiumStick:
                        CreateLoot(EridiumStickPrefab, enemyDied_DLTS, typeKilled);
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.EridiumBar:
                        CreateLoot(EridiumBarPrefab, enemyDied_DLTS, typeKilled);
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.HealthRan:
                        CreateLoot(HealthPrefab, enemyDied_DLTS, typeKilled);
                        //   enemyDied_DLTS.GetComponent<TestingStuff>().DropLoot.Add(HealthPrefab);
                        Debug.Log(checkDrop.selectPool);
                        break;
                    case EnemyType.ItemPools.AvailablePools.AmmoRan:
                        CreateLoot(AmmoPrefab, enemyDied_DLTS, typeKilled);
                        //   enemyDied_DLTS.GetComponent<TestingStuff>().DropLoot.Add(AmmoPrefab);
                        Debug.Log(checkDrop.selectPool);
                        break;
                     
                }
            }

            
        }
        float plHP = playerHealth.playerHealthPoints * 0.1f;
        if (playerHealth.playerHealthPoints < plHP)
        {
            CreateLoot(HealthPrefab, enemyDied_DLTS, typeKilled);
        }


        //float plA = weaponControllerScript.Ammo * 0.2f;
        //if (weaponControllerScript.Ammo < plA)
        //{
        //    CreateLoot(AmmoPrefab, enemyDied_DLTS, typeKilled);
        //}
    }

    private void DetermineGunsAndGear(EnemyType Killed, GameObject enemyDied_DGaG) // DGaG = DetermineGunsAndGear
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
                        DetermineRarityOfWeapon(Killed, enemyDied_DGaG);
                        break;
                    case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Shields:
                        CreateLoot(ShieldPrefab, enemyDied_DGaG, Killed);
                        Debug.Log(checkWeight.selectGunsAndGear);
                        break;
                    case EnemyType.PoolGunsAndGear.AvailableGunsAndGear.Relics:
                        CreateLoot(RelicPrefab, enemyDied_DGaG, Killed);
                        // enemyDied_DGaG.GetComponent<TestingStuff>().DropLoot.Add(RelicPrefab);
                        Debug.Log(checkWeight.selectGunsAndGear);
                        break;
                }

                return;
            }
        }
    }

    private void DetermineRarityOfWeapon(EnemyType killed, GameObject enemyDied_DRW)// DRW = DetermineRarityOfWeapon
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
                DetermineWeaponType(killed, enemyDied_DRW );
                return;
            }
        }
        
    }

    private void DetermineWeaponType(EnemyType killed, GameObject enemyDied_DWT) // DWT = DetermineWeaponType
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
                 DetermineManufacturer(killed, enemyDied_DWT);
                 return;
            }
        }
    }

    private void DetermineManufacturer(EnemyType killed, GameObject enemyDied_DMf) //DMf = DetermineManufacturer
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
                        weaponGenerator.GenerateWeapon((int)killed.produceRarity, killed.produceWeaponType, killed.produceManufacture, enemyDied_DMf);
                        //CreateLoot(GunsPrefab, enemyDied_DMf, killed);
                       //GunsPrefab.GetComponent<ShowRarityOnSpawn>().SetColour(killed.produceRarity);
                      //  enemyDied_DMf.GetComponent<TestingStuff>().DropLoot.Add(GunsPrefab);
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
                        weaponGenerator.GenerateWeapon((int)killed.produceRarity, killed.produceWeaponType, killed.produceManufacture, enemyDied_DMf);
                      //  CreateLoot(GunsPrefab, enemyDied_DMf, killed);
                      //  GunsPrefab.GetComponent<ShowRarityOnSpawn>().SetColour(killed.produceRarity);
                      //  enemyDied_DMf.GetComponent<TestingStuff>().DropLoot.Add(GunsPrefab);
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
                        weaponGenerator.GenerateWeapon((int)killed.produceRarity, killed.produceWeaponType, killed.produceManufacture, enemyDied_DMf);
                       // CreateLoot(GunsPrefab, enemyDied_DMf, killed);
                        // enemyDied_DMf.GetComponent<TestingStuff>().DropLoot.Add(GunsPrefab);
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
                        weaponGenerator.GenerateWeapon((int)killed.produceRarity, killed.produceWeaponType, killed.produceManufacture, enemyDied_DMf);
                        //CreateLoot(GunsPrefab, enemyDied_DMf, killed);
                        //  enemyDied_DMf.GetComponent<TestingStuff>().DropLoot.Add(GunsPrefab);
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
                        weaponGenerator.GenerateWeapon((int)killed.produceRarity, killed.produceWeaponType, killed.produceManufacture, enemyDied_DMf);
                        // CreateLoot(GunsPrefab, enemyDied_DMf, killed);
                        // enemyDied_DMf.GetComponent<TestingStuff>().DropLoot.Add(GunsPrefab);
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
                        weaponGenerator.GenerateWeapon((int)killed.produceRarity, killed.produceWeaponType, killed.produceManufacture, enemyDied_DMf);
                        // CreateLoot(GunsPrefab, enemyDied_DMf, killed);
                       // Debug.Log(killed.produceRarity + " " + killed.produceManufacture + " " + killed.produceWeaponType);
                        return;
                    }
                }
                break;

                
        }

       

      
    }


    private void CreateLoot(GameObject obj, GameObject enemyDied_CL, EnemyType killed)
    {
        Rigidbody2D Lootrb;
        GameObject Loot;
        Vector2 direction;
        float force;


        direction = new Vector2((float)UnityEngine.Random.Range(min, max), (float)UnityEngine.Random.Range(min, max));

        force = (float)UnityEngine.Random.Range(-minF, maxF);
        //  Loot = new GameObject();
        Loot = Instantiate(obj, enemyDied_CL.transform.position, Quaternion.identity);
        Lootrb = Loot.GetComponent<Rigidbody2D>();
        Lootrb.AddForce(direction * force, ForceMode2D.Impulse);
        
    }
    

    public void PositionGun(GameObject Gun, GameObject EnemyDied)
    {
        Debug.Log("Fok my" + Gun);
        Gun.transform.position = EnemyDied.transform.position;
        Rigidbody2D Lootrb;
        Vector2 direction;
        float force;
        direction = new Vector2((float)UnityEngine.Random.Range(min, max), (float)UnityEngine.Random.Range(min, max));
        force = (float)UnityEngine.Random.Range(-minF, maxF);
        Lootrb = Gun.GetComponent<Rigidbody2D>();
        Lootrb.AddForce(direction * force, ForceMode2D.Impulse);
    }
}