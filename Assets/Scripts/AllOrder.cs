using System.Collections.Generic;
using GameEnum;
using UnityEngine;

[CreateAssetMenu(fileName = "All Orders",menuName = "DayOrderDetails")]
public class AllOrderSO : ScriptableObject
{
    [SerializeField] public DayCount currentDay;
    [SerializeField] public List<OrderSO> orders;
    
    
}