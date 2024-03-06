using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl Current;
    public Transform target;
    public Vector3 offset;
    public GameObject kamera, GiftMenu, TapTo, suscoin, SettingsMenu,
    daliymenuclosebutton, areyousurebodypanel, areyousurerimpanel;
    public bool gifticoncontrol=false, settingsiconcontrol = false;

    void Start()
    {
        Current = this;
        suscoin.SetActive(false);
        GiftMenu.SetActive(false);
        areyousurebodypanel.SetActive(false);
        areyousurerimpanel.SetActive(false);
        SettingsMenu.SetActive(false);
    }

    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * 3);

    }
    public void BackButtonGift()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        gifticoncontrol = false;
        LevelController.Current.startMenu.SetActive(true);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 0;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 4.5f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -4.5f;
        kamera.transform.rotation = Quaternion.Euler(new Vector3(16.521f, 0, 0));
        Invoke("Action2", 0.5f);
    }
    public void Action()
    {
        if (settingsiconcontrol == false)
        {
            SettingsMenu.SetActive(false);
            TapTo.SetActive(true);
        }
    }
    public void Action2()
    {
        if (gifticoncontrol == false)
        {
            GiftMenu.SetActive(false);
            TapTo.SetActive(true);
            suscoin.SetActive(false);
        }
    }
    public void GiftScreen()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        gifticoncontrol = true;
        GiftMenu.SetActive(true);
        suscoin.SetActive(true);
        TapTo.SetActive(false);
        LevelController.Current.startMenu.SetActive(false);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 0;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = -1.7f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -4.5f;
    }
    public void SettingsScreen()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        settingsiconcontrol = true;
        SettingsMenu.SetActive(true);
        TapTo.SetActive(false);
        LevelController.Current.startMenu.SetActive(false);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 0;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = -1.7f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -4.5f;
    }
    public void BackButtonSettings()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        settingsiconcontrol = false;
        LevelController.Current.startMenu.SetActive(true);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 0;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 4.5f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -4.5f;
        kamera.transform.rotation = Quaternion.Euler(new Vector3(16.521f, 0, 0));
        Invoke("Action", 0.5f);

    }
    public void SellBodyButton()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        areyousurebodypanel.SetActive(true);
    }
    public void SellRimButton()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        areyousurerimpanel.SetActive(true);
    }
    public void SellBodyButtonBack()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        areyousurebodypanel.SetActive(false);
    }
    public void SellRimButtonBack()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        areyousurerimpanel.SetActive(false);
    }
    public void dailyclose()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        daliymenuclosebutton.SetActive(false);
        GameObject.FindWithTag("rewardparticle1").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("rewardparticle2").GetComponent<ParticleSystem>().Stop();
    }
}
