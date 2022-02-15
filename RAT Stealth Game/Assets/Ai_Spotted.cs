using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Spotted : MonoBehaviour
{
    public AiManager AiManager;
    public AI_Detection_Signal DetectionSignal;
    private bool LineofSight;

    private void FixedUpdate()
    {
        if(LineofSight == true && AiManager.DetectionLevel != 1)
        {
            AiManager.DetectionLevel += 0.1f;
        }

        if(AiManager.DetectionLevel >= 1)
        {
            AiManager.Spotter();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            LineofSight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            LineofSight = false;
        }
    }
}
