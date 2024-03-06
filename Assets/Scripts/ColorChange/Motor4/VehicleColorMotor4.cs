using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VehicleColorMotor4 : MonoBehaviour
{
    public bool checkFonk2 = false, chechFonkBody = false, checkFonkRim = false, settingsiconcontrol = false, gifticoncontrol = false;
    public static VehicleColorMotor4 Current;
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
        if (!PlayerPrefs.HasKey("kontrol10"))
        {
            baslangicbodyrengi = PlayerPrefs.GetString("SavedMotor4BodyColor") + "8A8A8A";
            baslangicrimrengi = PlayerPrefs.GetString("SavedMotor4RimColor") + "808080";
            PlayerPrefs.SetString("SavedMotor4BodyColor", baslangicbodyrengi);
            PlayerPrefs.SetString("SavedMotor4RimColor", baslangicrimrengi);
            PlayerPrefs.SetInt("kontrol10", 1);
        }
        else
        {
            PlayerPrefs.GetString("SavedMotor4BodyColor");
            PlayerPrefs.GetString("SavedMotor4RimColor");
        }
        kalicibodydiger.color = HexToColor(PlayerPrefs.GetString("SavedMotor4BodyColor"));
        kalicirimdiger.color = HexToColor(PlayerPrefs.GetString("SavedMotor4RimColor"));
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
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 1.9f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 3.4f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(-1.71f, -129.09f, 0));
        GameObject.FindWithTag("spot").GetComponent<Light>().enabled = true;
        GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
        leftButton.SetActive(false);
        rightButton.SetActive(true);
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor4>().MateyelEsitlemeBody();
        kalicirimdiger.color = GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor4>().gecicirim.color;
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
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 1.9f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 3.4f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(-1.71f, -129.09f, 0));
        GameObject.FindWithTag("spot").GetComponent<Light>().enabled = true;
        GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
        leftButton.SetActive(false);
        rightButton.SetActive(true);
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor4>().MateyelEsitlemeBody();
        kalicirimdiger.color = GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor4>().gecicirim.color;
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
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.x = 2.97f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.y = 1.35f;
        GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 2.05f;
        camera.transform.rotation = Quaternion.Euler(new Vector3(-1.45f, -106.97f, 0));
        GameObject.FindWithTag("spot").GetComponent<Light>().enabled = true;
        GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
        GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
        leftButton.SetActive(true);
        rightButton.SetActive(false);
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor4>().MateyelEsitlemeRim();
        kalicibodydiger.color = GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor4>().gecicibody.color;

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
        kalicibodydiger.color = ColorPaletteControllerMotor4.Current.gecicibody.color;
        kalicirimdiger.color = ColorPaletteControllerMotor4.Current.gecicirim.color;
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
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor4>().UpdateColor();
        PlayerPrefs.SetInt("money", LevelController.Current.money);
    }
    public void RimSellUpdateCoin()
    {
        GameObject.FindWithTag("satissesi").GetComponent<AudioSource>().Play();
        LevelController.Current.money -= 20;
        LevelController.Current.UpdateMoneyText();
        GameObject.FindWithTag("palet").GetComponent<ColorPaletteControllerMotor4>().UpdateColor();
        PlayerPrefs.SetInt("money", LevelController.Current.money);
    }
}
