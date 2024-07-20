using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEnum.Templates;

public class MainCamera : MonoBehaviour
{
    #region Variables
    
    [Header("Camera Sensitive and Player ")]
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private float _maxRayDistance = 5f;
    [SerializeField] private Transform playerBody;
    float xRotation = 0;
    

    Camera _mainCamera;
    Ray _ray = new Ray();
    Ray _ray2 = new Ray();
    RaycastHit _hit;

    #endregion
    #region Unity Methods
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        this._mainCamera = this.gameObject.GetComponent<Camera>();
    }
    void Update()
    {
        LookAround_Mouse();
        
    }

    private void FixedUpdate()
    {
        Check_UI();
    }

    #endregion
    
    private void LookAround_Mouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    
    private void Check_UI()
    {
        _ray2 = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray2, out _hit, _maxRayDistance))
        {
            if (_hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                //If the Object is Interactable Show the Helpe
                MainCanvas_UI.Instance.Show_Helper();
                interactable.Interact();
            }
            else
            {
                MainCanvas_UI.Instance.Hide_Helper();
             MainCanvas_UI.Instance.HideBookDetailes();
            }
        }
        else
        {
            MainCanvas_UI.Instance.Hide_Helper();
            MainCanvas_UI.Instance.HideBookDetailes();
        }
    }
    
    public bool IsInteractableObjectInRange(out IInteractable interactableItem)
    {
        bool inRange = false;
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit, _maxRayDistance))
        {
            inRange = true;
            if(_hit.collider.gameObject.TryGetComponent(out interactableItem));
        }
        else
        {
            inRange = false;
            interactableItem = null;
        }
        return inRange;

    }
    public bool IsInteractableMovableObjectInRange(out IItemMovable movableItem,out GameObject item)
    {
        bool inRange = false;
        _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(_ray, out _hit, _maxRayDistance))
        {
            inRange = true;

            if (_hit.collider.gameObject.TryGetComponent(out movableItem))
            {
                item = _hit.collider.gameObject;
                return inRange;
            }
        }
        else
        {
            inRange = false;
            movableItem = null;
        }

        item = null;
        return inRange;

    }
    
}
