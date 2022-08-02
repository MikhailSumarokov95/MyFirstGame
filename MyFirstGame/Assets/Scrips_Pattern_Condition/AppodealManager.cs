//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using AppodealAds.Unity.Api;
//using AppodealAds.Unity.Common;
//using UnityEngine.UI;

//public class AppodealManager : MonoBehaviour, IRewardedVideoAdListener
//{
//    private const string APP_KEY = "";

//    [SerializeField] private bool _testingMode;
//    [SerializeField] private int _score;
//    [SerializeField] private Text _scoreText;

//    private void Start()
//    {
//        this.Initialized();
//    }

//    public void ShowInterAds()
//    {
//        if (Appodeal.canShow(Appodeal.INTERSTITIAL)) 
//            Appodeal.show(Appodeal.INTERSTITIAL);
//    }

//    public void ShowRewardedAds()
//    {
//        if (Appodeal.canShow(Appodeal.REWARDED_VIDEO))
//            Appodeal.show(Appodeal.REWARDED_VIDEO);
//    }

//    private void UpdateScore()
//    {
//        _scoreText.text = _score.ToString();
//    }

//    private void Initialized()
//    {
//        Appodeal.setTesting(_testingMode);
//        Appodeal.disableLocationPermissionCheck();
//        Appodeal.muteVideosIfCallsMuted(true);
//        Appodeal.initialize(APP_KEY, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
//        Appodeal.setRewardedVideoCallbacks(this);
//    }

//    #region RewardedVideosCallBack
//    public void onRewardedVideoLoaded(bool isPrecache)
//    {
//        print("Video loaded");   
//    }

//    public void onRewardedVideoFailedToLoad()
//    {
//        print("Video failde");
//    }

//    public void onRewardedVideoShowFailed()
//    {
//        print("Video show filed");
//    }

//    public void onRewardedVideoShown()
//    {
//        print("Video shown");
//    }

//    public void onRewardedVideoClicked()
//    {
//        print("Video clicked");
//    }

//    public void onRewardedVideoClosed(bool finished)
//    {
//        print("Video closed");
//    }

//    public void onRewardedVideoFinished(double amount, string name)
//    {
//        _score++;
//        UpdateScore();
//    }

//    public void onRewardedVideoExpired()
//    {
//        print("Video expired");
//    }

//    #endregion
//}
