using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGenerator : WeaponBody
{

    public List<GameObject> bodyParts;
    public List<GameObject> barrelParts;
    public List<GameObject> stockParts;
    public List<GameObject> scopeParts;
    public List<GameObject> handleParts;
    public List<GameObject> magazineParts;


    public List<GameObject> Pistolbodypart;
    public List<GameObject> Pistolbarrelpart;
    public List<GameObject> Pistolstockpart;
    public List<GameObject> Pistolscopepart;
    public List<GameObject> Pistolhandlepart;
    public List<GameObject> Pistolmagazinepart;

    public List<GameObject> Rocketbodypart;
    public List<GameObject> Rocketbarrelpart;
    public List<GameObject> Rocketstockpart;
    public List<GameObject> Rocketscopepart;
    public List<GameObject> Rockethandlepart;
    public List<GameObject> Rocketmagazinepart;

    public List<GameObject> Shotgunbodypart;
    public List<GameObject> Shotgunbarrelpart;
    public List<GameObject> Shotgunstockpart;
    public List<GameObject> Shotgunscopepart;
    public List<GameObject> Shotgunhandlepart;
    public List<GameObject> Shotgunmagazinepart;

    public List<GameObject> Sniperbodypart;
    public List<GameObject> Sniperbarrelpart;
    public List<GameObject> Sniperstockpart;
    public List<GameObject> Sniperscopepart;
    public List<GameObject> Sniperhandlepart;
    public List<GameObject> Snipermagazinepart;

    public List<GameObject> Smgbodypart;
    public List<GameObject> Smgbarrelpart;
    public List<GameObject> Smgstockpart;
    public List<GameObject> Smgscopepart;
    public List<GameObject> Smghandlepart;
    public List<GameObject> Smgmagazinepart;

    public List<GameObject> Riflebodypart;
    public List<GameObject> Riflebarrelpart;
    public List<GameObject> Riflestockpart;
    public List<GameObject> Riflescopepart;
    public List<GameObject> Riflehandlepart;
    public List<GameObject> Riflemagazinepart;










    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            GenerateWeapon(); // change to be different for each weapon must change, eg GeneratePistol
        }

        if (Input.GetKeyDown(KeyCode.P)){
            GeneratePistol();
        }

        if (Input.GetKeyDown(KeyCode.R)){
            GenerateRocket();
        }

        if (Input.GetKeyDown(KeyCode.A)){
            GenerateRifle();
        }

        if (Input.GetKeyDown(KeyCode.S)){
            GenerateShotgun();
        }

        if (Input.GetKeyDown(KeyCode.M)){
            GenerateSmg();
        }

        if (Input.GetKeyDown(KeyCode.N)){
            GenerateSniper();
        }
    }

    void GenerateWeapon(){// random 

        

        GameObject randomBody = GetRandomPart(bodyParts);
       GameObject insBody = Instantiate(randomBody, Vector3.zero, Quaternion.identity);
        WeaponBody wpnBody = insBody.GetComponent<WeaponBody>();

        WeaponPart barrel = SpawnWeaponPart(barrelParts,wpnBody.barrelSocket);

        WeaponPart stock = SpawnWeaponPart(stockParts,wpnBody.stockSocket);

        WeaponPart handle = SpawnWeaponPart(handleParts,wpnBody.handleSocket);

        WeaponPart scope = SpawnWeaponPart(scopeParts,wpnBody.scopeSocket);

        WeaponPart magazine = SpawnWeaponPart(magazineParts,wpnBody.magazineSocket);
        //get random body from list
        //instantiate it
        wpnBody.Initialize(barrel, scope, stock, handle, magazine);

        
    }


    void GeneratePistol(){// random for pistol only


        

        GameObject randomBody = GetPistolPart(Pistolbodypart);
       GameObject insBody = Instantiate(randomBody, Vector3.zero, Quaternion.identity);
        WeaponBody pistolBody = insBody.GetComponent<WeaponBody>();

        WeaponPart barrel = SpawnPistolPart(Pistolbarrelpart,pistolBody.barrelSocket);

        WeaponPart stock = SpawnPistolPart(Pistolstockpart,pistolBody.stockSocket);

      WeaponPart handle =  SpawnPistolPart(Pistolhandlepart,pistolBody.handleSocket);

      WeaponPart scope =  SpawnPistolPart(Pistolscopepart,pistolBody.scopeSocket);

       WeaponPart magazine = SpawnPistolPart(Pistolmagazinepart,pistolBody.magazineSocket);
        //get random body from list
        //instantiate it
       // pistolBody.Initialize(barrel, scope, stock, handle, magazine);
        pistolBody.Initialize(barrel, scope, stock, handle, magazine);
        
    }

    void GenerateRocket(){// random for pistol only
        GameObject randomBody = GetRocketPart(Rocketbodypart);
       GameObject insBody = Instantiate(randomBody, Vector3.zero, Quaternion.identity);
        WeaponBody RocketBody = insBody.GetComponent<WeaponBody>();

        WeaponPart barrel =  SpawnRocketPart(Rocketbarrelpart,RocketBody.barrelSocket);

      WeaponPart stock =  SpawnRocketPart(Rocketstockpart,RocketBody.stockSocket);

       WeaponPart handle = SpawnRocketPart(Rockethandlepart,RocketBody.handleSocket);

       WeaponPart scope =  SpawnRocketPart(Rocketscopepart,RocketBody.scopeSocket);

       WeaponPart magazine = SpawnRocketPart(Rocketmagazinepart,RocketBody.magazineSocket);
        //get random body from list
        //instantiate it
        RocketBody.Initialize(barrel, scope, stock, handle, magazine);
    }

    void GenerateSniper(){// random for pistol only
        GameObject randomBody = GetSniperPart(Sniperbodypart);
       GameObject insBody = Instantiate(randomBody, Vector3.zero, Quaternion.identity);
        WeaponBody SniperBody = insBody.GetComponent<WeaponBody>();

       WeaponPart barrel =   SpawnSniperPart(Sniperbarrelpart,SniperBody.barrelSocket);

       WeaponPart stock = SpawnSniperPart(Sniperstockpart,SniperBody.stockSocket);

      WeaponPart handle =  SpawnSniperPart(Sniperhandlepart,SniperBody.handleSocket);

       WeaponPart scope = SpawnSniperPart(Sniperscopepart,SniperBody.scopeSocket);

        WeaponPart magazine = SpawnSniperPart(Snipermagazinepart,SniperBody.magazineSocket);
        //get random body from list
        //instantiate it
        SniperBody.Initialize(barrel, scope, stock, handle, magazine);
    }

    void GenerateShotgun(){// random for pistol only
        GameObject randomBody = GetShotgunPart(Shotgunbodypart);
       GameObject insBody = Instantiate(randomBody, Vector3.zero, Quaternion.identity);
        WeaponBody ShotgunBody = insBody.GetComponent<WeaponBody>();

        WeaponPart barrel =  SpawnShotgunPart(Shotgunbarrelpart,ShotgunBody.barrelSocket);

      WeaponPart stock =  SpawnShotgunPart(Shotgunstockpart,ShotgunBody.stockSocket);

      WeaponPart handle =   SpawnShotgunPart(Shotgunhandlepart,ShotgunBody.handleSocket);

       WeaponPart scope =  SpawnShotgunPart(Shotgunscopepart,ShotgunBody.scopeSocket);

      WeaponPart magazine =  SpawnShotgunPart(Shotgunmagazinepart,ShotgunBody.magazineSocket);
        //get random body from list
        //instantiate it
        ShotgunBody.Initialize(barrel, scope, stock, handle, magazine);
    }

    void GenerateSmg(){// random for pistol only
        GameObject randomBody = GetSmgPart(Smgbodypart);
       GameObject insBody = Instantiate(randomBody, Vector3.zero, Quaternion.identity);
        WeaponBody SmgBody = insBody.GetComponent<WeaponBody>();

       WeaponPart barrel =   SpawnSmgPart(Smgbarrelpart,SmgBody.barrelSocket);

      WeaponPart stock =   SpawnSmgPart(Smgstockpart,SmgBody.stockSocket);

       WeaponPart handle =   SpawnSmgPart(Smghandlepart,SmgBody.handleSocket);

       WeaponPart scope =  SpawnSmgPart(Smgscopepart,SmgBody.scopeSocket);

       WeaponPart magazine = SpawnSmgPart(Smgmagazinepart,SmgBody.magazineSocket);
        //get random body from list
        //instantiate it
       SmgBody.Initialize(barrel, scope, stock, handle, magazine);
    }

    void GenerateRifle(){// random for pistol only
        GameObject randomBody = GetRiflePart(Riflebodypart);
       GameObject insBody = Instantiate(randomBody, Vector3.zero, Quaternion.identity);
        WeaponBody RifleBody = insBody.GetComponent<WeaponBody>();

       WeaponPart barrel =  SpawnRiflePart(Riflebarrelpart,RifleBody.barrelSocket);

      WeaponPart stock =   SpawnRiflePart(Riflestockpart,RifleBody.stockSocket);

       WeaponPart handle =  SpawnRiflePart(Riflehandlepart,RifleBody.handleSocket);

       WeaponPart scope =  SpawnRiflePart(Riflescopepart,RifleBody.scopeSocket);

       WeaponPart magazine =   SpawnRiflePart(Riflemagazinepart,RifleBody.magazineSocket);
        //get random body from list
        //instantiate it
        RifleBody.Initialize(barrel, scope, stock, handle, magazine);
    }

    


    WeaponPart SpawnWeaponPart(List<GameObject> parts, Transform socket){
        GameObject randomPart = GetRandomPart(parts);
        GameObject insPart = Instantiate(randomPart, socket.transform.position, socket.transform.rotation);
        insPart.transform.parent = socket;

        return insPart.GetComponent<WeaponPart>();
    }

    WeaponPart SpawnPistolPart(List<GameObject> parts, Transform socket){
        GameObject randomPart = GetPistolPart(parts);
        GameObject insPart = Instantiate(randomPart, socket.transform.position, socket.transform.rotation);
        insPart.transform.parent = socket;
        return insPart.GetComponent<WeaponPart>();
    }

    WeaponPart SpawnRocketPart(List<GameObject> parts, Transform socket){
        GameObject randomPart = GetRocketPart(parts);
        GameObject insPart = Instantiate(randomPart, socket.transform.position, socket.transform.rotation);
        insPart.transform.parent = socket;
        return insPart.GetComponent<WeaponPart>();
    }

    WeaponPart SpawnSniperPart(List<GameObject> parts, Transform socket){
        GameObject randomPart = GetSniperPart(parts);
        GameObject insPart = Instantiate(randomPart, socket.transform.position, socket.transform.rotation);
        insPart.transform.parent = socket;
        return insPart.GetComponent<WeaponPart>();
    }

    WeaponPart SpawnShotgunPart(List<GameObject> parts, Transform socket){
        GameObject randomPart = GetShotgunPart(parts);
        GameObject insPart = Instantiate(randomPart, socket.transform.position, socket.transform.rotation);
        insPart.transform.parent = socket;
        return insPart.GetComponent<WeaponPart>();
    }

    WeaponPart SpawnSmgPart(List<GameObject> parts, Transform socket){
        GameObject randomPart = GetSmgPart(parts);
        GameObject insPart = Instantiate(randomPart, socket.transform.position, socket.transform.rotation);
        insPart.transform.parent = socket;
        return insPart.GetComponent<WeaponPart>();
    }

    WeaponPart SpawnRiflePart(List<GameObject> parts, Transform socket){
        GameObject randomPart = GetRiflePart(parts);
        GameObject insPart = Instantiate(randomPart, socket.transform.position, socket.transform.rotation);
        insPart.transform.parent = socket;
        return insPart.GetComponent<WeaponPart>();
    }



    GameObject GetRandomPart(List<GameObject> partList){
        int randomNumber = Random.Range(0, partList.Count);
        return partList[randomNumber];
    }


    GameObject GetPistolPart(List<GameObject> pistolpartList){
        int pistolrandomNumber = Random.Range(0, pistolpartList.Count);
        return pistolpartList[pistolrandomNumber];
    }

    GameObject GetRocketPart(List<GameObject> rocketpartList){
        int rocketrandomNumber = Random.Range(0, rocketpartList.Count);
        return rocketpartList[rocketrandomNumber];
    }

    GameObject GetSniperPart(List<GameObject> sniperpartList){
        int sniperrandomNumber = Random.Range(0, sniperpartList.Count);
        return sniperpartList[sniperrandomNumber];
    }

    GameObject GetShotgunPart(List<GameObject> shotgunpartList){
        int shotgunrandomNumber = Random.Range(0, shotgunpartList.Count);
        return shotgunpartList[shotgunrandomNumber];
    }

    GameObject GetSmgPart(List<GameObject> smgpartList){
        int smgrandomNumber = Random.Range(0, smgpartList.Count);
        return smgpartList[smgrandomNumber];
    }

    GameObject GetRiflePart(List<GameObject> riflepartList){
        int riflerandomNumber = Random.Range(0, riflepartList.Count);
        return riflepartList[riflerandomNumber];
    }
}
