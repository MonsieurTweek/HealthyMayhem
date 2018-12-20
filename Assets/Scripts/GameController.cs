using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Healthy.Enums;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public List<Order> m_Orders;
    public int m_CurrentOrder = 0;
    public List<float> m_Results;
    public Order _currentOrderInstance;

    private float _currentTime = 0f;
    private float _startingTime;
    private bool _timerAlertPlayed = false;

    // HUD
    [Header("----- HUD -----")]
    public Canvas m_CanvasIngredients;
    public Canvas m_CanvasTimer;
    public GameObject m_Order_Recipe;
    public GameObject m_Order_Customer;
    public Text m_CountdownText;
    public GameObject m_rootHUD;


    // Texts Controllers
    [Header("----- Texts Controllers -----")]
    public List<UIIngredientController> m_IngredientsUI;

    // Results screens
    [Header("----- Result Screens -----")]
    public UIResultScreenController m_ResultScreenSuccess;
    public UIResultScreenController m_ResultScreenFail;
    public UIResultScreenController m_ResultScreenInstance;

    //End screen
    [Header("----- End Screen -----")]
    public UIEndScreenController m_EndScreen;
    public UIEndScreenController m_EndScreenInstance;

    // States
    // 0 - Start Screen
    // 1 - Customer waiting
    // 2 - Order result screen
    // 3 - End game screen
    public int m_CurrentState;

    private AudioManager _GameControllerAudioManager;

    // Start is called before the first frame update
    void Start()
    {
        _GameControllerAudioManager = GetComponent<AudioManager>();
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
                // Update timer
                _currentTime -= 1 * Time.deltaTime;
                m_CountdownText.text = _currentTime.ToString("0");

                if (_currentTime <= 10)
                {
                    // Play Healthy_Mayhem_Timer_Alert_SFX
                    _GameControllerAudioManager.PlayInputSFX(AudioManager.HEALTHY_MAYHEM_TIMER_ALERT_SFX);
                    _timerAlertPlayed = true;
                }

                if (_currentTime <= 0)
                {
                    DeliverOrderToCustomer(_currentOrderInstance.m_Recipe, false, 0f);
                }

                break;

            case 2:

                if (Input.GetKeyDown(KeyCode.Space) == true)
                {
                    //Start next customer
                    Debug.Log(m_CurrentOrder);
                    Debug.Log(m_Orders.Count);

                    // Play Healthy_Mayhem_CounterBell_SFX
                    _GameControllerAudioManager.PlayInputSFX(AudioManager.HEALTHY_MAYHEM_BELL_SFX);
                    DestroyOrder(_currentOrderInstance);

                    if (m_CurrentOrder < m_Orders.Count)
                    {
                        GenerateOrder();
                        HideResultScreen();
                    }
                    else
                    {                        
                        ShowEndScreen(m_Results);
                        m_CurrentState = 3;
                    }
                }
                break;

            case 3:

                if (Input.GetKeyDown(KeyCode.Space) == true) {
                    SceneManager.LoadScene((int)SceneEnum.START);
                }
                break;
        }
    }

    public void ShowResultScreen(bool success, Recipe recipe)
    {
        if (success == true) {
            m_ResultScreenInstance = Instantiate(m_ResultScreenSuccess);
            m_ResultScreenInstance.UpdateImage(recipe.m_Sprite);
            m_ResultScreenInstance.UpdateText(recipe.m_Price);
            // Play Healthy_Mayhem_Money_SFX
            _GameControllerAudioManager.PlayVoiceSFX(AudioManager.HEALTHY_MAYHEM_MONEY_SFX);
        } else
        {
            m_ResultScreenInstance = Instantiate(m_ResultScreenFail);
            // Play Healthy_Mayhem_0$_SFX
            _GameControllerAudioManager.PlayVoiceSFX(AudioManager.HEALTHY_MAYHEM_NO_MONEY_SFX);
        }

        m_ResultScreenInstance.gameObject.SetActive(true);
        m_CanvasIngredients.gameObject.SetActive(false);
        m_CanvasTimer.gameObject.SetActive(false);
        m_CurrentState = 2;
    }

    public void HideResultScreen()
    {
        Destroy(m_ResultScreenInstance.gameObject);
        m_CanvasIngredients.gameObject.SetActive(true);
        m_CanvasTimer.gameObject.SetActive(true);
        m_CurrentState = 1;
    }

    public void GenerateOrder()
    {
        ResetCounter();
        ResetInputFiller();
        _currentOrderInstance = Instantiate(m_Orders[m_CurrentOrder]);
        m_CurrentOrder++;

        // Game Controller
        _currentOrderInstance.m_GameController = this;

        // HUD Position
        m_Order_Recipe.GetComponent<SpriteRenderer>().sprite = _currentOrderInstance.m_Recipe.m_Sprite;
        m_Order_Customer.GetComponent<SpriteRenderer>().sprite = _currentOrderInstance.m_Customer.m_Sprite;

        // Reset timer
        _currentTime = _currentOrderInstance.m_Customer.m_Timer;
        _timerAlertPlayed = false;
        // Play Healthy_Mayhem_Active_Timer_SFX
        _GameControllerAudioManager.PlayInputSFX(AudioManager.HEALTHY_MAYHEM_TIMER_START_SFX);

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

    public void ResetCounter() {
        foreach (UIIngredientController controller in m_IngredientsUI) {
            controller.ResetCounterToDefault();
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

    public void ResetInputFiller() {
        foreach (UIIngredientController controller in m_IngredientsUI) {
            controller.ResetInputFillerToDefault();
        }
    }

    public void DestroyOrder(Order order) {
        Destroy(order.m_CustomerClone.gameObject);
        Destroy(order.m_RecipeClone.gameObject);
        Destroy(order.gameObject);
        //Debug.Log(order.m_Recipe);
        //Debug.Log(order.m_Customer);
    }

    public void DeliverOrderToCustomer(Recipe recipe, bool isSuccess, float earning)
    {
        Debug.Log("DeliverOrderToCustomer");
        m_Results.Add(earning);
        ShowResultScreen(isSuccess, recipe);
    }

    public void ShowHud() {
        m_CanvasIngredients.gameObject.SetActive(true);
        m_CanvasTimer.gameObject.SetActive(true);
    }

    public void HideHud() {
        m_CanvasIngredients.gameObject.SetActive(false);
        m_CanvasTimer.gameObject.SetActive(false);
        m_rootHUD.gameObject.SetActive(false);
    }

    public void ShowEndScreen(List<float> results) {

        string resultsText = "";

        float total = 0f;
        foreach(float result in results) {
            if(result == 0) {
                resultsText = resultsText + "<color=#ff4747ff>";
            } else {
                resultsText = resultsText + "<color=#00b050ff>";
            }
            resultsText = resultsText + result.ToString("F") + "€</color>\n";
            total += result;
        }

        string totalText = "";
        if(total == 0) {
            totalText = "<color=#ff4747ff>";
        } else {
            totalText = "<color=#00b050ff>";
        }

        totalText = totalText + total.ToString("F") + "€</color>";

        m_EndScreenInstance = Instantiate(m_EndScreen);
        m_EndScreenInstance.UpdateText(resultsText, totalText);
        m_EndScreenInstance.UpdateImage(total);

        m_EndScreenInstance.gameObject.SetActive(true);
        HideHud();
        Destroy(m_ResultScreenInstance.gameObject);
        m_Order_Recipe.gameObject.SetActive(false);
        m_Order_Customer.gameObject.SetActive(false);
    }
}
