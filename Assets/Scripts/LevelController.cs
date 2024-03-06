using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public static LevelController Current;
    public bool gameActive = false;
    public int currentLevel,para = 0;
    public GameObject startMenu, gameMenu, gameOverMenu, finishMenu, taptostart, adminlevelnextbutton, adminlevelbackbutton;
    public Text currentLevelText, nextLevelText,startingMenuMoneyText, nextLevelMenuMoneyText,MarketMoneyText;
    public int money,money2;
    public Button sellbutton,sellbuttonrim;
    public DailyReward dailyreward;

    void Start()
    {

        if (!PlayerPrefs.HasKey("kontrol"))
        {
            money = PlayerPrefs.GetInt("money") + 999;
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("kontrol", 1);
        }
        else
        {
            money = PlayerPrefs.GetInt("money");
        }
        Current = this;
        currentLevel = PlayerPrefs.GetInt("currentLevel") + 1;

        if(SceneManager.GetActiveScene().name != "Level" + currentLevel)
        {
            SceneManager.LoadScene("Level" + currentLevel);
        }
        else
        {
            dailyreward.InitializeDailyRewrd();
            currentLevelText.text = (currentLevel).ToString();
            nextLevelText.text = (currentLevel).ToString();
            UpdateMoneyText();
        }
        if (!PlayerPrefs.HasKey("kontrol99"))
        {
            PlayerPrefs.SetInt("adminnextlevel", 0);
            PlayerPrefs.SetInt("kontrol99", 1);
        }
        if (PlayerPrefs.GetInt("adminnextlevel") == 0)
        {
            adminlevelnextbutton.SetActive(false);
            adminlevelbackbutton.SetActive(false);
        }else if (PlayerPrefs.GetInt("adminnextlevel") == 1)
        {
            adminlevelnextbutton.SetActive(true);
            adminlevelbackbutton.SetActive(true);
        }
        startMenu.SetActive(true);
        taptostart.SetActive(true);
        gameMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        finishMenu.SetActive(false);
        
    }


    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level" + 1 && PlayerPrefs.GetInt("adminnextlevel") == 1) {

            adminlevelbackbutton.SetActive(false);

        }
       
    }
    public void StartLevelMotor1()
    {
        MotorCont.Current.ChangeSpeed(MotorCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorMotor1.Current.checkFonk2 = false;
    }
    public void StartLevelMotor2()
    {
        MotorCont.Current.ChangeSpeed(MotorCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorMotor2.Current.checkFonk2 = false;
    }
    public void StartLevelMotor3()
    {
        MotorCont.Current.ChangeSpeed(MotorCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorMotor3.Current.checkFonk2 = false;
    }
    public void StartLevelMotor4()
    {
        MotorCont.Current.ChangeSpeed(MotorCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorMotor4.Current.checkFonk2 = false;
    }
    public void StartLevelMotor5()
    {
        MotorCont.Current.ChangeSpeed(MotorCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorMotor5.Current.checkFonk2 = false;
    }
    public void StartLevelAraba1()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba1.Current.checkFonk2 = false;

    }
    public void StartLevelAraba2()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba2.Current.checkFonk2 = false;

    }
    public void StartLevelAraba3()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba3.Current.checkFonk2 = false;

    }
    public void StartLevelAraba4()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba4.Current.checkFonk2 = false;

    }
    public void StartLevelAraba5()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba5.Current.checkFonk2 = false;

    }
    public void StartLevelAraba6()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColor.Current.checkFonk2 = false;
        
    }
    public void StartLevelAraba7()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba7.Current.checkFonk2 = false;

    }
    public void StartLevelAraba8()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba8.Current.checkFonk2 = false;

    }
    public void StartLevelAraba9()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba9.Current.checkFonk2 = false;

    }
    public void StartLevelAraba10()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba10.Current.checkFonk2 = false;

    }
    public void StartLevelAraba11()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba11.Current.checkFonk2 = false;

    }
    public void StartLevelAraba12()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba12.Current.checkFonk2 = false;

    }
    public void StartLevelAraba13()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba13.Current.checkFonk2 = false;

    }
    public void StartLevelAraba14()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba14.Current.checkFonk2 = false;

    }
    public void StartLevelAraba15()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba15.Current.checkFonk2 = false;

    }
    public void StartLevelAraba16()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba16.Current.checkFonk2 = false;

    }
    public void StartLevelAraba17()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba17.Current.checkFonk2 = false;

    }
    public void StartLevelAraba18()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba18.Current.checkFonk2 = false;

    }
    public void StartLevelAraba19()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba19.Current.checkFonk2 = false;

    }
    public void StartLevelAraba20()
    {
        CarCont.Current.ChangeSpeed(CarCont.Current.carSpeed);
        gameActive = true;
        startMenu.SetActive(false);
        taptostart.SetActive(false);
        gameMenu.SetActive(true);
        VehicleColorAraba20.Current.checkFonk2 = false;

    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void LoadNextLevel()
    {
        //PlayerPrefs.SetInt("currentLevel", 1);
        SceneManager.LoadScene("Level" + (currentLevel));
    }
    public void AdminLoadNextLevel()
    {
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        SceneManager.LoadScene("Level" + (currentLevel));
    }
    public void AdminLoadBackLevel()
    {
        PlayerPrefs.SetInt("currentLevel", (currentLevel-2));
        SceneManager.LoadScene("Level" + (currentLevel));
    }
    public void gizliinfoAdminLevelOpen()
    {
        PlayerPrefs.SetInt("adminnextlevel", 1);
        adminlevelbackbutton.SetActive(true);
        adminlevelnextbutton.SetActive(true);
    }
    public void gizliinfoAdminLevelClose()
    {
        PlayerPrefs.SetInt("adminnextlevel", 1);
        adminlevelbackbutton.SetActive(false);
        adminlevelnextbutton.SetActive(false);
    }
    public void GameOver()
    {
        GameObject.FindWithTag("motorsesi").GetComponent<AudioSource>().Stop();
        gameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        gameActive = false;
    }
    public void FinishGame()
    {
        money = PlayerPrefs.GetInt("money");
        PlayerPrefs.SetInt("money", para + money);
        nextLevelMenuMoneyText.text = para.ToString();
        UpdateMoneyText();
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        para = 0;
        gameMenu.SetActive(false);
        finishMenu.SetActive(true);
        gameActive = false;
        if (currentLevel % 2 == 0 && PlayerPrefs.GetInt("reklamkodu") == 0)
        {
            GameObject.FindWithTag("AddControl").GetComponent<ADController>().ShowInterstitial();
        }
    }
    public void sifirla()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ChangeMoney(int money)
    {
        para += money;
    }
    public void UpdateMoneyText()
    {
        startingMenuMoneyText.text = (money+ para).ToString();
        MarketMoneyText.text = (money+para).ToString();
    }
  
    public void DailyReward()
    {
        money += 10;
        UpdateMoneyText();
        PlayerPrefs.SetInt("money", money);
    }
    public void GizliExtraPara()
    {
        GameObject.FindWithTag("coinsesi").GetComponent<AudioSource>().Play();
        money += 100;
        UpdateMoneyText();
        PlayerPrefs.SetInt("money", money);
    }
}
