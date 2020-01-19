using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyer : MonoBehaviour
{
    public Transform LevelParent;
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.IsChildOf(LevelParent)){
            Destroy(other.gameObject);
        }
    }
}
