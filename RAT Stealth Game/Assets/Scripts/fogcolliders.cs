using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogcolliders : MonoBehaviour
{
    public bool colidn;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            colidn = true;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            colidn = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            colidn = false;
        }
    }
}
