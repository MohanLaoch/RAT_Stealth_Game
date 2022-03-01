using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogdestroy : MonoBehaviour
{
    public GameObject pater;

    // Start is called before the first frame update
    void Start()
    {
        pater = transform.parent.gameObject;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(pater);
    }
}
