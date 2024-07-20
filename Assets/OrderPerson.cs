using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderPerson : MonoBehaviour
{
    public OrderSO bookOrders;
    public Image personImage;
    public TextMeshProUGUI personName;
    public OrderListOfBooks OrderListOfBooks;
    
    public void InitializeOrderSo(OrderSO currentOrder)
    {
        bookOrders = currentOrder;
        personImage.sprite = bookOrders.orderPersonImage;
        personName.text = bookOrders.personName;
        OrderListOfBooks.listOFBooks = bookOrders.booksOrdered;
        
        OrderListOfBooks.SetListofBooksDetails(bookOrders.booksOrdered.Count);
        OrderListOfBooks.InitializeBooks();

    }
}
