using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeAsset : ScriptableObject
{
    public string m_RecipeName;
    public float m_Price;
    public List<Ingredient> m_IngredientList;
    public List<int> m_NbIngredient;
    public int m_ShakeTime;
    public List<Topping> m_Toppings;
    public Sprite m_Sprite;
}
