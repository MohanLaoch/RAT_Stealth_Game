using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    public Sprite doorOpen;
    public Sprite doorClosed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spriteRenderer.sprite = doorOpen;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spriteRenderer.sprite = doorClosed;
        }
    }

}
