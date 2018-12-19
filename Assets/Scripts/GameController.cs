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
    public Canvas m_CanvasIngredients;
    public GameObject m_Order_Recipe;
    public GameObject m_Order_Customer;

    // Texts Controllers
    [Header("----- Texts Controllers -----")]
    public List<UIIngredientController> m_IngredientsUI;

    // Results screens
    [Header("----- Result Screens -----")]
    public UIResultScreenController m_ResultScreenSuccess;
    public UIResultScreenController m_ResultScreenFail;
    public UIResultScreenController m_ResultScreenInstance;
    // States
    // 0 - Start Screen
    // 1 - Customer waiting
    // 2 - Order result screen
    // 3 - End game screen
    public int m_CurrentState;

    // Start is called before the first frame update
    void Start()
    {

        m_CurrentState = 1;

        // Init UI texts
        foreach (UIIngredientController controller in m_IngredientsUI)
        {
            controller.ResetCounterToDefault();
        }

        GenerateOrder();
    }

    // Update is called once per frame
    void Update()
    {        
        switch(m_CurrentState)
        {
            case 1 :
                if(Input.GetKeyDown(KeyCode.F1))
                {
                    ShowResultScreen(true);
                } else if(Input.GetKeyDown(KeyCode.F2))
                {
                    ShowResultScreen(false);
                }
                break;

            case 2 :
                if(Input.GetKeyDown(KeyCode.F5))
                {
                    HideResultScreen();
                }
                break;
        }
    }

    public void ShowResultScreen(bool success)
    {
        if(success == true)
        {
            m_ResultScreenInstance = Instantiate(m_ResultScreenSuccess);
        } else
        {
            m_ResultScreenInstance = Instantiate(m_ResultScreenFail);
        }

        m_ResultScreenInstance.gameObject.SetActive(true);
        m_CanvasIngredients.gameObject.SetActive(false);
        m_CurrentState = 2;
    }

    public void HideResultScreen()
    {
        Destroy(m_ResultScreenInstance.gameObject);
        m_CanvasIngredients.gameObject.SetActive(true);
        m_CurrentState = 1;
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
        foreach (UIIngredientController controller in m_IngredientsUI)
        {
            if(controller.m_QualifiedName == key)
            {
                controller.SetCounter(current, target);
            }
        }
    }

    public void SetInputFillerValue(string key, int current, int max)
    {
        foreach (UIIngredientController controller in m_IngredientsUI)
        {
            if (controller.m_QualifiedName == key)
            {
                controller.SetFiller(current, max);
            }
        }
    }
}
