using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsteroid_script : MonoBehaviour {
    public int scoreValue;
    private GameController gameController;
    public GameObject ship;
    bool scoreFlag = true;
    int levelUp;

    //проверка наличия GameController
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        //столкновение астероида с кораблем
        //если не осталось жизней, то GameOver
        //иначе уменьшение жизни на 1
        if (other.gameObject.CompareTag("Player"))
        {
            scoreFlag = false;
            gameController.UpdateLive();
            if (gameController.live > 0)
            {
                GameObject clone = Instantiate(ship, other.transform.position, other.transform.rotation) as GameObject;
                Destroy(gameObject);
            }
            else gameController.GameOver();
        }

        //если столкновение с пулей, то идёт подсчет заработанных очков
        if (other.gameObject.CompareTag("Bullet"))
            scoreFlag = true;

        if (scoreFlag == true)
        {
            gameController.AddScore(scoreValue);

            if (gameController.score >= gameController.liveUpScore)
                gameController.LiveUp();
        }

        //уничеожение любого объекта столкнувшегося с астероидом и самого астероида
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
