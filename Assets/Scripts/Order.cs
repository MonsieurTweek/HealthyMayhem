using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public Customer m_Customer;
    public Recipe m_Recipe;

    [HideInInspector]
    public GameObject m_HUD_Order_Customer;
    [HideInInspector]
    public GameObject m_HUD_Order_Recipe;

    // Start is called before the first frame update
    void Start()
    {
        Customer newCustomer = Instantiate(m_Customer);
        Recipe newRecipe = Instantiate(m_Recipe);
        /*
        Vector2 defaultPosition = new Vector2(0,0);
        newCustomer.transform.parent = m_HUD_Order_Customer.transform;
        newCustomer.transform.position = defaultPosition;
        newRecipe.transform.parent = m_HUD_Order_Recipe.transform;
        newRecipe.transform.position = defaultPosition;
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
