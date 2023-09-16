using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimCamera;
    [SerializeField] private GameObject lookAt;
    
    private void HandleAim()
    {
        if(Input.GetMouseButton(1))
        {
            aimCamera.gameObject.SetActive(true);
            float horizontal = Input.GetAxis("Mouse X") * 5f;
            float vertical = Input.GetAxis("Mouse Y") * 5f;
            transform.Rotate( 0,horizontal, 0);
        }
        else
        {
            aimCamera.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        HandleAim();
    }
}
