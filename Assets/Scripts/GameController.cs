using System.Collections;
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

    // Canvas - Ingredients
    [Header("----- Canvas - Ingredients -----")]
    public Text m_Apple_Count_Text;
    public Text m_Banana_Count_Text;
    public Text m_Carrot_Count_Text;
    public Text m_Orange_Count_Text;
    public Text m_Shaker_Count_Text;
    public Text m_Ingredients_Bell_Count_Text;

    // Canvas - Topping
    [Header("----- Canvas - Topping -----")]
    public Text m_Quinoa_Count_Text;
    public Text m_Goji_Count_Text;
    public Text m_Mint_Count_Text;
    public Text m_Topping_Bell_Count_Text;

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
        m_CurrentOrder++;

        // Game Controller
        newOrder.m_GameController = this;

        // HUD Position
        m_Order_Recipe.GetComponent<SpriteRenderer>().sprite = newOrder.m_Recipe.m_Sprite;
        m_Order_Customer.GetComponent<SpriteRenderer>().sprite = newOrder.m_Customer.m_Sprite;

    }

    public void SetInputCounterValue(string key, int current, int max)
    {

        Text textToUpdate = null;

        switch (key)
        {
            // Ingredients
            case "apple":
                textToUpdate = m_Apple_Count_Text;
                break;
            case "banana":
                textToUpdate = m_Banana_Count_Text;
                break;
            case "carrot":
                textToUpdate = m_Carrot_Count_Text;
                break;
            case "orange":
                textToUpdate =  m_Orange_Count_Text;
                break;
            case "shaker":
                textToUpdate = m_Shaker_Count_Text;
                break;
            case "ingredient_bell":
                textToUpdate = m_Ingredients_Bell_Count_Text;
                break;

            // Topping
            case "quinoa":
                textToUpdate = m_Quinoa_Count_Text;
                break;
            case "goji":
                textToUpdate = m_Goji_Count_Text;
                break;
            case "mint":
                textToUpdate = m_Mint_Count_Text;
                break;
            case "topping_bell":
                textToUpdate = m_Topping_Bell_Count_Text;
                break;

            default:
                break;
        }

        if(textToUpdate != null)
        {
            textToUpdate.text = current + "/" + max;
            if(max == 0)
            {
                textToUpdate.color = new Color(0.65f, 0.65f, 0.65f);
            } else
            {
                if(current < max)
                {
                    textToUpdate.color = new Color(0.12f, 0.12f, 0.12f);
                } else if(current == max)
                {
                    textToUpdate.color = new Color(0f, 0.69f, 0.31f);
                } else
                {
                    textToUpdate.color = new Color(1f, 0.28f, 0.28f);
                }
            }
        }
    }
}
