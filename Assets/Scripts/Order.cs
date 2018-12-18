using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public Customer m_Customer;
    public Recipe m_Recipe;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(m_Customer);
        Instantiate(m_Recipe);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
