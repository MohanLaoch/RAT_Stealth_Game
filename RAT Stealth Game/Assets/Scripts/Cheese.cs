using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cheese : MonoBehaviour
{
    public Image UICheese;

    public PlayerMovement player;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            UICheese.color = new Color(UICheese.color.r, UICheese.color.g, UICheese.color.b, 255f);
            player.hasCheese = true;
            Destroy(gameObject);
        }
    }

}
