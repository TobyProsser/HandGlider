﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdController : MonoBehaviour
{
    public static AdController AdInstance;

    private string AppleStore_ID = "3720212";
    private string GoogleStore_ID = "3720213";

    private string video_ad = "video";
    private string rewarded_video_ad = "rewardedVideo";
    private string banner_ad = "banner";

    private bool TestMode = true; //Turn to false when not testing

    private void Awake()
    {
        if (AdInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            AdInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer &&
            Application.platform != RuntimePlatform.OSXPlayer)
        {
            Advertisement.Initialize(GoogleStore_ID, TestMode); //Turn to false when not testing
        }
        else
        {
            Advertisement.Initialize(AppleStore_ID, TestMode); //Turn to false when not testing
        }
    }

    public void ShowAd(string p)
    {
        Advertisement.Show(p);
    }

    public void ShowBannerAd(string p)
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        Advertisement.Show(p);
    }
}
