using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float bulletSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.y = pos.y + bulletSpeed * Time.deltaTime;
        transform.position = pos;

        Vector2 maxPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        if (transform.position.y > maxPosition.y)
        {

            Destroy(gameObject);

        }
    }
}
