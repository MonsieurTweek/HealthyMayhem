﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Order> m_Orders;
    public int m_CurrentOrder = 0;

    // HUD
    [Header("----- HUD -----")]
    public GameObject m_Order_Recipe;
    public GameObject m_Order_Customer;

    // Texts Controllers
    [Header("----- Texts Controllers -----")]
    public List<UITextController> m_TextsUI;

    // Start is called before the first frame update
    void Start()
    {
        // Init UI texts
        foreach(UITextController textController in m_TextsUI)
        {
            textController.ResetCounterToDefault();
        }

        GenerateOrder();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateOrder()
    {
        Order newOrder = Instantiate(m_Orders[m_CurrentOrder]);
        m_CurrentOrder++;

        // Game Controller
        newOrder.m_GameController = this;

        // HUD Position
        m_Order_Recipe.GetComponent<SpriteRenderer>().sprite = newOrder.m_Recipe.m_Sprite;
        m_Order_Customer.GetComponent<SpriteRenderer>().sprite = newOrder.m_Customer.m_Sprite;

    }

    public void SetInputCounterValue(string key, int current, int target)
    {
        foreach (UITextController textController in m_TextsUI)
        {
            if(textController.m_QualifiedName == key)
            {
                textController.SetCounter(current, target);
            }
        }
    }
}
