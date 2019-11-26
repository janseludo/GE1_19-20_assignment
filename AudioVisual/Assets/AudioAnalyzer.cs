using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioAnalyzer : MonoBehaviour
{
    //Variables
   
    AudioSource a;

    public static int frameSize = 512;
    public static float[] spectrum;
    public static float[] bands;

    public float bidWidth;
    public float sampleRate;

    /*
     * 
     * 20-60
     * 60-250
     * 250-500
     * 500-2khz
     * 2khz-4khz
     * 4khz-6khz
     * 6khz-20khz
     * 
     */

    //Awake is used to inistialize any variables or game state before the game starts.
    //awake is called only once during the lifetime of the script instance.
    //awake is called after all objects are initialized so you can safely speake to the other objects or queary them usin
    //for example GameObject.FindWithTag
    private void Awake()
    {
        //get audio source and store it in - a
        a = GetComponent<AudioSource>();
        spectrum = new float[frameSize];
        bands = new float[(int)Mathf.Log(frameSize, 2)];

        a.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        sampleRate = AudioSettings.outputSampleRate;
        bidWidth = AudioSettings.outputSampleRate / 2 / frameSize;
    }
    //Bryan Duggan's version of gettign the frequency bands
    void GetFrequencyBands()
    {
        for(int i = 0; i < bands.Length; i++)
        {
            int start = (int)Mathf.Pow(2, i) - 1;
            int width = (int)Mathf.Pow(2, i);
            int end = start + width;
            float average = 0;

            for(int j = start; j < end; j++)
            {
                average += spectrum[j] * (j + 1);

            }
            average /= (float) width;
            bands[i] = average;
            //Debug.Log(i + "\t" + start + "\t" + end + "\t" + start * bidWidth + "\t" + (end * bidWidth));
        }
    }

    // Update is called once per frame
    void Update()
    {
        a.GetSpectrumData(spectrum, 0, FFTWindow.Blackman);
        GetFrequencyBands();
    }
}
