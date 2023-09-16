using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Soldier : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimCamera;
    [SerializeField] private GameObject lookAt;
    [SerializeField] private GameObject gun;

    private void VirtualCameraSetProperty(Weapon weapon)
    {
        aimCamera.GetComponent<CinemachineFollowZoom>().m_Width = weapon.Range;
    }
    
    private void HandleAim()
    {
        if(Input.GetMouseButton(1) && gun!=null)
        {
            aimCamera.gameObject.SetActive(true);
            VirtualCameraSetProperty(gun.GetComponent<Weapon>());
            float horizontal = Input.GetAxis("Mouse X") * 5f;
            float vertical = Input.GetAxis("Mouse Y") * 5f;
            transform.Rotate( 0,horizontal, 0);
            gun.transform.position = new Vector3(transform.position.x,transform.position.y-0.7f,transform.position.z);
        }
        else
        {
            aimCamera.gameObject.SetActive(false);
            if(gun!=null)
            gun.transform.position = lookAt.transform.position;
        }
    }

    private void LootGun(GameObject weapon)
    {
        GameObject newGun = Instantiate(weapon,
            new Vector3(transform.position.x + 0.5f, transform.position.y-1f, transform.position.z),
            Quaternion.identity);
        gun = newGun;
        newGun.transform.parent = transform;
    }
    
    private void CheckGun()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, 10f))
        {
            Debug.DrawRay(transform.position,hit.point-transform.position,Color.red);
            if (hit.collider.CompareTag("Gun"))
            {
                Debug.Log($"Press Enter to equip gun : {hit.collider.name}");
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (gun != null)
                    {
                        Destroy(gun);
                    }
                    LootGun(hit.collider.gameObject);
                }
            }
        }
    }

    private void EquipGun()
    {
        if (Input.GetKeyDown(KeyCode.E) && gun != null)
        {
            gun.transform.position = lookAt.transform.position;
            
            Quaternion newRotation = gun.transform.localRotation;
            newRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            gun.transform.localRotation = newRotation;
        }
    }
    private void Update()
    {
        HandleAim();
        CheckGun();
        EquipGun();
    }
}
