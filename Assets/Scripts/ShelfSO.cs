using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shelf",menuName = "ShelfBooks")]
public class ShelfSO : ScriptableObject
{
    [SerializeField] public List<BookSO> booksListToShow;
    
}