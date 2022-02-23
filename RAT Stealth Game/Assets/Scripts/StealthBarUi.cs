using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StealthBarUi : MonoBehaviour
{
    public Slider slider;
    public Image barFill;
    public Gradient gradient;
    public float slidernumber;
    public AiManager manager;

    //public StealthBarUi detectionBar;
    //in Start: detectionBar.SetSeen(detectionlevelvariable)

    // Start is called before the first frame update

    private void Start()
    {
        manager = gameObject.GetComponentInParent<AiManager>();

        barFill.color = gradient.Evaluate(1f);
    }

    public void SetSeen(float detection)
    {
        slider.value = detection;

        barFill.color = gradient.Evaluate(slider.value);
    }

    private void FixedUpdate()
    {
        slidernumber = manager.DetectionLevel;
        SetSeen(slidernumber);
    }

}
