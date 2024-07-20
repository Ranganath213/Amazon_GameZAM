using System;
using System.Collections;
using System.Collections.Generic;
using GameEnum;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private ShelfItem _shelf;

    private void Start()
    {
        Day1System(DayCount.Day1);
    }

    public void Day1System(DayCount dayCount)
    {
        _shelf.InitializeBooks(_shelf._shelfSo[(int)dayCount]);
    }

}
