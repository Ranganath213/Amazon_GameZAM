using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllOrders : MonoBehaviour
{
    public AllOrderSO allOrderSo;
    public GameObject orderInformationPrefab;
    public Canvas uiCanvas; // Reference to your Canvas with the UI Panel

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
    

    void Start()
    {
        // Set initial cursor visibility based on the initial state of the canvas
        UpdateCursorVisibility();
    }

    public void UpdateCursorVisibility()
    {
        if (uiCanvas != null && uiCanvas.enabled)
        {
            Cursor.visible = true; // Show the cursor
            Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        }
        else
        {
            Cursor.visible = false; // Hide the cursor
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        }
    }

    // Call this method when you show or hide the canvas
    public void SetCanvasActive(bool isActive)
    {
        if (uiCanvas != null)
        {
            uiCanvas.enabled = isActive;
            UpdateCursorVisibility();
        }
    }


}
