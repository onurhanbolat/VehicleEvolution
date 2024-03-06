using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VehicleColorMotor2 : MonoBehaviour
{
    public bool checkFonk2 = false, chechFonkBody = false, checkFonkRim = false, settingsiconcontrol = false, gifticoncontrol = false;
    public static VehicleColorMotor2 Current;
    public GameObject camera, colorScreen, leftButton, rightButton, BodyPicker, RimPicker, bodysellbutton, rimsellbutton;
    public Text MainText;
    public string baslangicbodyrengi, baslangicrimrengi;
    public Material kalicibodydiger, kalicirimdiger, gecicirimdiger;


    void Start()
    {
        colorScreen.SetActive(false);
        Current = this;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 0;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 4.5f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -4.5f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(16.521f, 0, 0));
        if (!PlayerPrefs.HasKey("kontrol6"))
        {
            baslangicbodyrengi = PlayerPrefs.GetString("SavedMotor2BodyColor") + "8A8A8A";
            baslangicrimrengi = PlayerPrefs.GetString("SavedMotor2RimColor") + "939393";
            PlayerPrefs.SetString("SavedMotor2BodyColor", baslangicbodyrengi);
            PlayerPrefs.SetString("SavedMotor2RimColor", baslangicrimrengi);
            PlayerPrefs.SetInt("kontrol6", 1);
        }
        else
        {
            PlayerPrefs.GetString("SavedMotor2BodyColor");
            PlayerPrefs.GetString("SavedMotor2RimColor");
        }
        kalicibodydiger.color = HexToColor(PlayerPrefs.GetString("SavedMotor2BodyColor"));
        kalicirimdiger.color = HexToColor(PlayerPrefs.GetString("SavedMotor2RimColor"));
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
        MainText.transform.localPosition = new Vector3(17.9f, 1083, 0);
        BodyPicker.SetActive(true);
        bodysellbutton.SetActive(true);
        rimsellbutton.SetActive(false);
        RimPicker.SetActive(false);
        MainText.text = "BODY";
        colorScreen.SetActive(true);
        LevelController.Current.startMenu.SetActive(false);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 3.82f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 2.06f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 3.97f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(-2.097f, -134.17f, 0));
        GameObject.FindWithTag("spot").GetComponent<Light>().enabled = true;
        GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
        leftButton.SetActive(false);
        rightButton.SetActive(true);
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor2>().MateyelEsitlemeBody();
        kalicirimdiger.color = GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor2>().gecicirim.color;
    }
    public void BodyColorChanceBack()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        MainText.transform.localPosition = new Vector3(17.9f, 1083, 0);
        BodyPicker.SetActive(true);
        bodysellbutton.SetActive(true);
        rimsellbutton.SetActive(false);
        RimPicker.SetActive(false);
        MainText.text = "BODY";
        colorScreen.SetActive(true);
        LevelController.Current.startMenu.SetActive(false);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 3.82f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 2.06f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 3.971f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(-2.097f, -134.17f, 0));
        GameObject.FindWithTag("spot").GetComponent<Light>().enabled = true;
        GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
        leftButton.SetActive(false);
        rightButton.SetActive(true);
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor2>().MateyelEsitlemeBody();
        kalicirimdiger.color = GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor2>().gecicirim.color;
    }
    public void WheelColorChance()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        rimsellbutton.SetActive(true);
        bodysellbutton.SetActive(false);
        MainText.transform.localPosition = new Vector3(17.9f, 1078, 0);
        BodyPicker.SetActive(false);
        RimPicker.SetActive(true);
        MainText.text = "RIM";
        colorScreen.SetActive(true);
        GameObject.FindWithTag("spot").GetComponent<Transform>().position = new Vector3(2.11f, 3.5f, -22.51f);
        LevelController.Current.startMenu.SetActive(false);
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 2.57f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 1.5f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 1.9f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(2.57f, -106.97f, 0));
        GameObject.FindWithTag("spot").GetComponent<Light>().enabled = true;
        GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
        leftButton.SetActive(true);
        rightButton.SetActive(false);
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor2>().MateyelEsitlemeRim();
        kalicibodydiger.color = GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor2>().gecicibody.color;

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
        chechFonkBody = false;
        checkFonk2 = true;
        kalicibodydiger.color = ColorPaletteControllerMotor2.Current.gecicibody.color;
        kalicirimdiger.color = ColorPaletteControllerMotor2.Current.gecicirim.color;
    }
    public void SellCoinBody()
    {
        CameraControl.Current.areyousurebodypanel.SetActive(false);
        chechFonkBody = true;
        BodySellUpdateCoin();
        if (PlayerPrefs.GetInt("reklamkodu") == 0)
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
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor2>().UpdateColor();
        PlayerPrefs.SetInt("money", LevelController.Current.money);
    }
    public void RimSellUpdateCoin()
    {
        GameObject.FindWithTag("satissesi").GetComponent<AudioSource>().Play();
        LevelController.Current.money -= 20;
        LevelController.Current.UpdateMoneyText();
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor2>().UpdateColor();
        PlayerPrefs.SetInt("money", LevelController.Current.money);
    }
}