using System.Collections.Generic;
using UnityEngine;
using GameEnum.Templates;

[CreateAssetMenu(fileName = "New Order",menuName = "Order")]
public class OrderSO : ScriptableObject
{
    public Sprite orderPersonImage;
    public string personName;
    [SerializeField] public List<BookSO> booksOrdered;
    
    
}