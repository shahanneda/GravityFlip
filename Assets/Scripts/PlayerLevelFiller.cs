using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelFiller : MonoBehaviour
{

    public GameObject levelPrefabs;
    public Transform levelParent;

    private GameObject currentLevel = null;


    public void Start()
    {
        GameObject newLevel = Instantiate(levelPrefabs, transform.position, Quaternion.identity, levelParent);
        currentLevel = newLevel;
    }

    private GameObject getCurrentLevelEnd(){
        return currentLevel.transform.Find("Level End").gameObject;
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
        Vector3 newLevelPos = transform.position;
        GameObject newLevel = Instantiate(levelPrefabs, newLevelPos, Quaternion.identity, levelParent);
        currentLevel = newLevel;
    }
}

