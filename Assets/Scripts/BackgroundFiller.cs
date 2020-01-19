using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFiller : MonoBehaviour
{
    public GameObject backgroundPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            GameObject clone = Instantiate(backgroundPrefab, new Vector3(transform.position.x + 2 * i, transform.position.y, transform.position.z), Quaternion.identity, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
