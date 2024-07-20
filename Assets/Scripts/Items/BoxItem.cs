using System;
using System.Collections;
using System.Collections.Generic;
using GameEnum.Templates;
using UnityEngine;

public class BoxItem : MonoBehaviour,IInteractable
{
    [SerializeField]private BookSO _bookSo;
    
    public void Interact()
    {
        Debug.Log("Interacted with box");
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Book"))
        {
            PackBook(other.gameObject);
        }
        
    }

    private void PackBook(GameObject bookPlaced)
    {
        BookItem bookItem=   bookPlaced.GetComponent<BookItem>();
        this._bookSo = bookItem._bookSo;
        Debug.Log("Book Packed");
    }
}
