using System;
using System.Collections;
using System.Collections.Generic;
using GameEnum;
using GameEnum.Templates;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Player_Actions : MonoBehaviour
{
    #region Variables

    [Header("Main Camera")]
    [SerializeField] private MainCamera mainCamera;
    [SerializeField] private Transform handPostition;
    [SerializeField] private Transform placeTransform = null; 
    
    [SerializeField]private bool playerHasItem;
    [SerializeField]private GameObject pickedUpitem;
    private Player_Audio _player_Audio;
    #endregion


    #region Unity Methods
    private void Start()
    {
        _player_Audio = this.GetComponent<Player_Audio>();
        
    }
    private void Update()
    {
        CheckForPlayerInputs();
    }
    #endregion
  

    private void CheckForPlayerInputs()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckForInteractables();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            PlaceItem();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowItem();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            CheckForInventory();
        }
    }

    private void ThrowItem()
    {
        if (playerHasItem)
        {
            if (pickedUpitem.TryGetComponent(out IItemMovable item))
            {
                item.OnThrow();
                pickedUpitem = null;
                playerHasItem = false;
            }
        }
       
    }

    private void PlaceItem()
    {
        if (playerHasItem)
        {
            if (pickedUpitem.TryGetComponent(out IItemMovable item))
            {
                item.OnRemoveItemFromPlayer();
                pickedUpitem = null;
                playerHasItem = false;
            }
        }
      
    }

    private void CheckForInventory()
    {
      //  InventoryManager.Instance.EnableInventory();
    }
    private void CheckForInteractables()
    {
        IInteractable interactableItem=null;
        IItemMovable movableitem = null;
        GameObject item;
        if (this.mainCamera.IsInteractableObjectInRange(out interactableItem))
        {
            if (interactableItem != null)
            {
                Debug.Log("Interactable ITem");
                if (this.mainCamera.IsInteractableMovableObjectInRange(out movableitem,out item))
                {
                    Debug.Log("Throwable ITem");
                    if (!playerHasItem)
                    {
                        Debug.Log(" ITem Pickup");
                        playerHasItem = true;
                        pickedUpitem = item;
                        movableitem.OnPickup(handPostition);
                        
                    }
                    
                }

            }
        }
    }

}
