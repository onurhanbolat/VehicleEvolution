using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuelSystem : MonoBehaviour
{

    public static fuelSystem Current;
    public Image FuelBar;
    public int katsayi = 10;
    public float bidonartisdegeri = 1.5f,bidonartisdegeri2=5f;
    public bool kontrol = true;

    private void Start()
    {
        Current = this;
    }
    public void Update()
    {

        if (kontrol == true && LevelController.Current.gameActive == true)
        {
            FuelBar.fillAmount -= Time.deltaTime / katsayi;
        }
        if (FuelBar.fillAmount == 0 && LevelController.Current.currentLevel >= 1 && LevelController.Current.currentLevel <= 9)
        {
            GameObject.FindWithTag("arac").GetComponent<MotorCont>().bug = false;
            GameObject.FindWithTag("arac").GetComponent<MotorCont>().shield.SetActive(false);
            GameObject.FindWithTag("arac").GetComponent<MotorCont>().carSpeed = 0;
            GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
            GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
            GameObject.FindWithTag("LevelController").GetComponent<LevelController>().GameOver();
            while (GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z > -6.3f)
            {
                GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z -= 0.5f;
            }

        }
        if (FuelBar.fillAmount == 0 && LevelController.Current.currentLevel >= 10 && LevelController.Current.currentLevel <= 70)
        {
            GameObject.FindWithTag("arac").GetComponent<CarCont>().bug = false;
            GameObject.FindWithTag("arac").GetComponent<CarCont>().shield.SetActive(false);
            GameObject.FindWithTag("arac").GetComponent<CarCont>().carSpeed = 0;
            GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
            GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
            GameObject.FindWithTag("teker2").GetComponent<Animator>().enabled = false;
            GameObject.FindWithTag("teker3").GetComponent<Animator>().enabled = false;
            GameObject.FindWithTag("LevelController").GetComponent<LevelController>().GameOver();
            while (GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z > -6.3f)
            {
                GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z -= 0.5f;
            }

        }
        
        
    }
    public void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("benzin"))
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                FuelBar.fillAmount += Time.deltaTime * bidonartisdegeri;
                Destroy(other.gameObject);
            }
            if (other.CompareTag("altinbenzin"))
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                FuelBar.fillAmount += Time.deltaTime * bidonartisdegeri2;
                Destroy(other.gameObject);
            }
        
    }
}
