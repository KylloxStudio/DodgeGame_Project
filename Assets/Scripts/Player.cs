using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 3;
    public bool isBeingAttacked = false;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float posX = 0;
        float posY = 0;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            posY += 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            posX -= 1;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            posY -= 1;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            posX += 1;
        }

        float x = transform.position.x + posX * Time.deltaTime * 12.5f;
        float y = transform.position.y + posY * Time.deltaTime * 12.5f;
        transform.position = new Vector3(x, y);

        Vector3 pos = transform.position;
        if (pos.x < -8.3f)
        {
            pos.x = -8.3f;
        }
        else if (pos.x > 8.3f)
        {
            pos.x = 8.3f;
        }

        if (pos.y < -4.7f)
        {
            pos.y = -4.7f;
        }
        else if (pos.y > 4.7f)
        {
            pos.y = 4.7f;
        }
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            if (!isBeingAttacked)
            {
                hp -= 1;
                isBeingAttacked = true;
                StartCoroutine(ChangeColor());
            }
            if (hp <= 0)
            {
                isGameOver = true;
            }
        }
    }

    public IEnumerator ChangeColor()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        for (int i = 0; i < 3; i++)
        {
            sprite.color = new Color(255, 0, 0);
            yield return new WaitForSeconds(0.1f);
            sprite.color = new Color(255, 255, 255);
            yield return new WaitForSeconds(0.1f);
        }
        sprite.color = new Color(255, 255, 255);
        isBeingAttacked = false;
    }
}
