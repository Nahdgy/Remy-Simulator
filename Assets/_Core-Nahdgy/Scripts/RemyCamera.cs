using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemyCamera : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensibilityX, _mouseSensibilityY, _pickUpRange = 2.6f;
    private float _cameraRotationX, _cameraRotationY;
    [SerializeField]
    private Transform _oriantationCam;
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField]
    private GameObject _picUpUI;
    public ItemBehavior _pickUp;




     private void Start()
     {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;    
     }

    void GetMouseInput()
    {
        float _mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * _mouseSensibilityX;
        float _mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * _mouseSensibilityY;
        _cameraRotationY += _mouseX;
        _cameraRotationX -= _mouseY;
        _cameraRotationX = Mathf.Clamp(_cameraRotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(_cameraRotationX, _cameraRotationY, 0);
        _oriantationCam.rotation = Quaternion.Euler(0, _cameraRotationY, 0);
    }
    private void ObjectTargeted()
    {
        RaycastHit _hit;
        if (Physics.Raycast(transform.position, transform.forward, out _hit, _pickUpRange, _layerMask))
        {
            if (_hit.transform.CompareTag("Item"))
            {
                _picUpUI.SetActive(true);
                if (Input.GetButtonDown("Pick"))
                {
                    _pickUp.DoPickUp(_hit.transform.gameObject.GetComponent<Item>());

                }
            }
        }
        else 
        {
            _picUpUI.SetActive(false);
        }

    }


    private void Update()
    {
        ObjectTargeted();
        GetMouseInput();
    }
}
