using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelFiller : MonoBehaviour
{

    public GameObject levelPrefabs;
    public Transform levelParent;
    public int levelPrebuffNumber = 10;
    private GameObject currentGenerationLevel = null;


    public void Start()
    {
        GameObject newLevel = Instantiate(levelPrefabs, transform.position, Quaternion.identity, levelParent);
        currentGenerationLevel = newLevel;
        for (int i = 0; i < levelPrebuffNumber; i++){
            GenerateNewLevel();
        }
    }

    private GameObject getCurrentLevelEnd(){
        return currentGenerationLevel.transform.Find("Level End").gameObject;
    }
    private void alignColliderWithLevelEnd(){
        transform.position = getCurrentLevelEnd().transform.position;
    }
    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Level End"){
            GenerateNewLevel();
        } 
    }

    private void GenerateNewLevel(){

        Vector3 newLevelPos = getCurrentLevelEnd().transform.position;
        Vector3 levelStartLocalPos = levelPrefabs.transform.Find("Level Start").localPosition;
        newLevelPos = newLevelPos - levelStartLocalPos;

        GameObject newLevel = Instantiate(levelPrefabs, newLevelPos, Quaternion.identity, levelParent);
        currentGenerationLevel = newLevel;
          
    }
}

