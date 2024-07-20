using System.Collections;
using System.Collections.Generic;
using GameEnum.Templates;
using UnityEngine;

public class ShelfItem : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with Shelf");
    }
}
