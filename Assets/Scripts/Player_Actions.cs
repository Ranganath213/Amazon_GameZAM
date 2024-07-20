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

        if (Input.GetKeyDown(KeyCode.I))
        {
            CheckForInventory();
        }
    }
    private void CheckForInventory()
    {
      //  InventoryManager.Instance.EnableInventory();
    }
    private void CheckForInteractables()
    {
        IInteractable interactableItem=null;
        if (this.mainCamera.IsInteractableObjectInRange(out interactableItem))
        {
            if (interactableItem != null)
            {
                interactableItem.Interact();
            }
        }
    }

}
