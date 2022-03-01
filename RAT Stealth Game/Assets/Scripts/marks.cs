using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class marks : MonoBehaviour
{
    public GameObject qmark;
    public GameObject emark;
    public float detectnumber;
    public bool ischasing;
    public AiManager manager;

    private void Start()
    {
        manager = gameObject.GetComponentInParent<AiManager>();
    }

    private void FixedUpdate()
    {
        detectnumber = manager.DetectionLevel;
        ischasing = manager.Chasing;

        if (detectnumber > 0 & !ischasing)
        {
            qmark.SetActive(true);
            emark.SetActive(false);
        }
        else if (ischasing)
        {
            emark.SetActive(true);
            qmark.SetActive(false);
        }
        else
        {
            emark.SetActive(false);
            qmark.SetActive(false);
        }

    }

}