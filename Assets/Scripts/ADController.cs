using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds;
using GoogleMobileAds.Api;
public class ADController : MonoBehaviour
{
    private InterstitialAD interstitial;

    public static ADController Instance;

    public delegate void OnReward();
    public static event OnReward OnGaveReward;

    public Button noAdButton;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        interstitial = GetComponent<InterstitialAD>();
    }
    private void Start()
    {
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            interstitial.LoadInterstitialAd();
        });

        if (PlayerPrefs.GetInt("reklamkodu") == 1)
        {
            GameObject.FindWithTag("AddControl").GetComponent<ADController>().noAdButton.interactable = false;
        }
        else if (PlayerPrefs.GetInt("reklamkodu") == 0)
        {
            GameObject.FindWithTag("AddControl").GetComponent<ADController>().noAdButton.interactable = true;
        }
    }

    public void ShowInterstitial()
    {
        interstitial.ShowAd();
    }
    public void ReklamiManuelKapat()
    {
        PlayerPrefs.SetInt("reklamkodu", 1);
        noAdButton.interactable = false;
    }
    public void ReklamiManuelAc()
    {
        PlayerPrefs.SetInt("reklamkodu", 0);
        noAdButton.interactable = true;
    }
}