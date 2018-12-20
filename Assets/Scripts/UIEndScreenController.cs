using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEndScreenController : MonoBehaviour
{
    public Image m_ImageFail;
    public Image m_ImageSuccess;
    public Text m_TextResults;
    public Text m_TextTotal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateImage(float price) {
        if(price > 0) {
            m_ImageFail.gameObject.SetActive(false);
        } else {
            m_ImageSuccess.gameObject.SetActive(false);
        }
    }

    public void UpdateText(string results, string total) {
        m_TextResults.text = results;
        m_TextTotal.text = total;
    }
}
