using System;
using System.Collections;
using System.Collections.Generic;
using GameEnum.Templates;
using UnityEngine;

public class BookItem : MonoBehaviour,IInteractable,IItemMovable
{
    private Transform originalParent;
    [SerializeField] public BookSO _bookSo;
    public void Interact()
    {
        MainCanvas_UI.Instance.Show_Details(_bookSo.bookName);
        
    }
    
    public void OnPickup(Transform handTransform)
    {
        originalParent = transform.parent;
        transform.SetParent(handTransform);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        GetComponent<Rigidbody>().isKinematic = true; // Disable physics
    }

    public void OnPlace(Transform newParentTransform)
    {
        transform.SetParent(newParentTransform);
        GetComponent<Rigidbody>().isKinematic = false; // Enable physics
    }

    public void OnRemoveItemFromPlayer()
    {
        transform.SetParent(null);
        GetComponent<Rigidbody>().isKinematic = false; // Disable physics   
    }

    public void OnThrow()
    {
        transform.SetParent(null); // Remove from parent
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false; // Enable physics
        Vector3 throwDirection = Camera.main.transform.forward; // Ge
        rb.AddForce(throwDirection*20f, ForceMode.Impulse); // Apply force to throw the item
    }
}
