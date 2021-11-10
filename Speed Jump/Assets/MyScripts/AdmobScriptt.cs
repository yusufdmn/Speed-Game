using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;
using System;

public class AdmobScriptt : MonoBehaviour
{
    private int loadTry;
    private InterstitialAd interstitial;
    private string adUnitId;
    void Start()
    {
        loadTry = 0;
        adUnitId = "ca-app-pub-2309141602496848/2936761437";

        MobileAds.Initialize(initStatus => { });

        this.RequestInterstitial();

    }


    private void RequestInterstitial()
    {


        if (interstitial != null)
        {
            interstitial.Destroy();
        }

        this.interstitial = new InterstitialAd(adUnitId);


        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();


        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);

    }

    public void ShowAds()
    {

        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }


    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        SceneManager.LoadScene(0);
        MonoBehaviour.print("HandleAdClosed event received");
    }


    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLoaded event received");
    }


    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        loadTry++;
        if(loadTry < 5)
        {
            AdRequest request = new AdRequest.Builder().Build();

            this.interstitial.LoadAd(request);
        }
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.LoadAdError);
    }


}
