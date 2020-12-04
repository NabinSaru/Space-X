using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHandler : MonoBehaviour
{
    [SerializeField] GameObject obstaclePrefab;
    void Start()
    {
        for (int i = 0; i < Random.Range(10,20); i++)
        {
            GameObject temp = Instantiate(obstaclePrefab,new Vector3(Random.Range(-35,35),4.7f,Random.Range(transform.position.z-36,transform.position.z+36)),Quaternion.identity);
            temp.transform.parent = gameObject.transform;
        }
    }
    void Update()
    {
        
    }
}
