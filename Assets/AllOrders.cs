using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllOrders : MonoBehaviour
{
    public AllOrderSO allOrderSo;
    public GameObject orderInformationPrefab;

    public void SetOrders(AllOrderSO allOrders)
    {
        allOrderSo = allOrders;
        foreach (var order in allOrders.orders)
        {
            GameObject orderPrefabPanel = Instantiate(orderInformationPrefab);
            orderPrefabPanel.transform.SetParent(this.gameObject.transform);
            orderPrefabPanel.GetComponent<OrderPerson>().InitializeOrderSo(order);
        }
      
        
    }


}
