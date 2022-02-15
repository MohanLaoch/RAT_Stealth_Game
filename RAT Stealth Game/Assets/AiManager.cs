using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AiManager : MonoBehaviour
{
    public AIDestinationSetter DestSetter;
    public Ai_Spotted Spotted;
    public AI_Detection_Signal DetectionSignal;

    public GameObject Player;
    public GameObject PlayerLastSeen;

    [Range(0,1)]
    public float DetectionLevel;

    public bool Chasing;

    public void Update()
    {
        if(DetectionLevel > 1)
        {
            DetectionLevel = 1;
        }
        else if(DetectionLevel < 0)
        {
            DetectionLevel = 0;
        }

        if(Chasing == true)
        {
            DestSetter.target = PlayerLastSeen.transform;
            PlayerLastSeen.transform.position = Player.transform.position;
        }
    }

    public void Spotter()
    {
        DestSetter.target = PlayerLastSeen.transform;
        Chasing = true;
    }
}
