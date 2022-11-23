using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : Singleton<AdManager>, IUnityAdsListener
{
    [SerializeField] private string _id = "5001671";
    [SerializeField] private string _placementId;

    [Header("ReWarded")]
    [SerializeField] private int _coinsSkip;
    [SerializeField] private int _coinsFinish;

    

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(_id);
    }

    public void PlayRewardedAd(string id)
    {
        _placementId = id;
        if (!Advertisement.IsReady()) return;

        Advertisement.Show(_placementId);
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad Ready");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Ad Error");
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Start");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("Ad Finish");
        if(_placementId == "Rewarded_Android")
        {
            switch (showResult)
            {
                case ShowResult.Failed:
                    Debug.Log("Ad Failed");
                    break;
                case ShowResult.Skipped:
                    CoinManager.Instance.AddMuchCoins(_coinsSkip);
                    break;
                case ShowResult.Finished:
                    CoinManager.Instance.AddMuchCoins(_coinsFinish);
                    break;
                default:
                    break;
            }
        }

        if (_placementId == "Rewarded_Stamina")
        {
            switch (showResult)
            {
                case ShowResult.Failed:
                    Debug.Log("Ad Failed");
                    break;
                case ShowResult.Skipped:
                    Debug.Log("Ad Skip");
                    break;
                case ShowResult.Finished:
                    StaminaManager.Instance.AddStamina(1);
                    break;
                default:
                    break;
            }
        }


    }
}
