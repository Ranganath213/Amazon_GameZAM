using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Book",menuName = "Book")]
public class BookSO : ScriptableObject
{
    [SerializeField] public GameObject bookPrefab;
    [SerializeField] public string bookName;
    [SerializeField] public int bookId;
    [SerializeField] public string bookAuthorName;

}