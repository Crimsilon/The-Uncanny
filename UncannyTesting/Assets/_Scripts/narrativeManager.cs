﻿using System.Collections;
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
    public bool RyanTalkedTo;
    public bool CameraChecked;
    public bool SpraypaintReceived;
    public bool CameraSpraypainted;
    public bool CrowbarFound;
    public bool GunFound;
    public bool puzzleStart;
    public bool PotionMade;

    public GameObject puzzleVolumes;

    private void Start()
    {
        puzzleVolumes.SetActive(false);
        BouncerTalkedTo = false;
        NiftyTalkedTo = false;
        CashGrabbed = false;
        BabeFound = false;
        MagnetFound = false;
        KeyFound = false;
        VolumeDown = false;
        JulietTalkedTo = false;
        RyanTalkedTo = false;
        CameraChecked = false;
        SpraypaintReceived = false;
        CameraSpraypainted = false;
        CrowbarFound = false;
        GunFound = false;
        puzzleStart = false;
        PotionMade = false;
    }

    public void Update()
    {
        if (puzzleStart == true)
        {
            puzzleVolumes.SetActive(true);
        }
    }
}
