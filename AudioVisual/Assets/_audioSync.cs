using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class _audioSync : MonoBehaviour
{
    public float bias;          //what spectrum value to trigger a beat
    public float timeStep;      //determins the minim interval between each beat
    public float timeToBeat;    //how much time between the visualization completes
    public float restSmoothTime;//how fast the object goes to rest after a beat

    //if the value went above or below the value 
    //during the current frame, thus triggereing a beat
    private float m_previousAudioValue;
    private float m_audioValue;

    private float m_timer;      //to keep strack of the time step interval
    protected bool m_isBeat;    //bool to determin if the sync object in in a beat state

    // Inherit this to cause some behavior on each beat
    public virtual void OnBeat()
    {
        //Debug.Log("beat");
        m_timer = 0;
        m_isBeat = true;
    }

    //subclasses to inject thier own update
    //without completely overwriting the base class
    public virtual void OnUpdate()
    {
        // update audio value
        m_previousAudioValue = m_audioValue;
        m_audioValue = _audioSpect.spectrumValue;

        // if audio value went below the bias during this frame
        if (m_previousAudioValue > bias && m_audioValue <= bias)
        {
            // if minimum beat interval is reached
            if (m_timer > timeStep)
                OnBeat();
        }

        // if audio value went above the bias during this frame
        if (m_previousAudioValue <= bias &&  m_audioValue > bias)
        {
            // if minimum beat interval is reached
            if (m_timer > timeStep)
                OnBeat();
        }
        m_timer += Time.deltaTime;
    }
    public void Update()
    {
        OnUpdate();
    }
}
