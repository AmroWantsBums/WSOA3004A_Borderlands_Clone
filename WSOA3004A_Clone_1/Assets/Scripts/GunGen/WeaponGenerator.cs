using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGenerator : MonoBehaviour
{

    public List<GameObject> bodyParts;
    public List<GameObject> barrelParts;
    public List<GameObject> stockParts;
    public List<GameObject> scopeParts;
    public List<GameObject> handleParts;
    public List<GameObject> magazineParts;

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
    }

    void GenerateWeapon(){
        GameObject randomBody = GetRandomPart(bodyParts);
       GameObject insBody = Instantiate(randomBody, Vector3.zero, Quaternion.identity);
        WeaponBody wpnBody = insBody.GetComponent<WeaponBody>();

        SpawnWeaponPart(barrelParts,wpnBody.barrelSocket);

        SpawnWeaponPart(stockParts,wpnBody.stockSocket);

        SpawnWeaponPart(handleParts,wpnBody.handleSocket);

        SpawnWeaponPart(scopeParts,wpnBody.scopeSocket);

        SpawnWeaponPart(magazineParts,wpnBody.magazineSocket);

        
        
        
        
        
        //get random body from list
        //instantiate it
    }

    void SpawnWeaponPart(List<GameObject> parts, Transform socket){
        GameObject randomPart = GetRandomPart(parts);
        GameObject insPart = Instantiate(randomPart, socket.transform.position, socket.transform.rotation);
        insPart.transform.parent = socket;
    }


    GameObject GetRandomPart(List<GameObject> partList){
        int randomNumber = Random.Range(0, partList.Count);
        return partList[randomNumber];
    }
}
