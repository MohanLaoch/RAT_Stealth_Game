using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Ai_Spotted : MonoBehaviour
{
    private AiManager AiManager;
    private AI_Detection_Signal DetectionSignal;
    private bool LineofSight;

    private FieldOfView thisFOV;

    private GameObject Player;

    public LayerMask NewLayerMask;

    private void Start()
    {
        AiManager = gameObject.GetComponent<FieldOfView>().AiManager;
        thisFOV = gameObject.GetComponent<FieldOfView>();
        DetectionSignal = AiManager.DetectionSignal;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

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

    public void Update()
    {
        FindTargetPlayer();
    }

    public void FindTargetPlayer()
    {
        if (Vector3.Distance(AiManager.fieldOfView.origin, Player.transform.position) < AiManager.fieldOfView.viewDistance)
        {
            // Player inside viewDistance WORKS!!!!!!!
            Vector3 dirToPlayer = (Player.transform.position - thisFOV.origin);
            if (Vector3.Angle(thisFOV.origin, dirToPlayer) < thisFOV.fov / 2f)
            {
                //THIS PART WORKS NOW!!!!!!!!!
                RaycastHit2D raycastHit2D = Physics2D.Raycast(thisFOV.origin, dirToPlayer.normalized, thisFOV.viewDistance, NewLayerMask);
                if(raycastHit2D.collider != null)
                {
                    if(raycastHit2D.collider.gameObject.tag == "Player")
                    {
                        LineofSight = true;
                    }
                }
                else
                {
                    LineofSight = false;
                }
            }
            else
            {
                LineofSight = false;
            }
        }
        else
        {
            LineofSight = false;
        }
    }
}
