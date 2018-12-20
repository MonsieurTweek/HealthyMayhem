using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    // Constants keys
    // Inputs feedbacks
    public const int HEALTHY_MAYHEM_VALID_SFX       = 0;
    public const int HEALTHY_MAYHEM_TOUCH_SFX       = 1;
    public const int HEALTHY_MAYHEM_BELL_SFX        = 2;
    public const int HEALTHY_MAYHEM_SHAKER_SFX      = 9;
    // Order result screen
    public const int HEALTHY_MAYHEM_MONEY_SFX       = 3;
    public const int HEALTHY_MAYHEM_NO_MONEY_SFX    = 4;
    // Timer feedbacks
    public const int HEALTHY_MAYHEM_TIMER_START_SFX = 5;
    public const int HEALTHY_MAYHEM_TIMER_ALERT_SFX = 6;
    // End game screen
    public const int HEALTHY_MAYHEM_WIN_SFX         = 7;
    public const int HEALTHY_MAYHEM_FAIL_SFX        = 8;
    // Voices SFX
    public const int HEALTHY_MAYHEM_FERNAND_SFX         = 10;
    public const int HEALTHY_MAYHEM_LEOPOLD_SFX         = 11;
    public const int HEALTHY_MAYHEM_CELESTIN_SFX        = 12;
    public const int HEALTHY_MAYHEM_ARCHIBALD_SFX       = 13;
    public const int HEALTHY_MAYHEM_APPOLINNAIRE_SFX    = 14;

    public AudioSource m_AudioSourceMusic;
    public AudioSource m_AudioSourceInputSFX;
    public AudioSource m_AudioSourceVoiceSFX;

    // Clips
    // Inputs feedbacks
    [Header("----- Inputs feedbacks -----")]
    public AudioClip m_ClipValid;
    public AudioClip m_ClipTouch;
    public AudioClip m_ClipBell;
    public AudioClip m_ClipShaker;
    // Order result screen
    [Header("----- Order result screen -----")]
    public AudioClip m_ClipMoney;
    public AudioClip m_ClipNoMoney;
    // Timer feedbacks
    [Header("----- Timer feedbacks -----")]
    public AudioClip m_ClipTimerStart;
    public AudioClip m_ClipTimerAlert;
    [Header("----- End game screen -----")]
    // End game screen
    public AudioClip m_ClipWin;
    public AudioClip m_ClipFail;

    // Customers Voices
    [Header("----- Customers Voices -----")]
    public AudioClip m_ClipHipsterFernand;
    public AudioClip m_ClipHipsterLeopold;
    public AudioClip m_ClipHipsterCelestin;
    public AudioClip m_ClipHipsterArchibald;
    public AudioClip m_ClipHipsterAppolinnaire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayInputSFX(int key)
    {

        switch(key)
        {
            // Inputs feedbacks
            case HEALTHY_MAYHEM_VALID_SFX:
                m_AudioSourceInputSFX.clip = m_ClipValid;
                break;
            case HEALTHY_MAYHEM_TOUCH_SFX:
                m_AudioSourceInputSFX.clip = m_ClipTouch;
                break;
            case HEALTHY_MAYHEM_BELL_SFX:
                m_AudioSourceInputSFX.clip = m_ClipBell;
                break;
            case HEALTHY_MAYHEM_SHAKER_SFX:
                m_AudioSourceInputSFX.clip = m_ClipShaker;
                break;

            // Timer feedbacks
            case HEALTHY_MAYHEM_TIMER_START_SFX:
                m_AudioSourceInputSFX.clip = m_ClipTimerStart;
                break;
            case HEALTHY_MAYHEM_TIMER_ALERT_SFX:
                m_AudioSourceInputSFX.clip = m_ClipTimerAlert;
                break;
        }

        m_AudioSourceInputSFX.Play();
    }

    public void PlayVoiceSFX(int key)
    {
        switch(key)
        {

            // Order result screen
            case HEALTHY_MAYHEM_MONEY_SFX:
                m_AudioSourceVoiceSFX.clip = m_ClipMoney;
                break;
            case HEALTHY_MAYHEM_NO_MONEY_SFX:
                m_AudioSourceVoiceSFX.clip = m_ClipNoMoney;
                break;

            // End game screen
            case HEALTHY_MAYHEM_WIN_SFX:
                m_AudioSourceVoiceSFX.clip = m_ClipWin;
                break;
            case HEALTHY_MAYHEM_FAIL_SFX:
                m_AudioSourceVoiceSFX.clip = m_ClipFail;
                break;
        }

        m_AudioSourceVoiceSFX.Play();
    }
}
