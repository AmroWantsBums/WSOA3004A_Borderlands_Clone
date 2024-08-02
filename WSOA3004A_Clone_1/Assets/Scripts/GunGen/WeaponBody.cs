using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBody : WeaponPart
{

    public Transform barrelSocket;
    public Transform scopeSocket;
    public Transform handleSocket;
    public Transform magazineSocket;
    public Transform stockSocket;
    public int WepaonDamage;


    


    

     
    protected List<WeaponPart> weaponParts = new List<WeaponPart>();
   protected Dictionary<WeaponStatType, float> weaponStats = new Dictionary<WeaponStatType, float>();

    int rawRarity = 0;


    public void Initialize(WeaponPart barrel,WeaponPart scope,WeaponPart stock,WeaponPart magazine,WeaponPart handle)
     {
        weaponParts.Add(barrel);
        weaponParts.Add(scope);
        weaponParts.Add(stock);
        weaponParts.Add(magazine);
        weaponParts.Add(handle);

        CalculateStats();
        DetermineRarity();
       
     }

    void CalculateStats()
        {
            foreach (WeaponPart part in weaponParts)
            {

                rawRarity += (int)part.rarityLevel;

                foreach (KeyValuePair<WeaponStatType, float> stat in part.stats)
                {
                   weaponStats.Add(stat.Key, stat.Value);
                }
            }
            // go through list of weaponparts
            //go throug all stats per weapon part
            //save them in a colleciton
            
        }

    void DetermineRarity()
    {
        int averageRarity = rawRarity / weaponParts.Count;
        averageRarity = Mathf.Clamp(averageRarity, 0 , 4);
        rarityLevel = (RarityLevel)averageRarity;

        Debug.Log (rarityLevel);
    }


   
    

    public List<WeaponPart> GetWeaponParts()
    {
        return weaponParts;
    }

}
