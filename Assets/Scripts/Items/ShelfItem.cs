using System;
using System.Collections;
using System.Collections.Generic;
using GameEnum.Templates;
using UnityEngine;

public class ShelfItem : MonoBehaviour,IInteractable
{
    [SerializeField] private ShelfSO _shelfSo;
    [SerializeField] private Transform spawnerPos;
    [SerializeField] private Transform booksParentGameObject;
    [SerializeField] private Vector3 spawnOffset;
    
    private void InitializeBooks()
    {
        int booksPerRow = 5;
        Vector3 initialPosition = spawnerPos.position;
        Vector3 rowOffset = new Vector3(0, -2, 0); // Adjust the Y-axis offset for the new row, you can change it as per your needs

        for (int i = 0; i < _shelfSo.booksListToShow.Count; i++)
        {
            var _book = _shelfSo.booksListToShow[i];
            GameObject spawnedBook = Instantiate(_book.bookPrefab, spawnerPos.position, Quaternion.identity, booksParentGameObject);
        
            // Check if we need to move to the next row
            if ((i + 1) % booksPerRow == 0)
            {
                spawnerPos.position = new Vector3(initialPosition.x, spawnerPos.position.y, initialPosition.z) + rowOffset;
                initialPosition = spawnerPos.position; // Update the initial position for the next row
            }
            else
            {
                spawnerPos.position += spawnOffset; // Update position for the next spawn
            }
        }
    }

    private void Start()
    {
        InitializeBooks();
    }

    public void Interact()
    {
        Debug.Log("Interacted with Shelf");
    }
}
