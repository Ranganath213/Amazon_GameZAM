using System;
using System.Collections;
using System.Collections.Generic;
using GameEnum;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private ShelfItem _shelf;
    [SerializeField] private AllOrders _allOrders;
    [SerializeField] private AllOrderSO _allOrderSo;

    private void Start()
    {
        Day1System(DayCount.Day1);
    }

    public void Day1System(DayCount dayCount)
    {
        _shelf.InitializeBooks(_shelf._shelfSo[(int)dayCount]);
        _allOrders.SetOrders(_allOrderSo);
    }

}
