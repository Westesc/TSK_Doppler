using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadInfiniteScrolling : MonoBehaviour
{


    public float scrollSpeed;
    private Vector2 offset;
    private bool onClick = false;

    public void setButton()
    {
        onClick = !onClick;
    }

    void Update()
    {
        if (onClick)
        {
            offset = new Vector2(Time.time * scrollSpeed, 0);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }
    }
}
