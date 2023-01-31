using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener, IUnityAdsInitializationListener
{
    [SerializeField] bool testMode = true;
    public static AdManager instance;
    GameOverHandler gameOverHandler;

#if UNITY_ANDROID 
    string gameId = "5144129";
#elif UNITY_IOS
    sting gameId = "5144128";
#endif
    

    void Awake() {
        ManageSingleton();
    }
    void ManageSingleton(){
        if(instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.Initialize(gameId, testMode, this);
        }
    }
   
    public void ShowAd(GameOverHandler gameOverHandler){
        this.gameOverHandler = gameOverHandler;

        Advertisement.Load(gameId, this);
    }
    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show("rewardedVideo", this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Continue Button Pressed");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Advertisement.Load("rewardedVideo", this);
        switch(showCompletionState){
            case UnityAdsShowCompletionState.COMPLETED:
                //gameOverHandler.ContinueGame();
                break;
            case UnityAdsShowCompletionState.SKIPPED:
                //Ad was skipped
                break;
            case UnityAdsShowCompletionState.UNKNOWN:
                Debug.Log("Warning! Ad Failed");
                break;
        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Ad Initialized");
    }
     public void OnInitializationComplete()
    {
        Advertisement.Load("rewardedVide",this);
        Debug.Log("Initialization Complete");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Initialization Failed: {message}");
    }

   
}
