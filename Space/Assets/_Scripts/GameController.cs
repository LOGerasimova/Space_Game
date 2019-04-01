using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GameObject _asteroid;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text LiveText;
    public Text LiveUpText;
    public Text Main;

    private bool gameOver;
    private bool restart;
    public int score;
    public int live;
    public int liveUpScore;
    bool levelup = false;

    //Стартовые значения UI
    void Start()
    {
        score = 0;
        live = 3;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        Main.text = "";
        LiveUpText.text = "";
        LiveText.text = "Live: " + live;
        UpdateScore();
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        //перезапуск уровня
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        //переход в меню с открыванием следующего уровня / простой выход в меню в случае проигрыша
        if (gameOver && levelup)
            if (Input.GetKey(KeyCode.M))
            {
                if (SceneManager.GetActiveScene().buildIndex == Level_Main_script.countUnlockedLevel)
                    Level_Main_script.countUnlockedLevel++;
                SceneManager.LoadScene(0);
            }
        if (gameOver)
            if (Input.GetKey(KeyCode.M))
                SceneManager.LoadScene(0);
    }

    //SpawnAsteroids
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(_asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                Main.text = "Press 'M' for Menu";
                restart = true;
                break;
            }
        }
    }

    //Добавление очков, если уровень не пройден
    public void AddScore(int newScoreValue)
    {
        if (levelup == false)
        {
            score += newScoreValue;
            UpdateScore();
        }
    }

    //Обновление
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    //Конец игры в случае проигрыша
    public void GameOver()
    {
        if (levelup == false)
        {
            gameOverText.text = "Game Over!";
            gameOver = true;
        }
    }

    //Конец игры в случае победы
    public void LiveUp()
    {
        LiveUpText.text = "Live Up!";
        gameOver = true;
        levelup = true;
    }

    //Уровень жизней
    public void UpdateLive()
    {
        if (levelup == false)
        {
            live--;
            LiveText.text = "Live: " + live;
        }
    }
}
