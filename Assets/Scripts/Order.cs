using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    public Customer m_Customer;
    [HideInInspector]
    public Customer m_CustomerClone;
    public Recipe m_Recipe;
    [HideInInspector]
    public Recipe m_RecipeClone;
    public Dictionary<Ingredient, int> m_IngredientsDone = new Dictionary<Ingredient, int>();
    public Dictionary<Ingredient, int> m_InputsIngredient = new Dictionary<Ingredient, int>();
    public Dictionary<Topping, int> m_ToppingsDone = new Dictionary<Topping, int>();
    public Dictionary<Topping, int> m_InputsTopping = new Dictionary<Topping, int>();
    public string m_Status = "waiting";
    public int m_Step = 0;

    public float m_Shaking = 0;
    public RecipeAsset recipe = null;

    [HideInInspector]
    public GameController m_GameController;
    [HideInInspector]
    public AudioManager m_GameControllerAudioManager;

    [HideInInspector]
    public GameObject m_HUD_Order_Customer;
    [HideInInspector]
    public GameObject m_HUD_Order_Recipe;

    private int _previousShakingTime;

    // Start is called before the first frame update
    void Start()
    {

        m_GameControllerAudioManager = m_GameController.GetComponent<AudioManager>();

        m_CustomerClone = Instantiate(m_Customer);
        m_RecipeClone = Instantiate(m_Recipe);

        // Update UI
        Debug.Log(m_Recipe);
        foreach(KeyValuePair<Ingredient, int> element in m_Recipe.m_Ingredients)
        {
            m_GameController.SetInputCounterValue(element.Key.m_IngredientName, 0, element.Value);
        }
        //m_GameController.SetInputCounterValue("ingredients-bell", 0, 1);
        m_GameController.SetInputCounterValue("shaker", 0, m_Recipe.m_ShakeTime);
        //m_GameController.SetInputCounterValue("toppings-bell", 0, 1);

        foreach (var ingredient in m_Recipe.m_Ingredients) {
            m_IngredientsDone.Add(ingredient.Key, 0);
            m_InputsIngredient.Add(ingredient.Key, ingredient.Key.m_NbInput);
        }

        foreach (Topping topping in m_Recipe.m_Toppings) {
            m_ToppingsDone.Add(topping, 0);
            m_InputsTopping.Add(topping, topping.m_NbInput);

            m_GameController.SetInputCounterValue(topping.m_ToppingName, 0, 1);
        }

        _previousShakingTime = -1;

        m_GameController.m_CurrentState = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Ingredient ingredient;

       if (m_Step == 0) {
            m_GameController.SetInputCounterValue("ingredients-bell", 0, 1);
            foreach (var ingredientInDictionary in m_Recipe.m_Ingredients) {
                ingredient = ingredientInDictionary.Key;
                if (
                    (ingredient.m_IngredientName == "banana" && Input.GetKeyDown(KeyCode.UpArrow) == true) ||
                    (ingredient.m_IngredientName == "orange" && Input.GetKeyDown(KeyCode.RightArrow) == true) ||
                    (ingredient.m_IngredientName == "carrot" && Input.GetKeyDown(KeyCode.LeftArrow) == true) ||
                    (ingredient.m_IngredientName == "apple" && Input.GetKeyDown(KeyCode.DownArrow) == true)
                ) {
                    m_InputsIngredient[ingredient]--;

                    // Play Healthy_Mayhem_Touch_SFX
                    m_GameControllerAudioManager.PlayInputSFX(AudioManager.HEALTHY_MAYHEM_TOUCH_SFX);

                    Debug.Log(m_InputsIngredient[ingredient]);

                    if (m_InputsIngredient[ingredient] == 0) {
                        m_InputsIngredient[ingredient] = ingredient.m_NbInput;
                        m_IngredientsDone[ingredient]++;

                        // Play Healthy_Mayhem_Valid_SFX
                        m_GameControllerAudioManager.PlayInputSFX(AudioManager.HEALTHY_MAYHEM_VALID_SFX);

                        Debug.Log(m_IngredientsDone[ingredient]);
                    }
                }

                m_GameController.SetInputFillerValue(ingredient.m_IngredientName, ingredient.m_NbInput - m_InputsIngredient[ingredient], ingredient.m_NbInput);
                m_GameController.SetInputCounterValue(ingredient.m_IngredientName, m_IngredientsDone[ingredient], ingredientInDictionary.Value);
            }

            if (Input.GetKey(KeyCode.Mouse0) == true) {
                m_Shaking += Time.deltaTime;

                if(Mathf.FloorToInt(m_Shaking) > _previousShakingTime)
                {
                    _previousShakingTime = Mathf.FloorToInt(m_Shaking);
                    // Play Healthy_Mayhem_Shaker_SFX
                    m_GameControllerAudioManager.PlayInputSFX(AudioManager.HEALTHY_MAYHEM_SHAKER_SFX);
                    Debug.Log(_previousShakingTime);
                }

                m_GameController.SetInputFillerValue("shaker", Mathf.FloorToInt(m_Shaking), m_Recipe.m_ShakeTime);
                m_GameController.SetInputCounterValue("shaker", Mathf.FloorToInt(m_Shaking), m_Recipe.m_ShakeTime);
            }

            if (Input.GetKeyDown(KeyCode.Space) == true && m_Step == 0)
            {
                // Play Healthy_Mayhem_CounterBell_SFX
                m_GameControllerAudioManager.PlayInputSFX(AudioManager.HEALTHY_MAYHEM_BELL_SFX);

                m_Step++;   //Player 2 send the order to Player 1
                m_GameController.SetInputCounterValue("ingredients-bell", 1, 1);
            }
        } else if (m_Step == 1) {
            m_GameController.SetInputCounterValue("toppings-bell", 0, 1);
            foreach (Topping topping in m_Recipe.m_Toppings) {
                if (
                    (topping.m_ToppingName == "quinoa" && Input.GetKeyDown(KeyCode.UpArrow) == true) ||
                    (topping.m_ToppingName == "goji" && Input.GetKeyDown(KeyCode.RightArrow) == true) ||
                    (topping.m_ToppingName == "mint" && Input.GetKeyDown(KeyCode.LeftArrow) == true)
                 ) {
                    m_InputsTopping[topping]--;

                    // Play Healthy_Mayhem_Touch_SFX
                    m_GameControllerAudioManager.PlayInputSFX(AudioManager.HEALTHY_MAYHEM_TOUCH_SFX);

                    Debug.Log(m_InputsTopping[topping]);

                    if (m_InputsTopping[topping] == 0) {
                        m_InputsTopping[topping] = topping.m_NbInput;
                        m_ToppingsDone[topping]++;

                        // Play Healthy_Mayhem_Valid_SFX
                        m_GameControllerAudioManager.PlayInputSFX(AudioManager.HEALTHY_MAYHEM_VALID_SFX);

                        Debug.Log(m_ToppingsDone[topping]);
                    }
                }

                m_GameController.SetInputFillerValue(topping.m_ToppingName, topping.m_NbInput - m_InputsTopping[topping], topping.m_NbInput);
                m_GameController.SetInputCounterValue(topping.m_ToppingName, m_ToppingsDone[topping], 1);
            }

            if (Input.GetKeyDown(KeyCode.Space) == true && m_Step == 1)
            {
                // Play Healthy_Mayhem_CounterBell_SFX
                m_GameControllerAudioManager.PlayInputSFX(AudioManager.HEALTHY_MAYHEM_BELL_SFX);

                m_Step++;   //Player 1 send the order to the customer
                m_GameController.SetInputCounterValue("toppings-bell", 1, 1);
            }
        } else if (m_Step == 2) {
            foreach (var ingredientInDictionary in m_Recipe.m_Ingredients) {
                ingredient = ingredientInDictionary.Key;
                if (m_Status != "failed" && m_IngredientsDone[ingredient] != m_Recipe.m_Ingredients[ingredient]) {
                    m_Status = "failed";
                }
                m_IngredientsDone[ingredient] = 0;
                m_InputsIngredient[ingredient] = 0;
            }

            if (m_Status != "failed" && Mathf.RoundToInt(m_Shaking) != m_Recipe.m_ShakeTime) {
                m_Status = "failed";
            }
            m_Shaking = 0;

            foreach (Topping topping in m_Recipe.m_Toppings) {
                if (m_Status != "failed" && m_ToppingsDone[topping] != 1) {
                    m_Status = "failed";
                }
                m_ToppingsDone[topping] = 0;
                m_InputsTopping[topping] = 0;
            }

            // End of the order
            // It's a fail
            bool isSuccess = (m_Status != "failed");
            float earning = (m_Status == "failed") ? 0f : m_Recipe.m_Price;
            m_GameController.DeliverOrderToCustomer(m_Recipe, isSuccess, earning);
            m_Step = 3;
        }
    }
}
