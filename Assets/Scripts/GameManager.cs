using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public GameObject enemyGroup;
    public float spawnPercent;

    public Text scoreText;
    public Text hpText;
    public GameObject gameoverPanel;

    public float timer = 0f;
    public bool isPlaying = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            if (player.isGameOver)
            {
                Time.timeScale = 0f;
                isPlaying = false;
            }
            timer += Time.deltaTime;
            scoreText.text = "Score: " + timer.ToString("N2");
            hpText.text = "HP: " + player.hp;
            if (player.isBeingAttacked)
            {
                return;
            }
            float random = Random.Range(0f, 100f);
            if (random <= spawnPercent)
            {
                int zone = Random.Range(0, 4);
                Enemy e = Instantiate(enemy);
                switch (zone)
                {
                    case 0:
                        e.transform.position = new Vector3(Random.Range(-8.3f, 8.3f), 4.7f);
                        e.posY = -1;
                        break;
                    case 1:
                        e.transform.position = new Vector3(8.3f, Random.Range(-4.7f, 4.7f));
                        e.posX = -1;
                        break;
                    case 2:
                        e.transform.position = new Vector3(Random.Range(-8.3f, 8.3f), -4.7f);
                        e.posY = 1;
                        break;
                    case 3:
                        e.transform.position = new Vector3(-8.3f, Random.Range(-4.7f, 4.7f));
                        e.posY = -1;
                        break;
                    default:
                        Debug.Log("Error");
                        return;
                }
            }
        }
        else
        {
            if (!gameoverPanel.activeInHierarchy)
            {
                gameoverPanel.SetActive(true);
            }
        }
    }
}
