using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeBarScript : MonoBehaviour
{
    public Slider slider;
    //public Gradient gradient;



    public void setSlider(int val)
    {
        slider.value = val; 
    }
}
