using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int actualLevel = 0, deathEnemy;
    public SpawnerEnemic spawner;
    public bool deathBoss;
    public Jugador jugador;
    public GameStates gameStates;
    public GameObject pantallaNivell, UItext;

    // Start is called before the first frame update
    void Start()
    {
        gameStates = GameStates.pantallaTrascicio;
        pantallaNivell.GetComponentInChildren<Text>().text = $"LEVEL {actualLevel}";
        StartCoroutine(nameof(PlayState));
        StartCoroutine(nameof(PantallaTrascicio));
        StartCoroutine(nameof(GameOver));
        StartCoroutine(nameof(Win));
    }

    // Update is called once per frame
    void Update()
    {
        if (deathEnemy >= 20 && GameObject.Find(spawner.enemic.name + "(Clone)") == null)
        {
            Debug.Log("BossIsManager / " + spawner.bossIsHere + spawner.noMolestar);
            spawner.bossIsHere = true;
        }
        Debug.Log("deathboss" + deathBoss);
        if (deathBoss) gameStates = GameStates.win;
    }

    public void canviNivell()
    {
        //s'abansa un nivell
        Debug.Log("Level: " + actualLevel);

        //es reposiciona al jugador.
        jugador.transform.position = transform.position;
        spawner.jugador = jugador;

        //es reseteijen els contadors d'enemics.
        deathEnemy = 0;
        deathBoss = false;
        spawner.enemyCounter = 20;
        spawner.bossIsHere = false;
        spawner.level = actualLevel;

        //es tornan a spawnear enemics, pero del seguent nivell.
        gameStates = GameStates.play;
    }

    public enum GameStates
    {
        mainMenu, pantallaTrascicio, play, gameOver, win
    }

    public IEnumerator PlayState()
    {
        while (true)
        {
            while (gameStates == GameStates.play)
            {
                UItext.gameObject.SetActive(true);
                pantallaNivell.gameObject.SetActive(false);
                spawner.noMolestar = false;
                if (!jugador.isActiveAndEnabled) gameStates = GameStates.gameOver;

                yield return 0;
            }
            yield return new WaitForSeconds(5);
        }
    }

    public IEnumerator PantallaTrascicio()
    {
        while (true)
        {
            while (gameStates == GameStates.pantallaTrascicio && jugador != null)
            {
                UItext.gameObject.SetActive(false);
                pantallaNivell.gameObject.SetActive(true);
                spawner.noMolestar = true;
                Debug.Log("pepepe");
                canviNivell();

                yield return 0;
            }
            Debug.Log("pepepe2");
            yield return 0;
        }
    }

    public IEnumerator GameOver()
    {
        while (true)
        {
            while (gameStates == GameStates.gameOver)
            {
                UItext.gameObject.SetActive(false);
                spawner.noMolestar = true;

                SceneManager.LoadScene(3);
                yield return 10;
            }
            yield return 0;
        }
    }

    public IEnumerator Win()
    {
        while (true)
        {
            while (gameStates == GameStates.win)
            {
                UItext.gameObject.SetActive(false);
                spawner.noMolestar = true;
                SceneManager.LoadScene(actualLevel + 1);

                yield return 10;
            }
            yield return 0;
        }
    }
}
