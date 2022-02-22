using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Detection_Signal : MonoBehaviour
{
    public AiManager AiManager;
    private Ai_Spotted Spotted;

    public bool PlayerinArea;

    private void Start()
    {
        Spotted = AiManager.fieldOfView.GetComponent<Ai_Spotted>();
    }

    public void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Player" && AiManager.Chasing == true)
        {
            AiManager.DetectionLevel += 0.1f;
        }
        else if(col.tag == "Player")
        {
            PlayerinArea = true;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            PlayerinArea = false;
        }
    }

    public void FixedUpdate()
    {
        if(AiManager.DetectionLevel <= 0)
        {
            AiManager.Chasing = false;
        }
        else if(PlayerinArea != true && AiManager.Chasing == true)
        {
            AiManager.DetectionLevel -= 0.01f;
        }

        if(Spotted == null)
        {
            Spotted = AiManager.fieldOfView.GetComponent<Ai_Spotted>();
        }
    }
}
