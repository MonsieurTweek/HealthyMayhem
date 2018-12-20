using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public string m_CustomerName;
    public int m_Timer;
    public Sprite m_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        source.PlayDelayed(Random.Range(2f, 4f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
