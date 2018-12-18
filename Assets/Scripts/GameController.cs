using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public List<Order> m_Orders;
    public int m_CurrentOrder = 0;

    // Start is called before the first frame update
    void Start()
    {
        GenerateOrder();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateOrder() {
        Instantiate(m_Orders[m_CurrentOrder]);
        m_CurrentOrder++;
    }
}
