using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe : MonoBehaviour, ISerializationCallbackReceiver
{
    public string m_RecipeName;
    public float m_Price;
    public List<Ingredient> m_IngredientList;
    public List<int> m_NbIngredient;
    public Dictionary<Ingredient, int> m_Ingredients;
    public int m_ShakeTime;
    public List<Topping> m_Toppings;
    public Sprite m_Sprite;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeforeSerialize() {
        this.m_IngredientList.Clear();
        this.m_NbIngredient.Clear();

        foreach(var kvp in m_Ingredients) {
            m_IngredientList.Add(kvp.Key);
            m_NbIngredient.Add(kvp.Value);
        }
    }

    public void OnAfterDeserialize() {
        m_Ingredients = new Dictionary<Ingredient, int>();

        for(int i = 0; i != Mathf.Min(m_IngredientList.Count, m_NbIngredient.Count); i++) {
            m_Ingredients.Add(m_IngredientList[i], m_NbIngredient[i]);
        }
    }
}
