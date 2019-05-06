using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Osborne_AudioManager_CyberpunkNoir : MonoBehaviour
{

    public AudioSource clubSource;
    public AudioSource ambSource;
    public AudioSource extraMusicSource;

    public AudioClip clubLoop;
    public AudioClip bathroomAmbience;
    public AudioClip defaultAmbience;
    public AudioClip sewerAmbience;
    public AudioClip sewerMusic;
    public AudioClip sneakingMusic;

    public int whichLevelOfMuffling;
    AudioMixerSnapshot[] mufflingLayer = new AudioMixerSnapshot[4];

    public AudioMixerSnapshot notMuffled;
    public AudioMixerSnapshot bitMuffled;
    public AudioMixerSnapshot veryMuffled;
    public AudioMixerSnapshot completelyMuffled;
    public AudioMixerSnapshot ambOnSnap;
    public AudioMixerSnapshot ambOffSnap;
    public AudioMixerSnapshot extraMusicSnapOn;
    public AudioMixerSnapshot extraMusicSnapOff;

    public string whichAmbience;

    public float clubFadeDownTime;
    public float clubFadeUpTime;
    public float ambFadeOutTime;
    public float ambFadeInTime;
    public float extraMusicFadeOutTime;
    public float extraMusicFadeInTime;

    // Start is called before the first frame update
    void Start()
    {
        mufflingLayer[0] = notMuffled;
        mufflingLayer[1] = bitMuffled;
        mufflingLayer[2] = veryMuffled;
        mufflingLayer[3] = completelyMuffled;
        whichLevelOfMuffling = 2;
        StartClubMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartClubMusic()
    {
        Debug.Log("Begin plz work");
        mufflingLayer[whichLevelOfMuffling].TransitionTo(0);
        ambOffSnap.TransitionTo(0);
        clubSource.clip = clubLoop;
        clubSource.loop = true;
        clubSource.Play();
        Debug.Log("Please work");
    }

    public void AmbienceRoom()
    {
        if(whichLevelOfMuffling != 3)
        {
            extraMusicSnapOff.TransitionTo(extraMusicFadeOutTime); 
        }
        mufflingLayer[whichLevelOfMuffling].TransitionTo(clubFadeDownTime);
        if (whichAmbience == "default")
        {
            ambSource.clip = defaultAmbience;
        }
        else if (whichAmbience == "bathroom")
        {
            ambSource.clip = bathroomAmbience;
        }
        else if (whichAmbience == "sewer")
        {
            ambSource.clip = sewerAmbience;
        }
        else
        {
            Debug.Log("you're probably playing the wrong ambience.");
        }
        //play that ambience
        ambSource.loop = true;
        ambSource.Play();
        ambOnSnap.TransitionTo(ambFadeInTime);
    }

    public void NonAmbienceRoom()
    {
        if (whichLevelOfMuffling != 3)
        {
            extraMusicSnapOff.TransitionTo(extraMusicFadeOutTime);
        }
        ambOffSnap.TransitionTo(ambFadeOutTime);
        mufflingLayer[whichLevelOfMuffling].TransitionTo(clubFadeDownTime);
    }

    public void DefaultAmbience()
    {
        whichAmbience = "default";
    }

    public void BathroomAmbience()
    {
        whichAmbience = "bathroom";
    }

    public void SewerAmbienceAndMusic()
    {
        whichAmbience = "sewer";

        //turn off all other music by transitioning to silence
        CompletelyMuffled();
        mufflingLayer[whichLevelOfMuffling].TransitionTo(clubFadeDownTime);

        //turn on the sewer ambience
        AmbienceRoom();

        //play the sewer music
        extraMusicSource.clip = sewerMusic;
        extraMusicSource.loop = true;
        extraMusicSource.Play();
        //make sure to fade in the music again
        extraMusicSnapOn.TransitionTo(extraMusicFadeInTime);
    }

    public void SneakingRoom()
    {
        //turn off any extra ambiences that have been left on
        ambOffSnap.TransitionTo(ambFadeOutTime);

        //turn off all club music, just in case
        CompletelyMuffled();
        mufflingLayer[whichLevelOfMuffling].TransitionTo(clubFadeDownTime);

        //play the sneaky music
        extraMusicSource.clip = sneakingMusic;
        extraMusicSource.loop = true;
        extraMusicSource.Play();
        //make sure to fade in the music again
        extraMusicSnapOn.TransitionTo(extraMusicFadeInTime);
    }


    public void NotMuffled()
    {
        whichLevelOfMuffling = 0;
    }

    public void BitMuffled()
    {
        whichLevelOfMuffling = 1;
    }

    public void VeryMuffled()
    {
        whichLevelOfMuffling = 2;
    }

    public void CompletelyMuffled()
    {
        whichLevelOfMuffling = 3;
    }

}
