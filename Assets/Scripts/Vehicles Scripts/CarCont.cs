using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CarCont : MonoBehaviour
{

    public static CarCont Current;

    [SerializeField] public float carSpeed;
    [SerializeField] float maxSpeed;

    [SerializeField] float steerangle, carangle, direksiyonangle;

    float dragAmount = 0.99f;

    [SerializeField] float Traction;

    public Transform solon, sagon, car, direksiyon;
    public GameObject shield,shieldkirmizi,karsitoksayac, EffectSoundOnButton, EffectSoundOffButton,
    infopanel,gizliinfo, MusicSoundOffButton, MusicSoundOnButton;


    Vector3 _rotVec;
    Vector3 _rotVec1;
    Vector3 _rotVec2;
    Vector3 _moveVec;

    int sayac = 0,sayac2=0,sayac3=0,sayac4=0,reklamsayaci;

    float time, time2,timee,timee2,timeee,timeee3,carSpeedGecici,zaman,zaman2;
    public bool bug = true, turbokontrol = false;
    bool karsitok = false, GizliButton=false,infotest=false;

    public Text karsitokyazi;





    void Start()
    {
        reklamsayaci = PlayerPrefs.GetInt("reklam");
        MusicSoundOffButton.SetActive(false);
        MusicSoundOnButton.SetActive(true);
        gizliinfo.SetActive(false);
        infopanel.SetActive(false);
        EffectSoundOffButton.SetActive(false);
        EffectSoundOnButton.SetActive(true);
        Current = this;
        shield.SetActive(false);
        shieldkirmizi.SetActive(false);
        karsitoksayac.SetActive(false);
        if (!PlayerPrefs.HasKey("kontrol3"))
        {
            PlayerPrefs.SetInt("sesDurum1", 1);
            PlayerPrefs.SetInt("kontrol3", 1);
        }
        if (!PlayerPrefs.HasKey("kontrol4"))
        {
            PlayerPrefs.SetInt("sesDurum2", 1);
            PlayerPrefs.SetInt("kontrol4", 1);
        }
        if (!PlayerPrefs.HasKey("kontrol5"))
        {
            PlayerPrefs.SetInt("reklamkodu", 0);
            PlayerPrefs.SetInt("kontrol5", 1);
        }

        if (PlayerPrefs.GetInt("sesDurum1") == 0)
        {
            MusicSoundOffButton.SetActive(true);
            MusicSoundOnButton.SetActive(false);
            GameObject.FindWithTag("arkaplansesi").GetComponent<AudioSource>().mute = true;
        }
        else if(PlayerPrefs.GetInt("sesDurum1") == 1)
        {
            MusicSoundOffButton.SetActive(false);
            MusicSoundOnButton.SetActive(true);
            GameObject.FindWithTag("arkaplansesi").GetComponent<AudioSource>().mute = false;
        }
        if (PlayerPrefs.GetInt("sesDurum2") == 0)
        {
            EffectSoundOn();
        }
        else if (PlayerPrefs.GetInt("sesDurum2") == 1)
        {
            EffectSoundOff();
        }
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        GameObject.FindWithTag("kan1").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("kan2").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("kan3").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("kan4").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("kan5").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("kalkanefekt").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("kalkanefekt2").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("kalkanefekt3").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("spot").GetComponent<Light>().enabled = false;
    }
    void Update()
    {
        

        if (GizliButton==true && infotest == true)
        {
            GameObject.FindWithTag("A").GetComponent<AudioSource>().Play();
            infopanel.SetActive(false);
            gizliinfo.SetActive(true);
        }
        if (LevelController.Current == null || LevelController.Current.gameActive==false)
        {
            return;
        }
        if (Input.GetMouseButton(0) && carSpeed > 0)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * steerangle * Time.fixedDeltaTime * _moveVec.magnitude /6);
            _rotVec1 = Vector3.ClampMagnitude(_rotVec, carangle);
            if (karsitok == false)
            {
                _rotVec += new Vector3(0, 2*Input.GetAxis("Mouse X"), 0);
            }if(karsitok == true)
            {
                _rotVec += new Vector3(0, -2*Input.GetAxis("Mouse X"), 0);
            }
           
            _rotVec1 += new Vector3(0, Input.GetAxis("Mouse X"), 0);
            _rotVec2 += new Vector3(0, 0, Input.GetAxis("Mouse X"));
        }

        _moveVec += transform.forward * carSpeed * Time.fixedDeltaTime * 0.5f;
        transform.position += _moveVec * Time.deltaTime;


        _moveVec *= dragAmount;
        _moveVec = Vector3.ClampMagnitude(_moveVec, maxSpeed);
        _moveVec = Vector3.Lerp(_moveVec.normalized, transform.forward, Traction * Time.fixedDeltaTime) * _moveVec.magnitude;

        _rotVec = Vector3.ClampMagnitude(_rotVec, steerangle);
        _rotVec2 = Vector3.ClampMagnitude(_rotVec2, direksiyonangle);

        solon.localRotation = Quaternion.Euler(_rotVec);
        sagon.localRotation = Quaternion.Euler(_rotVec);
        direksiyon.localRotation = Quaternion.Euler(_rotVec2);
        car.localRotation = Quaternion.Euler(_rotVec1);

        if (sayac == 1)
        {

            time -= 3f * Time.deltaTime;
            time2 = Mathf.CeilToInt(time);

            if(time2 == 7)
            {
                GameObject.FindWithTag("gerisayimsesi").GetComponent<AudioSource>().Play();
            }
            else if (time2 == 6)
            {
                shieldkirmizi.SetActive(true);
                shield.SetActive(false);
            }
            else if (time2 == 4)
            {
                shieldkirmizi.SetActive(true);
                shield.SetActive(false);
            }
            else if (time2 == 2)
            {
                shieldkirmizi.SetActive(true);
                shield.SetActive(false);
            }
            else
            {
                shield.SetActive(true);
                shieldkirmizi.SetActive(false);
            }
            if (time2 == 0)
            {
                GameObject.FindWithTag("patlamasesi").GetComponent<AudioSource>().Play();
                GameObject.FindWithTag("kalkanefekt3").GetComponent<ParticleSystem>().Play();
                shield.SetActive(false);
                time = 30f;
                sayac = 0;
            }
        }
        if (sayac2 == 1)
        {
            timee -= Time.deltaTime;
            timee2 = Mathf.CeilToInt(timee);
            karsitokyazi.text = timee2.ToString();
            karsitoksayac.SetActive(true);

            if (timee2 == 0)
            {
                karsitoksayac.SetActive(false);
                karsitok = false;
                timee = 3f;
                sayac2 = 0;
            }
        }
        if (sayac3 == 1)
        {
            timeee -= Time.deltaTime;
            timeee3 = Mathf.CeilToInt(timeee);
            if (timeee3 == 0)
            {
                timeee = 1f;
                carSpeed -= carSpeedGecici;
                sayac3 = 0;
                sayac4 = 1;
            }
        }
        if (sayac4 == 1)
        {
            zaman -= 4f*Time.deltaTime;
            zaman2 = Mathf.CeilToInt(zaman);
            if (zaman2 == 6)
            {
                GameObject.FindWithTag("gerisayimsesiturbo").GetComponent<AudioSource>().Play();
            }
            else if (zaman2 == 5)
            {
                shield.SetActive(false);
                shieldkirmizi.SetActive(true);
            }
            else if (zaman2 == 3)
            {
                shield.SetActive(false);
                shieldkirmizi.SetActive(true);
            }
            else if (zaman2 == 1)
            {
                shield.SetActive(false);
                shieldkirmizi.SetActive(true);
            }
            else
            {
                shield.SetActive(true);
                shieldkirmizi.SetActive(false);
            }
            if (zaman2 == 0)
            {
                GameObject.FindWithTag("patlamasesi").GetComponent<AudioSource>().Play();
                zaman = 9f;
                shield.SetActive(false);
                shieldkirmizi.SetActive(false);
                sayac4 = 0;
                GameObject.FindWithTag("kalkanefekt3").GetComponent<ParticleSystem>().Play();
                turbokontrol = false;
            }
        }

        //hýz 8
        if (carSpeed <= 11 && carSpeed>=8)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -4f;
        }
        if (carSpeed <= 14 && carSpeed > 11)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -3;
        }
        if (carSpeed <= 17 && carSpeed > 14)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -2f;
        }
        if (carSpeed <= 20 && carSpeed > 17)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -1.5f;
        }
        if (carSpeed <= 23 && carSpeed > 20)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 0f;
        }
        if (carSpeed <= 26 && carSpeed > 23)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 0.5f;
        }
        if (carSpeed <= 29 && carSpeed > 26)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 1.7f;
        }
        if (carSpeed <= 32 && carSpeed > 29)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = 1.7f;
        }
        if (carSpeed==40)
        {
            GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z = -1.5f;
        }

    }

    public void ChangeSpeed(float value)
    {
        GameObject.FindWithTag("motorsesi").GetComponent<AudioSource>().Play();
        carSpeed = value;
    }
    public void EffectSoundOff()
    {
        EffectSoundOnButton.SetActive(true);
        EffectSoundOffButton.SetActive(false);
        PlayerPrefs.SetInt("sesDurum2", 1);
        GameObject.FindWithTag("roketsesi").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("A").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("losesesi").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("levelupsesi").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("coinsesi").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("patlamasesi").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("spreysesi").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("gerisayimsesi").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("gerisayimsesiturbo").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("kansesi").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("satissesi").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("motorsesi").GetComponent<AudioSource>().mute = false;
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().mute = false;

    }
    public void EffectSoundOn()
    {
        EffectSoundOnButton.SetActive(false);
        EffectSoundOffButton.SetActive(true);
        PlayerPrefs.SetInt("sesDurum2", 0);
        GameObject.FindWithTag("roketsesi").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("A").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("losesesi").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("levelupsesi").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("coinsesi").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("patlamasesi").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("spreysesi").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("gerisayimsesi").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("gerisayimsesiturbo").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("kansesi").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("satissesi").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("motorsesi").GetComponent<AudioSource>().mute = true;
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().mute = true;
    } 
   
    public void MusicSoundOff()
     {
        MusicSoundOnButton.SetActive(true);
        MusicSoundOffButton.SetActive(false);
        GameObject.FindWithTag("arkaplansesi").GetComponent<AudioSource>().mute = false;
        PlayerPrefs.SetInt("sesDurum1", 1);

    }
     public void MusicSoundOn()
     {
         MusicSoundOnButton.SetActive(false);
         MusicSoundOffButton.SetActive(true);
        GameObject.FindWithTag("arkaplansesi").GetComponent<AudioSource>().mute = true;
        PlayerPrefs.SetInt("sesDurum1", 0);
    }
    public void gizlibuttontrue()
    {
        GizliButton = true;
    }
    public void gizlibuttonfalse()
    {
        GizliButton = false;
    }
    public void infotrue()
    {
        infotest = true;
        infopanel.SetActive(true);
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
    }
    public void infofalse()
    {
        infotest = false;
    }
    public void infoback()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        infopanel.SetActive(false);
    }
    public void gizliinfoback()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        gizliinfo.SetActive(false);
    }
   

    public void OnTriggerEnter(Collider other)
    {
        if (turbokontrol == false)
        {
            if (other.CompareTag("engel") && sayac == 0)
            {
                PlayerPrefs.SetInt("reklam", reklamsayaci + 1);
                bug = false;
                shield.SetActive(false);
                carSpeed = 0;
                GameObject.FindWithTag("arac").GetComponent<fuelSystem>().kontrol = false;
                GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
                GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
                GameObject.FindWithTag("teker2").GetComponent<Animator>().enabled = false;
                GameObject.FindWithTag("teker3").GetComponent<Animator>().enabled = false;
                GameObject.FindWithTag("LevelController").GetComponent<LevelController>().GameOver();
                GameObject.FindWithTag("losesesi").GetComponent<AudioSource>().Play();

                if (PlayerPrefs.GetInt("reklam")%3 == 0 && PlayerPrefs.GetInt("reklamkodu") == 0) //reklamkodu 0 ise reklam çýkar 1 ise çýkmaz
                {
                    GameObject.FindWithTag("AddControl").GetComponent<ADController>().ShowInterstitial();
                }
               
                while (GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z > -6.3f)
                {
                    GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z -= 0.5f;
                }

            }
            else if (other.CompareTag("kalkantrigger") && bug == true)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                sayac = 1;
                time = 30f;
                shield.SetActive(true);
                GameObject.FindWithTag("kalkanefekt").GetComponent<ParticleSystem>().Play();
            }
            else if (other.CompareTag("engel") && sayac == 1)
            {
                GameObject.FindWithTag("patlamasesi").GetComponent<AudioSource>().Play();
                sayac = 0;
                time = 30f;
                shield.SetActive(false);
                shieldkirmizi.SetActive(false);
                GameObject.FindWithTag("gerisayimsesi").GetComponent<AudioSource>().Stop();
                GameObject.FindWithTag("kalkanefekt2").GetComponent<ParticleSystem>().Play();
            }
        }
        if (other.CompareTag("finish"))
        {
            GameObject.FindWithTag("levelupsesi").GetComponent<AudioSource>().Play();
            carSpeed = 0;
            GameObject.FindWithTag("arac").GetComponent<fuelSystem>().kontrol = false;
            GameObject.FindWithTag("teker").GetComponent<Animator>().enabled = false;
            GameObject.FindWithTag("teker1").GetComponent<Animator>().enabled = false;
            GameObject.FindWithTag("teker2").GetComponent<Animator>().enabled = false;
            GameObject.FindWithTag("teker3").GetComponent<Animator>().enabled = false;
            GameObject.FindWithTag("LevelController").GetComponent<LevelController>().FinishGame();
            while (GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z > -6.3f)
            {
                GameObject.FindWithTag("MainCamera").GetComponent<CameraControl>().offset.z -= 0.5f;
            }
        }if (other.CompareTag("asagiengel"))
        {
            GameObject.FindWithTag("losesesi").GetComponent<AudioSource>().Play();
            sayac = 0;
            bug = false;
            shield.SetActive(false);
            carSpeed = 0;
            GameObject.FindWithTag("arac").GetComponent<fuelSystem>().kontrol = false;
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
        if (other.CompareTag("coin"))
        {
            GameObject.FindWithTag("coinsesi").GetComponent<AudioSource>().Play();
            GameObject.FindWithTag("LevelController").GetComponent<LevelController>().ChangeMoney(1);
            Destroy(other.gameObject);
        }
   
        if (carSpeed != 0)
        {
            if (other.CompareTag("+5") && turbokontrol == false)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                carSpeed += 0.5f;
            }
            if (other.CompareTag("-5") && turbokontrol == false)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                carSpeed -= 0.5f;
            }
            if (other.CompareTag("+10") && turbokontrol == false)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                carSpeed += 1;
            }
            if (other.CompareTag("-10") && turbokontrol == false)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                carSpeed -= 1;
            }
            if (other.CompareTag("+15") && turbokontrol == false)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                carSpeed += 1.5f;
            }
            if (other.CompareTag("-15") && turbokontrol == false)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                carSpeed -= 1.5f;
            }
           
            if (other.CompareTag("+20") && turbokontrol == false)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                carSpeed += 2;
            }
            if (other.CompareTag("-20") && turbokontrol == false)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                carSpeed -= 2;
            }
            if (other.CompareTag("+25") && turbokontrol == false)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                carSpeed += 3;
            }
            if (other.CompareTag("-25") && turbokontrol==false)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                carSpeed -= 3;
            }
            if (other.CompareTag("karsitok") && turbokontrol == false)
            {
                GameObject.FindWithTag("almasesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                karsitok = true;
                timee = 3f;
                sayac2 = 1;
            }
            if (other.CompareTag("roket") )
            {
                GameObject.FindWithTag("roketsesi").GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                sayac3 = 1;
                timeee = 1f;
                zaman = 9f;
                carSpeedGecici= 40 - carSpeed;
                carSpeed += carSpeedGecici;
                shield.SetActive(true);
                turbokontrol = true;
            }
        }
    }
}