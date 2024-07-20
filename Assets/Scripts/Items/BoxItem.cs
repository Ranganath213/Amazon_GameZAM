using System;
using System.Collections;
using System.Collections.Generic;
using GameEnum.Templates;
using UnityEngine;
using UnityEngine.Serialization;

public class BoxItem : MonoBehaviour,IInteractable,IItemMovable
{
    private Transform originalParent;
    [FormerlySerializedAs("_bookSo")] [SerializeField]private List<BookSO> _bookSoList;
    public AudioSource audioSource;
    public AudioClip audioClip;
    private bool bookPacked;
    private int amountOfBook_boxHolds=0;
    private int maxBookLimit = 3;

    private void Start()
    {
        bookPacked = false;
    }

    public void Interact()
    {
        MainCanvas_UI.Instance.Show_BoxDetails(_bookSoList);
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Book")&& amountOfBook_boxHolds<maxBookLimit)
        {
            audioSource.PlayOneShot(audioClip);
            PackBook(other.gameObject);
            amountOfBook_boxHolds++;
            if (amountOfBook_boxHolds == maxBookLimit)
                bookPacked = true;
        }
        
    }

    private void PackBook(GameObject bookPlaced)
    {
        BookItem bookItem=   bookPlaced.GetComponent<BookItem>();
        this._bookSoList.Add( bookItem._bookSo);
        Destroy(bookPlaced);
    }

    public bool OnPickup(Transform handTransform)
    {
        if (bookPacked)
        {
            MainCanvas_UI.Instance.HideBoxPanel();
            originalParent = transform.parent;
            transform.SetParent(handTransform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<BoxCollider>().enabled = false;// Disable physics
            return true;
        }

        return false;
    }

    public void OnPlace(Transform newParentTransform)
    {
        if (bookPacked)
        {
            transform.SetParent(newParentTransform);
            GetComponent<Rigidbody>().isKinematic = false; // Enable physics
            GetComponent<BoxCollider>().enabled = true;// Disable physics
        }
    }

    public void OnRemoveItemFromPlayer()
    {
        if (bookPacked)
        {
            transform.SetParent(null);
            GetComponent<Rigidbody>().isKinematic = false; // Disable physics  
            GetComponent<BoxCollider>().enabled = true;// Disable physics
            
        }
    }

    public void OnThrow()
    {
        if (bookPacked)
        {
            transform.SetParent(null); // Remove from parent
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false; // Enable physics
            Vector3 throwDirection = Camera.main.transform.forward; // Ge
            rb.AddForce(throwDirection * 20f, ForceMode.Impulse); // Apply force to throw the item
            GetComponent<BoxCollider>().enabled = true;
        }
    }
}
