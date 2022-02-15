using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StealthBarUi : MonoBehaviour
{
    public Slider slider;
    public Image barFill;
    public Gradient gradient;

    //public StealthBarUi detectionBar;
    //in Start: detectionBar.SetSeen(detectionlevelvariable)

    // Start is called before the first frame update

    private void Start()
    {
        barFill.color = gradient.Evaluate(1f);
    }

    public void SetSeen(int detection)
    {
        slider.value = detection;

        barFill.color = gradient.Evaluate(slider.value);
    }

}
