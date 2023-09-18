using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ActiveFreeCamera : MonoBehaviour
{
    [SerializeField] private CinemachineBrain cinemachineBrain;
    public void ActivateCamera(CinemachineFreeLook freeLook)
    {
        cinemachineBrain.GetComponent<CinemachineBrain>().ActiveVirtualCamera.VirtualCameraGameObject.SetActive(false);
        freeLook.gameObject.SetActive(true);        
    }
}
