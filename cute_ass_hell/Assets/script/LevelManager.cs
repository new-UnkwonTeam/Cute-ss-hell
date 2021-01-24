using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int actualLevel = 0, deathEnemy;
    public SpawnerEnemic spawner;
    public bool deathBoss;
    public Jugador jugador;
    // Start is called before the first frame update
    void Start()
    {
        spawner = GameObject.Find("SpawnerEnemic").GetComponent<SpawnerEnemic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathEnemy >= 20 && GameObject.Find(spawner.enemics[actualLevel].name+ "(Clone)") == null)
        {
            Debug.Log("BossIsManager / " + spawner.bossIsHere + spawner.noMolestar);
            spawner.bossIsHere = true;
        }
        Debug.Log("deathboss" + deathBoss);
        if (deathBoss) canviNivell((actualLevel + 1), jugador);
    }

    public void canviNivell(int newLevel, Jugador player)
    {

        if (newLevel < 3)
        {
            //s'abansa un nivell
            actualLevel = newLevel;
            Debug.Log("Level: " + (actualLevel + 1));

            //es reposiciona al jugador.
            jugador = player;
            jugador.transform.position = transform.position;
            spawner.jugador = jugador;

            //fa falta ficar una transcicio grafica

            //es reseteijen els contadors d'enemics.
            deathEnemy = 0;
            deathBoss = false;
            spawner.enemyCounter = 20;
            spawner.bossIsHere = false;
            spawner.level = actualLevel;

            //es tornan a spawnear enemics, pero del seguent nivell.
            spawner.noMolestar = false;
        }
        else fiDeRun();
    }

    public void fiDeRun()
    {
        Debug.Log("I-i-i eso es todo amigos");
    }
}
