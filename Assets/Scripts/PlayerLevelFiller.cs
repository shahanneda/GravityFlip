using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelFiller : MonoBehaviour
{

    public Transform levelParent;
    public int levelPrebuffNumber = 10;
    private GameObject currentGenerationLevel = null;
    public List<Level> levelPrefabs = new List<Level>();

    public void Start()
    {
        GameObject newLevel = Instantiate(levelPrefabs[0].prefab, transform.position, Quaternion.identity, levelParent);
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
    private GameObject PickRandomNewLevel(){//the idea behind this is to create a pie with all the probablities, then stack them up   and pick a random number
        //if future optimization is needed this can be moved to the start as it only needs to be run once instead of every time
        List<float[]> eachLevelPie = new List<float[]>();

        eachLevelPie.Add(new float[] { 0, levelPrefabs[0].probability });
        for (int i = 1; i < levelPrefabs.Count; i++){
            eachLevelPie.Add(new float[]{ eachLevelPie[i-1][1], (eachLevelPie[i-1][1] + levelPrefabs[i].probability) }); 
        }

        //foreach(float[] pie in eachLevelPie)
        //{
        //    Debug.Log("[" + pie[0] + "," + pie[1] + "]");
        //}

        float randomNum = Random.Range(1, 1000);
        //Debug.Log("Random Number Picked: " + randomNum);
        int index = 0;
        for (int i = 0; i < eachLevelPie.Count; i++){
            if(randomNum >= eachLevelPie[i][0] && randomNum <= eachLevelPie[i][1]){
                index = i;
                break;
            }
        }
        return levelPrefabs[index].prefab;
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

