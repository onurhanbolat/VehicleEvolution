using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class speedometer : MonoBehaviour
{

    public static speedometer Current;

    public Rigidbody target;

    public float maxSpeed = 0.0f; 

    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;

    [Header("UI")]
    public RectTransform arrow; 

    private float speed = 0.0f;

    public void Start()
    {
        Current = this;
    }
    private void Update()
    {
        if (LevelController.Current.currentLevel == 1)
        {
            speed = GameObject.FindWithTag("arac").GetComponent<MotorCont>().carSpeed - 1.5f * Time.fixedDeltaTime;
        }
        if (LevelController.Current.currentLevel == 2)
        {
            speed = GameObject.FindWithTag("arac").GetComponent<MotorCont>().carSpeed - 1.5f * Time.fixedDeltaTime;
        }
        if (LevelController.Current.currentLevel == 3)
        {
            speed = GameObject.FindWithTag("arac").GetComponent<MotorCont>().carSpeed - 1.5f * Time.fixedDeltaTime;
        }
        if (LevelController.Current.currentLevel == 4)
        {
            speed = GameObject.FindWithTag("arac").GetComponent<MotorCont>().carSpeed - 1.5f * Time.fixedDeltaTime;
        }
        if (LevelController.Current.currentLevel == 5)
        {
            speed = GameObject.FindWithTag("arac").GetComponent<MotorCont>().carSpeed - 1.5f * Time.fixedDeltaTime;
        }
        if (LevelController.Current.currentLevel == 6)
        {
            speed = GameObject.FindWithTag("arac").GetComponent<MotorCont>().carSpeed - 1.5f * Time.fixedDeltaTime;
        }




        if (arrow != null) { 
            arrow.localEulerAngles = new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed)); //Ýbre açý artýþýný maksspeedi düþürerek yap
    
        }
    }
}