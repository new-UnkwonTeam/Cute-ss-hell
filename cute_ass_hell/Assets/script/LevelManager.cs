using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int actualLevel = 0, deathEnemy;
    public SpawnerEnemic spawner;
    public bool deathBoss;
    public Jugador jugador;
    public GameObject pantallaNivell;
    private string[] titolsNivell;
    public float timePantallaNivell;

    // Start is called before the first frame update
    void Start()
    {
        pantallaNivell.SetActive(false);
        titolsNivell = new string[] { "NIVELL 1: THE MADNESS", "NIVELL 2: EL PANTA", "NIVELL 3: EL LLAC CONGELAT" };
        spawner = GameObject.Find("SpawnerEnemic").GetComponent<SpawnerEnemic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathEnemy >= 20 && GameObject.Find(spawner.enemics[actualLevel].name + "(Clone)") == null)
        {
            Debug.Log("BossIsManager / " + spawner.bossIsHere + spawner.noMolestar);
            spawner.bossIsHere = true;
        }
        Debug.Log("deathboss" + deathBoss);
        if (deathBoss) canviNivell((actualLevel + 1), jugador);
    }

    public void canviNivell(int newLevel, Jugador player)
    {
        player.pause = true;

        if (newLevel < 3)
        {
            //s'abansa un nivell
            actualLevel = newLevel;
            Debug.Log("Level: " + (actualLevel + 1));

            //pantalla de trancicio
            Debug.Log("ESTO TENDRIA QUE SER UNA PANTALLA DE CARGA");
            pantallaNivell.SetActive(true);
            Debug.Log("pantalla" + pantallaNivell.activeSelf);
            pantallaNivell.GetComponentInChildren<Text>().text = titolsNivell[actualLevel];

            //es reposiciona al jugador.
            jugador = player;
            jugador.transform.position = transform.position;
            spawner.jugador = jugador;

            //es reseteijen els contadors d'enemics.
            deleteAll();
            deathEnemy = 0;
            deathBoss = false;
            spawner.enemyCounter = 20;
            spawner.bossIsHere = false;
            spawner.level = actualLevel;

            Debug.Log("epera");
            float temps = 0;
            while (Time.time > temps)
            {
                temps = Time.deltaTime + timePantallaNivell;
            }
            pantallaNivell.SetActive(false);
            Debug.Log("pantalla" + pantallaNivell.activeSelf);
            jugador.pause = false;

            //es tornan a spawnear enemics, pero del seguent nivell.
            spawner.noMolestar = false;
        }
        else fiDeRun();
    }

    public void fiDeRun()
    {
        Debug.Log("I-i-i eso es todo amigos");
    }

    public void wait(float time)
    {
        Debug.Log("epera");
        float temps = 0;
        while(Time.time > temps)
        {
            temps = Time.time + time;
        }
    }
    IEnumerator waiter(float time)
    {
        Debug.Log("epera");
        yield return new WaitForSecondsRealtime(time * Time.deltaTime);
    }

    public void deleteAll()
    {
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.CompareTag("Moneda") || go.CompareTag("ProyectilPlayer")) Destroy(go);
        }
    }
}
