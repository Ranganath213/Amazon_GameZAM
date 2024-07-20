using System;
using System.Collections;
using System.Collections.Generic;
using GameEnum.Templates;
using UnityEngine;

public class BookItem : MonoBehaviour,IInteractable
{
    [SerializeField] private BookSO _bookSo;
   
   
    public void Interact()
    {
        Debug.Log("Interacted with Book");
        MainCanvas_UI.Instance.SendMessage(_bookSo.name);
        
    }
}
