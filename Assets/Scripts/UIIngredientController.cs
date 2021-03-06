﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIngredientController : MonoBehaviour
{

    public string m_QualifiedName;

    public Image m_FillerComponent;
    public Text m_TextComponent;
    public Image m_ImageComponent;

    private Color m_Green = new Color(0f, 0.69f, 0.31f);
    private Color m_Red = new Color(1f, 0.28f, 0.28f);
    private Color m_Black = new Color(0.12f, 0.12f, 0.12f);
    private Color m_Grey = new Color(0.65f, 0.65f, 0.65f);
    private Color m_Orange = new Color(0.93f, 0.43f, 0.27f);

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetCounterToDefault()
    {
        m_TextComponent.text = "-/-";
        m_TextComponent.color = m_Grey;
    }

    public void SetCounter(int current, int target)
    {
        m_TextComponent.text = current + "/" + target;
        if(current < target)
        {
            m_TextComponent.color = m_Black;
        } else if(current > target)
        {
            m_TextComponent.color = m_Red;
        } else
        {
            m_TextComponent.color = m_Green;
        }
        
    }

    public void SetCounterColor(int delta) {
        switch (delta) {
            case 1:
                m_TextComponent.color = m_Orange;
                break;

            //case 2:
                //m_TextComponent.color = m_Red;
                //break;
        }
    }

    public void ResetInputFillerToDefault() {
        m_FillerComponent.fillAmount = 0;
    }

    public void SetFiller(int current, int max)
    {
        m_FillerComponent.fillAmount = (float) current / (float) max;
    }

    public void SetFillerColor(int delta) {
        switch(delta) {
            case 1:
                m_FillerComponent.color = m_Orange;
                break;

            case 2:
                m_FillerComponent.color = m_Red;
                break;
        }
    }

}
