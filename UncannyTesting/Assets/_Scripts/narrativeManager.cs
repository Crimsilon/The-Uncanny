using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class narrativeManager : MonoBehaviour {

    public bool BouncerTalkedTo;
    public bool NiftyTalkedTo;
    public bool CashGrabbed;
    public bool BabeFound;
    public bool MagnetFound;
    public bool KeyFound;
    public bool VolumeDown;
    public bool JulietTalkedTo;
    public bool CodeFound;

    private void Start()
    {
        BouncerTalkedTo = false;
        NiftyTalkedTo = false;
        CashGrabbed = false;
        BabeFound = false;
        MagnetFound = false;
        KeyFound = false;
        VolumeDown = false;
        JulietTalkedTo = false;
        CodeFound = false;
    }
}
