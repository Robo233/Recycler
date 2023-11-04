using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;


public class AdsManager : MonoBehaviour, IUnityAdsListener
{
	public GameObject AdsAreNotAvailable;

	private Action onRewardedAdSuccess;

	public static bool isAppPurchased;

	public bool isAdvertisementReady;

	private void Start()
	{
		 #if UNITY_IPHONE
		Advertisement.Initialize("4553930");
         #endif
         #if UNITY_ANDROID
        Advertisement.Initialize("4553931");
          #endif
		
		Advertisement.AddListener(this);
		this.ShowBanner();

	}

	
	public void PlayAd()
	{
		if (Advertisement.IsReady("Interstitial_Android") && !AdsManager.isAppPurchased)
		{
			Advertisement.Show("Interstitial_Android");
		}
	}

	public void PlayRewardedAd()
	{
		if (Advertisement.IsReady("Rewarded_Android"))
		{
			Advertisement.Show("Rewarded_Android");
			this.isAdvertisementReady = true;
			
			return;
		}
		else{
		AdsAreNotAvailable.SetActive(true);
		}
		Debug.Log("Rewarded ad is not ready");
	}


	public void ShowBanner()
	{
		if (Advertisement.IsReady("banner") && !AdsManager.isAppPurchased)
		{
			Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
			Advertisement.Banner.Show("banner");
			return;
		}
		base.StartCoroutine(this.RepeatShowBanner());
	}


	public void HideBanner()
	{
		Advertisement.Banner.Hide(false);
	}

	
	private IEnumerator RepeatShowBanner()
	{
		yield return new WaitForSeconds(1f);
		this.ShowBanner();
		yield break;
	}

	
	public void OnUnityAdsReady(string placementId)
	{
		Debug.Log("Ads are ready");
	}

	
	public void OnUnityAdsDidError(string message)
	{
		Debug.Log("Error: " + message);
	}


	public void OnUnityAdsDidStart(string placementId)
	{
		Debug.Log("VIDEO STARTED");
	}


	public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
	{
		if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
		{
			Debug.Log("PLAYER SHOULD NOT BE REWARDED");
			GetComponent<GameOver>().Revive();
		}
	
	}

	public void RemoveAdFunction()
	{
		AdsManager.isAppPurchased = true;
		PlayerPrefs.SetString("isAppPurchased", AdsManager.isAppPurchased.ToString());
		PlayerPrefs.Save();
		this.HideBanner();
	}

}
