using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class narrativeManager : MonoBehaviour {

    public bool VolumeDown;
    public bool MagnetFound;
    public bool KeyFound;
    public bool CodeFound;

    private void Start()
    {
        VolumeDown = false;
        MagnetFound = false;
        KeyFound = false;
        CodeFound = false;
    }
}
