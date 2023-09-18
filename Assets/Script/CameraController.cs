using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Cinemachine;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

public class CameraController : MonoBehaviour
{
    [SerializeField] private List<CinemachineVirtualCamera> cinemachineVirtualCameras;
    private int _index = 0;

    private void Awake()
    {
        if (cinemachineVirtualCameras.Count<1)
        {
            Destroy(GetComponent<CameraController>());
        }
    }

    private void Start()
    {
        cinemachineVirtualCameras[_index].gameObject.SetActive(true);
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.V) && cinemachineVirtualCameras.Count >0)
        {
            if (_index < cinemachineVirtualCameras.Count-1)
            {
                _index++;
            }
            else
            {
                _index = 0;
            }

            for (int i = 0; i < cinemachineVirtualCameras.Count; i++)
            {
                cinemachineVirtualCameras[i].gameObject.SetActive(i == _index);
            }

            Debug.Log($"{_index}/{cinemachineVirtualCameras.Count-1}");
        }

    }
}
