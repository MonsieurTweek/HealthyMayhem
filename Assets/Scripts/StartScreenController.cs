using Healthy.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenController : MonoBehaviour
{

    public AudioSource AudioSourceInputSFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            AudioSourceInputSFX.Play();
            SceneManager.LoadScene((int)SceneEnum.GAME);
        }
    }
}
