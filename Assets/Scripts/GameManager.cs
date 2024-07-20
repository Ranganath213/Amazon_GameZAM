using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using GameEnum;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private ShelfItem _shelf;
    [SerializeField] private AllOrders _allOrders;
    [SerializeField] private AllOrderSO _allOrderSo;

    public GameObject boxPosituin;
    public GameObject boxPrefab;
    private GameObject box;
    private void Start()
    {
        Day1System(DayCount.Day1);
    }

    public void Day1System(DayCount dayCount)
    {
        _shelf.InitializeBooks(_shelf._shelfSo[(int)dayCount]);
        _allOrders.SetOrders(_allOrderSo);
    }

    public void CreateBoxForOrder(OrderSO orderSo)
    {
        box = null;
        box= Instantiate(boxPrefab, boxPosituin.transform.position, Quaternion.identity);
       box.GetComponent<BoxItem>().CreateBox(orderSo);

    }

}
