using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VehicleColor : MonoBehaviour
{
    public bool checkFonk2 = false, chechFonkBody = false,checkFonkRim=false, settingsiconcontrol=false, gifticoncontrol=false;
    public static VehicleColor Current;
    public GameObject camera,colorScreen,leftButton,rightButton,BodyPicker,RimPicker,bodysellbutton, rimsellbutton;
    public Text MainText;
    public string baslangicbodyrengi, baslangicrimrengi;
    public Material kalicibodydiger,kalicirimdiger,gecicirimdiger;


    void Start()
    {
        colorScreen.SetActive(false);
        Current = this;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 0;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 4.5f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -4.5f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(16.521f, 0, 0));
        if (!PlayerPrefs.HasKey("kontrol2"))
        {
            baslangicbodyrengi = PlayerPrefs.GetString("SavedBodyColor") + "8A8A8A";
            baslangicrimrengi = PlayerPrefs.GetString("SavedRimColor") + "313131";
            PlayerPrefs.SetString("SavedBodyColor", baslangicbodyrengi);
            PlayerPrefs.SetString("SavedRimColor", baslangicrimrengi);
            PlayerPrefs.SetInt("kontrol2", 1);
        }
        else
        {
            PlayerPrefs.GetString("SavedBodyColor");
            PlayerPrefs.GetString("SavedRimColor");
        }
        kalicibodydiger.color = HexToColor(PlayerPrefs.GetString("SavedBodyColor"));
        kalicirimdiger.color = HexToColor(PlayerPrefs.GetString("SavedRimColor"));
        gecicirimdiger.color = kalicirimdiger.color;
    }

    void Update()
    {
        if (rimsellbutton.activeInHierarchy == true)
        {
            if (LevelController.Current.money < 20)
            {
                LevelController.Current.sellbuttonrim.interactable = false;
            }
            if (LevelController.Current.money >= 20)
            {
                LevelController.Current.sellbuttonrim.interactable = true;
            }
        }
        if (bodysellbutton.activeInHierarchy == true)
        {
            if (LevelController.Current.money < 50)
            {
                LevelController.Current.sellbutton.interactable = false;
            }
            if (LevelController.Current.money >= 50)
            {
                LevelController.Current.sellbutton.interactable = true;
            }
        }
    }

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }
    public void BodyColorChance()
    {
        GameObject.FindWithTag("spreysesi").GetComponent<AudioSource>().Play();
        MainText.transform.localPosition = new Vector3(17.9f, 1098, 0);
        BodyPicker.SetActive(true);
        bodysellbutton.SetActive(true);
        rimsellbutton.SetActive(false);
        RimPicker.SetActive(false);
        MainText.text = "BODY";
        colorScreen.SetActive(true);
        LevelController.Current.startMenu.SetActive(false);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 1.82f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 1.54f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 5.25f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(-2.097f, 202.265f, 0));
        GameObject.FindWithTag("spot").GetComponent<Light>().enabled = true;
        GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker2").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker3").GetComponent<Animator>().enabled = false;
        leftButton.SetActive(false);
        rightButton.SetActive(true);
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteController>().MateyelEsitlemeBody();
        kalicirimdiger.color = GameObject.FindWithTag("palet").GetComponent<ColorPaletteController>().gecicirim.color;
    }
    public void BodyColorChanceBack()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        MainText.transform.localPosition = new Vector3(17.9f, 1098, 0);
        BodyPicker.SetActive(true);
        bodysellbutton.SetActive(true);
        rimsellbutton.SetActive(false);
        RimPicker.SetActive(false);
        MainText.text = "BODY";
        colorScreen.SetActive(true);
        LevelController.Current.startMenu.SetActive(false);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 1.82f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 1.54f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 5.25f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(-2.097f, 202.265f, 0));
        GameObject.FindWithTag("spot").GetComponent<Light>().enabled = true;
        GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker2").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker3").GetComponent<Animator>().enabled = false;
        leftButton.SetActive(false);
        rightButton.SetActive(true);
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteController>().MateyelEsitlemeBody();
        kalicirimdiger.color = GameObject.FindWithTag("palet").GetComponent<ColorPaletteController>().gecicirim.color;
    }
    public void WheelColorChance()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        rimsellbutton.SetActive(true);
        bodysellbutton.SetActive(false);
        MainText.transform.localPosition = new Vector3(17.9f, 1019, 0);
        BodyPicker.SetActive(false);
        RimPicker.SetActive(true);
        MainText.text = "RIM";
        colorScreen.SetActive(true);
        GameObject.FindWithTag("spot").GetComponent<Transform>().position = new Vector3(2.11f, 3.5f, -22.51f);
        LevelController.Current.startMenu.SetActive(false);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 3.99f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 0.59f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 1.01f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(-14.466f, -90, 0));
        GameObject.FindWithTag("spot").GetComponent<Light>().enabled = true;
        GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker2").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker3").GetComponent<Animator>().enabled = false;
        leftButton.SetActive(true);
        rightButton.SetActive(false);
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteController>().MateyelEsitlemeRim();
        kalicibodydiger.color = GameObject.FindWithTag("palet").GetComponent<ColorPaletteController>().gecicibody.color;

    }
    public void BackButton()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        BodyPicker.SetActive(false);
        RimPicker.SetActive(false);
        LevelController.Current.startMenu.SetActive(true);
        colorScreen.SetActive(false);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 0;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 4.5f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -4.5f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(16.521f, 0, 0));
        GameObject.FindWithTag("spot").GetComponent<Light>().enabled = false;
        GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = true;
        GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = true;
        GameObject.FindWithTag("teker2").GetComponent<Animator>().enabled = true;
        GameObject.FindWithTag("teker3").GetComponent<Animator>().enabled = true;
        chechFonkBody = false;
        checkFonk2 = true;
        kalicibodydiger.color = ColorPaletteController.Current.gecicibody.color;
        kalicirimdiger.color = ColorPaletteController.Current.gecicirim.color;
    }
    public void SellCoinBody()
    {
        CameraControl.Current.areyousurebodypanel.SetActive(false);
        chechFonkBody = true;
        BodySellUpdateCoin();
        if(PlayerPrefs.GetInt("reklamkodu") == 0)
        {
            GameObject.FindWithTag("AddControl").GetComponent<ADController>().ShowInterstitial();
        }
        
    }
    public void SellCoinRim()
    {
        CameraControl.Current.areyousurerimpanel.SetActive(false);
        checkFonkRim = true;
        RimSellUpdateCoin();
        if (PlayerPrefs.GetInt("reklamkodu") == 0)
        {
            GameObject.FindWithTag("AddControl").GetComponent<ADController>().ShowInterstitial();
        }
    }
    public void BodySellUpdateCoin()
    {
        GameObject.FindWithTag("satissesi").GetComponent<AudioSource>().Play();
        LevelController.Current.money -= 50;
        LevelController.Current.UpdateMoneyText();
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteController>().UpdateColor();
        PlayerPrefs.SetInt("money", LevelController.Current.money);
    }
    public void RimSellUpdateCoin()
    {
        GameObject.FindWithTag("satissesi").GetComponent<AudioSource>().Play();
        LevelController.Current.money -= 20;
        LevelController.Current.UpdateMoneyText();
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteController>().UpdateColor();
        PlayerPrefs.SetInt("money", LevelController.Current.money);
    }
}
