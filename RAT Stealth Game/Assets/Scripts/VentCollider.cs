using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentCollider : MonoBehaviour
{

    //This Class is the collider controller class for the player

    PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //When the Player Enters the Vent Area
        if (other.gameObject.tag == "Vent")
        {
            //If the Player is activated skip
            //This is used to move the imposter around without activating the triggers
            if (playerMovement.IsInVent())
            {
                other.gameObject.GetComponent<Vent>().EnableVent(playerMovement);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //When the Player Exits the Vent Area
        if (other.gameObject.tag == "Vent")
        {
            //If the Imposter is activated skip
            //to not allow killing from the vent
            /*if (playerMovement.IsInVent())
            { 
                other.gameObject.GetComponent<Vent>().DisableVent();
            }*/
        }
    }
}