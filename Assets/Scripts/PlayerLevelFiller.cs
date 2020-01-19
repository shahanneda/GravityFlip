using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelFiller : MonoBehaviour
{

    public GameObject[] levelPrefabs;
    public Transform levelParent;
    public int levelPrebuffNumber = 10;
    private GameObject currentGenerationLevel = null;


    public void Start()
    {
        GameObject newLevel = Instantiate(levelPrefabs[0], transform.position, Quaternion.identity, levelParent);
        currentGenerationLevel = newLevel;

        for (int i = 0; i < levelPrebuffNumber; i++)
        {
            GenerateRandomNewLevel();
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
            GenerateRandomNewLevel();
        } 
    }
    private GameObject PickRandomNewLevel(){
        return levelPrefabs[Random.Range(0,levelPrefabs.Length)];
    }

    private void CreateNewLevel(GameObject levelPrefab){
        GameObject newLevel = Instantiate(levelPrefab, GetNewLevelPosition(levelPrefab), Quaternion.identity, levelParent);
        currentGenerationLevel = newLevel;
    }
    private Vector3 GetNewLevelPosition(GameObject level){
        Vector3 newLevelPos = getCurrentLevelEnd().transform.position;
        Vector3 levelStartLocalPos = level.transform.Find("Level Start").localPosition;
        newLevelPos = newLevelPos - levelStartLocalPos;
        return newLevelPos;
    }

    public void GenerateRandomNewLevel(){
        CreateNewLevel(PickRandomNewLevel());
    }
}

