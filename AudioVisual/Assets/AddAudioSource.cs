using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAudioSource : MonoBehaviour
{
    AudioSource m_MyAudioSource;

    //Play music
    bool m_Play;

    //detect when you use the toggle, ensure music isn't played multiple times
    bool m_ToggleChange;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Audiosource from the game object
        m_MyAudioSource = GetComponent<AudioSource>();
        //ensure the toggle is set to true for the music to play at start up
        m_Play = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        //check to see if you just set the togglw to positive
        if (m_Play == true && m_ToggleChange == true)
        {
            //play the audio you attatch to the audiosource component
            m_MyAudioSource.Play();
            //ensure audio doesn't play more than once
            m_ToggleChange = false;

        }
        //checl if you just set the toggle to flase
        if(m_Play == false && m_ToggleChange == true)
        {
            //Stop the Audio
            m_MyAudioSource.Stop();
            //ensure audio doesn't play more than once
            m_ToggleChange = false;

        }
    }
   
    //
    void OnGUI()
    {
        //Switch this to activate and deactivate the parent GameObject
        m_Play = GUI.Toggle(new Rect(10,10,100,30),m_Play, "Play Music");

        //Detect if there is a change with the toggle
        if(GUI.changed)
        {
            //change to true to show that there was just a change in the toggle state
            m_ToggleChange = true;

        }
    }

}
