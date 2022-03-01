using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foghide : MonoBehaviour
{
    public GameObject childe;
    public bool collidin;

    // Start is called before the first frame update
    void Start()
    {
        childe = GameObject.Find("Fogsprite");
    }

    void FixedUpdate()
    {
        collidin = gameObject.GetComponentInChildren<fogcolliders>().colidn;

        if (collidin)
        {
            childe.SetActive(false);
        }
        else
        {
            childe.SetActive(true);
        }
    }

}
