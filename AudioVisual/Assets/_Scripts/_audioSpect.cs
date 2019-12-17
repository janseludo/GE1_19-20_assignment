using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _audioSpect : MonoBehaviour
{
    // 
    private float[] m_audioSpectrum;
    
    // This value served to AudioSyncer for beat extraction
    public static float spectrumValue
    {
        get; private set;
    }

    private void Update()
    {
        // get the data
        AudioListener.GetSpectrumData(m_audioSpectrum, 0, FFTWindow.Blackman);

        if (m_audioSpectrum != null && m_audioSpectrum.Length > 0)
        {
            spectrumValue = m_audioSpectrum[0] * 100;
        }
    }
    private void Start()
    {
        //initialize buffer
        m_audioSpectrum = new float[128];
    }
    
    

}