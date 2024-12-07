using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public Vector2 scrollDirection = Vector2.right;
    private RawImage rawImage;
    private Vector2 offset;

    void Start()
    {
        rawImage = GetComponent<RawImage>();
        if (rawImage == null)
        {
            Debug.LogError("ScrollingBackground requires a RawImage component.");
        }
    }

    void Update()
    {
        if (rawImage != null)
        {
            offset += scrollDirection * scrollSpeed * Time.deltaTime;
            rawImage.uvRect = new Rect(offset.x, offset.y, rawImage.uvRect.width, rawImage.uvRect.height);
        }
    }
}
