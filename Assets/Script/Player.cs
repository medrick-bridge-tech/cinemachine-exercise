using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private List<Light> flashLights;
    
    void Update()
    {
        Walking();
        Running();
        Rotation();
        HandleFlashLight();
    }

    private void Walking()
    {
        float z = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0, 0, z);
        movement = Vector3.ClampMagnitude(movement, 1);
        transform.Translate(movement * (moveSpeed * Time.deltaTime));
    }

    private void Running()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = moveSpeed - runSpeed;
        }
    }
    private void Rotation()
    {
        var view = transform.localRotation;
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f,-0.1f,0f,Space.Self);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f,0.1f,0f,Space.Self);
        }
    }

    private void HandleFlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F) && flashLights.Count>0)
        {
            foreach (var flashLight in flashLights)
            {
                flashLight.enabled = !flashLight.enabled;    
            }
        }
    }
}
