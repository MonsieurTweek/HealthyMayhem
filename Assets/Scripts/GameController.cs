using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Order> m_Orders;
    public int m_CurrentOrder = 0;
    public GameObject m_HUD_Order_Recipe;
    public GameObject m_HUD_Order_Customer;


    // Start is called before the first frame update
    void Start()
    {
        GenerateOrder();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateOrder()
    {
        Order newOrder = Instantiate(m_Orders[m_CurrentOrder]);
        m_HUD_Order_Recipe.GetComponent<SpriteRenderer>().sprite = newOrder.m_Recipe.m_Sprite;
        m_HUD_Order_Customer.GetComponent<SpriteRenderer>().sprite = newOrder.m_Customer.m_Sprite;
        m_CurrentOrder++;
    }
}
