﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorPaletteControllerAraba2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IInitializePotentialDragHandler
{
    public static ColorPaletteControllerAraba2 Current;
    [SerializeField] RectTransform picker;
    [SerializeField] Image pickedColorImage;
    [SerializeField] Material colorWheelMat;
    [SerializeField] int totalNumberofColors = 24;
    [SerializeField] int wheelsCount = 2;
    [SerializeField]
    [Range(0, 360)]
    [Tooltip("clockwise angle of the begnning point starting from positive x-axis")]
    float startingAngle = 0;
    [SerializeField] [InspectorName("Control Sat & Val")] bool controlSV = false;
    [SerializeField] bool inertia = true;
    [SerializeField] float decelerationRate = 0.135f;
    [SerializeField] bool wholeSegment = false;

    [Header("Limits")]
    [SerializeField] [Range(0.5f, 0.001f)] float minimumSatValStep = 0.01f;
    [SerializeField] [Range(0, 1)] float minimumSaturation = 0.25f;
    [SerializeField] [Range(0, 1)] float maximumSaturation = 1;
    [SerializeField] [Range(0, 1)] float minimumValue = 0.25f;
    [SerializeField] [Range(0, 1)] float maximumValue = 1;
    public Material gecicibody, kalicibody, gecicirim, kalicirim;


    //dragging variables
    bool dragging = false;
    float satValAmount = 1;
    float omega = 0;
    float previousTheta;
    float theta;

    float previousDiscretedH;
    float sat = 1, val = 1;
    Color selectedColor;

    public GameObject marketPanel;
    public Color SelectedColor
    {
        get
        {
            return selectedColor;
        }
        private set
        {
            if (value != selectedColor)
            {
                selectedColor = value;
                OnColorChange?.Invoke(SelectedColor);

            }
        }
    }

    void SaveColorBody(Color color)
    {
        PlayerPrefs.SetString("SavedBodyAraba2Color", ColorToHexBody(color));
    }

    void SaveColorRim(Color color)
    {
        PlayerPrefs.SetString("SavedRimAraba2Color", ColorToHexRim(color));
    }



    string ColorToHexBody(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        return hex;
    }
    string ColorToHexRim(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2");
        return hex;
    }

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }

    public void Start()
    {
        Current = this;
        MateyelGuncellemeBody();
        MateyelEsitlemeBody();
        MateyelGuncellemeRim();
        MateyelEsitlemeRim();
    }
    public void MateyelGuncellemeBody()
    {
        gecicibody.color = kalicibody.color;
        if (wholeSegment)
        {
            float discretedHue = ((int)((Hue + startingAngle / 360.0f) * totalNumberofColors)) / (1.0f * (totalNumberofColors));
            colorWheelMat.SetFloat("_Hue", discretedHue);
        }
        else
        {
            colorWheelMat.SetFloat("_Hue", Hue);
        }
        if (controlSV)
        {
            colorWheelMat.SetFloat("_Sat", sat);
            colorWheelMat.SetFloat("_Val", val);
        }
    }
    public void MateyelGuncellemeRim()
    {

        gecicirim.color = kalicirim.color;
        if (wholeSegment)
        {
            float discretedHue = ((int)((Hue + startingAngle / 360.0f) * totalNumberofColors)) / (1.0f * (totalNumberofColors));
            colorWheelMat.SetFloat("_Hue", discretedHue);
        }
        else
        {
            colorWheelMat.SetFloat("_Hue", Hue);
        }
        if (controlSV)
        {
            colorWheelMat.SetFloat("_Sat", sat);
            colorWheelMat.SetFloat("_Val", val);
        }
    }
    public void MateyelEsitlemeBody()
    {
        float shiftedH = (pickerHueOffset + startingAngle / 360.0f + Hue % wheelsCount) / wheelsCount;
        shiftedH = shiftedH % 1.0f;
        float discretedH = ((int)(shiftedH * totalNumberofColors)) / (1.0f * (totalNumberofColors - 1));
        Color color;
        if (shiftedH > 1 - 1.0 / totalNumberofColors && shiftedH <= 1)//for gray
            color = Color.HSVToRGB(0, 0, (val - sat + 0.75f) / 1.5f);
        else
            color = Color.HSVToRGB(discretedH, sat, val);
        if (previousDiscretedH != discretedH)
            if (pickedColorImage)
            {
                pickedColorImage.color = color;
            }
    }
    public void MateyelEsitlemeRim()
    {
        float shiftedH = (pickerHueOffset + startingAngle / 360.0f + Hue % wheelsCount) / wheelsCount;
        shiftedH = shiftedH % 1.0f;
        float discretedH = ((int)(shiftedH * totalNumberofColors)) / (1.0f * (totalNumberofColors - 1));
        Color color;
        if (shiftedH > 1 - 1.0 / totalNumberofColors && shiftedH <= 1)//for gray
            color = Color.HSVToRGB(0, 0, (val - sat + 0.75f) / 1.5f);
        else
            color = Color.HSVToRGB(discretedH, sat, val);
        if (previousDiscretedH != discretedH)
            if (pickedColorImage)
            {
                pickedColorImage.color = color;
            }
    }
    public float Hue { get; private set; } = 1.835f;
    public float Value
    {
        get { return val; }
        set
        {
            float newVal = Mathf.Clamp(value, minimumValue, maximumValue);
            if (Mathf.Abs(val - newVal) > minimumSatValStep)
            {
                val = newVal;
                UpdateMaterial();
                UpdateColor();
            }
        }
    }
    public float Saturation
    {
        get { return sat; }
        set
        {
            float newSat = Mathf.Clamp(value, minimumSaturation, maximumSaturation);
            if (Mathf.Abs(sat - newSat) > minimumSatValStep)
            {
                sat = newSat;
                UpdateMaterial();
                UpdateColor();
            }
        }
    }
    public ColorChangeEvent OnColorChange;
    public HueChangeEvent OnHueChange;

    // Start is called before the first frame update
    void Awake()
    {
        CalculatePresets();
        UpdateMaterialInitialValues();
    }
    void UpdateMaterialInitialValues()
    {

        colorWheelMat.SetFloat("_StartingAngle", startingAngle);
        colorWheelMat.SetInt("_ColorsCount", totalNumberofColors);
        colorWheelMat.SetInt("_WheelsCount", wheelsCount);


    }
    //presets
    Vector2 centerPoint;
    float paletteRadius;
    float pickerHueOffset;
    //if the palette position/size or Picker position change in runtime, this function should be called 
    void CalculatePresets()
    {
        //Assuming the canvas is ScreenSpace-Overlay
        centerPoint = RectTransformUtility.WorldToScreenPoint(null, transform.position);
        RectTransform rect = GetComponent<RectTransform>();
        paletteRadius = rect.sizeDelta.x / 2;
        Vector3 pickerLocalPosition = picker.localPosition;
        float angle = Vector2.SignedAngle(Vector2.right, pickerLocalPosition);
        if (angle < 0) angle += 360;
        pickerHueOffset = angle / 360;

    }

    /// <summary>
    /// Calculate the S and V 
    /// </summary>
    /// <param name="amount">represent the value of S and V combined, it should be between 0 and 2
    /// from 0 to 1 S will be equal to 1 and V = amount
    /// from 1 to 2 V will be equal to 1 and S = 2-amount
    /// </param>
    public void CalculateSaturationAndValue(float amount)
    {

        if (amount > 1)
        {
            val = 1;
            sat = 2 - amount;
        }
        else
        {
            sat = 1;
            val = amount;
        }
        sat = Mathf.Clamp(sat, minimumSaturation, maximumSaturation);
        val = Mathf.Clamp(val, minimumValue, maximumValue);
        UpdateColor();
    }
    public void UpdateHue()
    {
        UpdateMaterial();
        UpdateColor();
    }
    public void UpdateMaterial()
    {
        if (wholeSegment)
        {
            float discretedHue = ((int)((Hue + startingAngle / 360.0f) * totalNumberofColors)) / (1.0f * (totalNumberofColors));
            colorWheelMat.SetFloat("_Hue", discretedHue);
        }
        else
        {
            colorWheelMat.SetFloat("_Hue", Hue);
        }
        if (controlSV)
        {
            colorWheelMat.SetFloat("_Sat", sat);
            colorWheelMat.SetFloat("_Val", val);
        }

    }
    public void UpdateColor()
    {
        float shiftedH = (pickerHueOffset + startingAngle / 360.0f + Hue % wheelsCount) / wheelsCount;
        shiftedH = shiftedH % 1.0f;
        float discretedH = ((int)(shiftedH * totalNumberofColors)) / (1.0f * (totalNumberofColors - 1));
        Color color;
        if (shiftedH > 1 - 1.0 / totalNumberofColors && shiftedH <= 1)//for gray
            color = Color.HSVToRGB(0, 0, (val - sat + 0.75f) / 1.5f);
        else
            color = Color.HSVToRGB(discretedH, sat, val);
        if (previousDiscretedH != discretedH)
            OnHueChange?.Invoke(discretedH);
        if (pickedColorImage)
        {
            pickedColorImage.color = color;
            SelectedColor = color;
            if (VehicleColorAraba2.Current.chechFonkBody == true)
            {
                MateyelGuncellemeBody();
                SaveColorBody(kalicibody.color);
                VehicleColorAraba2.Current.chechFonkBody = false;
            }
            else if (VehicleColorAraba2.Current.checkFonkRim == true)
            {
                MateyelGuncellemeRim();
                SaveColorRim(kalicirim.color);
                VehicleColorAraba2.Current.checkFonkRim = false;
            }
            else if (VehicleColorAraba2.Current.chechFonkBody == false && VehicleColorAraba2.Current.checkFonk2 == true || VehicleColorAraba2.Current.checkFonkRim == false && VehicleColorAraba2.Current.checkFonk2 == true)
            {
                MateyelEsitlemeBody();
                MateyelEsitlemeRim();
            }
            previousDiscretedH = discretedH;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!dragging)
            return;

        if (eventData.button != PointerEventData.InputButton.Left)
            return;

        Vector2 dragVec = eventData.delta;
        Vector2 currentPos = eventData.position;
        Vector2 prevPos = currentPos - dragVec;

        //calculate Saturation and Value change
        if (controlSV)
        {
            float r1 = Vector2.Distance(centerPoint, prevPos);
            float r2 = Vector2.Distance(centerPoint, currentPos);
            float dr = r2 - r1;
            satValAmount += dr / paletteRadius;
            satValAmount = Mathf.Clamp(satValAmount, 0, 2);
            CalculateSaturationAndValue(satValAmount);
        }

        //calculate Hue change
        float dtheta = Vector2.SignedAngle(currentPos - centerPoint, prevPos - centerPoint);
        theta += dtheta;

        Hue += dtheta / 360;
        if (Hue < 0) Hue += wheelsCount;

        UpdateHue();

    }
    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        omega = 0;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        dragging = true;
        omega = 0;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button != PointerEventData.InputButton.Left)
            return;
        dragging = false;
    }
    public void Update()
    {

        kalicibody.SetColor(0, gecicibody.color);
        float deltaTime = Time.unscaledDeltaTime;
        if (dragging && inertia)
        {
            float newOmega = (theta - previousTheta) / Time.deltaTime;
            omega = Mathf.Lerp(omega, newOmega, deltaTime * 10);
            previousTheta = theta;
        }
        if (!dragging && omega != 0)
        {
            omega *= Mathf.Pow(decelerationRate, deltaTime);
            if (Mathf.Abs(omega) < 1)
                omega = 0;
            float dtheta = omega * deltaTime;
            Hue += dtheta / 360;
            if (Hue < 0) Hue += wheelsCount;
            UpdateHue();
        }
    }
}
