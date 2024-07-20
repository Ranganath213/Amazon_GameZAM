using System.Collections;
using System.Collections.Generic;
using GameEnum.Templates;
using UnityEngine;

public class BoxItem : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        Debug.Log("Interacted with box");
    }
}
