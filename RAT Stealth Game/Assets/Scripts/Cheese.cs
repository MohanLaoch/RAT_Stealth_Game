using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public GameObject Endgame;


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Stop("BackgroundTheme");
            FindObjectOfType<AudioManager>().Play("GameWin");
            Endgame.SetActive(true);
        }
    }
}
