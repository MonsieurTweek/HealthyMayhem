using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public Customer m_Customer;
    public Recipe m_Recipe;

    [HideInInspector]
    public GameController m_GameController;

    [HideInInspector]
    public GameObject m_HUD_Order_Customer;
    [HideInInspector]
    public GameObject m_HUD_Order_Recipe;

    // Start is called before the first frame update
    void Start()
    {
        Customer newCustomer = Instantiate(m_Customer);
        Recipe newRecipe = Instantiate(m_Recipe);

        // Update UI
        Debug.Log(newRecipe);
        foreach(KeyValuePair<Ingredient, int> element in newRecipe.m_Ingredients)
        {
            m_GameController.SetInputCounterValue(element.Key.m_IngredientName, 0, element.Value);
        }
        m_GameController.SetInputCounterValue("ingredient_bell", 0, 1);
        m_GameController.SetInputCounterValue("shaker", 0, newRecipe.m_ShakeTime);
        m_GameController.SetInputCounterValue("topping_bell", 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
