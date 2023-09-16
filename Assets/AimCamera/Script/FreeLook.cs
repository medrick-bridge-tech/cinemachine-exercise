using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FreeLook : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> freeCameras;

    private bool IsFreeCameraActive()
    {
        foreach (var virtualCamera in freeCameras)
        {
            if (virtualCamera == Camera.main.GetComponent<CinemachineBrain>().ActiveVirtualCamera)
            {
                return true;
            }
        }
        return false;
    }
    
    private void Looking()
    {
        
    }

    private void Update()
    {
        Looking();
    }
}
