using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResultScreenController : MonoBehaviour
{

    public Image m_Image;
    public Text m_Text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowResultScreen()
    {
        gameObject.SetActive(true);
    }

    public void HideResultScreen()
    {
        gameObject.SetActive(false);
    }

    public void UpdateImage(Sprite sprite) {
        m_Image.sprite = sprite;
    }

    public void UpdateText(float price) {
        m_Text.text = price.ToString("F") + "€";
    }
}
