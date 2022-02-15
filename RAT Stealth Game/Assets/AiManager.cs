using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AiManager : MonoBehaviour
{
    public AIDestinationSetter DestSetter;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            DestSetter.target = col.transform;
        }
    }
    public void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            DestSetter.target = col.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            DestSetter.target = null;
        }
    }
}
