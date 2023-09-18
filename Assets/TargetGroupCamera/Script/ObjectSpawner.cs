using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private Vector3 target;
    [SerializeField] private float radius;
    [Header("Cinemachine Target Group")]
    [SerializeField] private CinemachineTargetGroup cinemachineTargetGroup;
    [SerializeField] private float targetWeight;
    [SerializeField] private float targetRadius;

    // Update is called once per frame

    private void CreateObject()
    {
        var randomDistanceX = Random.Range(-radius, radius);
        var randomDistanceZ = Random.Range(-radius, radius);
        var spawnPosition = new Vector3(target.x + randomDistanceX, target.y, target.z + randomDistanceZ);
        GameObject newObject = Instantiate(prefab, spawnPosition, Quaternion.identity);
        newObject.transform.parent = transform;
        cinemachineTargetGroup.GetComponent<CinemachineTargetGroup>().AddMember(newObject.transform,targetWeight,targetRadius);
    }
    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateObject();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            for (int i = 0; i < 10; i++)
            {
                CreateObject();
            }
        }
    }

    void Update()
    {
        InputHandler();    
    }
}
