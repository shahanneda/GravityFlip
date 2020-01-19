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
        alignColliderWithLevelEnd();
    }

    private GameObject getCurrentLevelEnd(){
        return currentLevel.transform.Find("Level End").gameObject;
    }
    private void alignColliderWithLevelEnd(){
        transform.position = getCurrentLevelEnd().transform.position;
    }
}

