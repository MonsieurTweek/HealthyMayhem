using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{

    public SpriteRenderer m_BtnAction1, m_BtnAction2, m_BtnAction3, m_BtnAction4;


    // Start is called before the first frame update
    void Start()
    {
        m_BtnAction1.color = Color.red;
        m_BtnAction2.color = Color.red;
        m_BtnAction3.color = Color.red;
        m_BtnAction4.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Action1") == true)
        {
            m_BtnAction1.color = Color.green;
        } else
        {
            m_BtnAction1.color = Color.red;
        }


        if (Input.GetButton("Action2") == true)
        {
            m_BtnAction2.color = Color.green;
        }
        else
        {
            m_BtnAction2.color = Color.red;
        }


        if (Input.GetButton("Action3") == true)
        {
            m_BtnAction3.color = Color.green;
        }
        else
        {
            m_BtnAction3.color = Color.red;
        }


        if (Input.GetButton("Action4") == true)
        {
            m_BtnAction4.color = Color.green;
        }
        else
        {
            m_BtnAction4.color = Color.red;
        }
    }
}
