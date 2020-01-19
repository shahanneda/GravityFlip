using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overhang : MonoBehaviour
{
    public  Color[] colors;
    void Start()
    {
        Color color = colors[Random.Range(0, colors.Length)];
        foreach(Transform child in transform){
            child.gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}
