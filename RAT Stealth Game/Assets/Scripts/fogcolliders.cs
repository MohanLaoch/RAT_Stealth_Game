using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogcolliders : MonoBehaviour
{
    public bool colidn;

    void OnTriggerEnter2D(Collider2D col)
    {
        colidn = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        colidn = false;
    }
}
