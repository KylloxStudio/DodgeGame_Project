using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float posX;
    public float posY;

    public float speedX;
    public float speedY;

    // Start is called before the first frame update
    void Start()
    {
        speedX = UnityEngine.Random.Range(10f, 20f);
        speedY = UnityEngine.Random.Range(7.5f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x + posX * Time.deltaTime * speedX;
        float y = transform.position.y + posY * Time.deltaTime * speedY;
        transform.position = new Vector3(x, y);

        if (Math.Abs(transform.position.x) > 10f)
        {
            Destroy(gameObject);
        }
        else if (Math.Abs(transform.position.y) > 5f)
        {
            Destroy(gameObject);
        }
    }
}
