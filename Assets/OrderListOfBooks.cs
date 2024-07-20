using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderListOfBooks : MonoBehaviour
{
    public GameObject bookDetailPrefab;
    public List<BookSO> listOFBooks;
    public List<BookDetailsUI> listofBooksUI;

    public void SetListofBooksDetails(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject bookUIDetails = Instantiate(bookDetailPrefab);
            bookUIDetails.gameObject.transform.SetParent(this.gameObject.transform);
            listofBooksUI.Add(bookUIDetails.GetComponent<BookDetailsUI>());
        }
     
    }
    public void InitializeBooks()
    {
        // Check if both lists are initialized and have the same number of elements
        Debug.LogError($"List of Book Count {listOFBooks.Count}"+$"List of BookUI {listofBooksUI.Count}");
        if (listOFBooks != null && listofBooksUI != null && listOFBooks.Count == listofBooksUI.Count)
        {
            for (int i = 0; i < listOFBooks.Count; i++)
            {
                BookDetailsUI bookDetailsUI = listofBooksUI[i];
                BookSO bookSO = listOFBooks[i];
                // Assuming SetData method of BookDetailsUI takes BookSO as a parameter
                bookDetailsUI.SetData(bookSO.bookName,bookSO.bookAuthorName,bookSO.bookImage);
            }
        }
        else
        {
            Debug.LogError("Lists are not initialized or their counts do not match.");
        }
    }
}
