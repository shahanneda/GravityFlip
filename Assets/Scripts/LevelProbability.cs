using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelProbability : MonoBehaviour
{
    [SerializeField] public List<Level> levelPrefabs = new List<Level>();
}
[Serializable]
public struct Level{
    public GameObject prefab;
    public float probability;
}
