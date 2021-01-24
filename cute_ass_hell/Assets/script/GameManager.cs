using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager    : MonoBehaviour
{
    //objectes que es crean al principi del joc.
    public Jugador jugador;
    public Enemic enemic;
    public Pared pared;
    public LevelManager levelManager;
    public static bool mort = false;
    public GameObject panelGameOver;

    // Start is called before the first frame update
    void Start()
    {
        panelGameOver.gameObject.SetActive(false);

        //comenza la partida
        play();
    }

    // Update is called once per frame
    void Update()
    {
        if (mort) gameOver();
    }

    public void play()
    {
        //Es crean els objectes.
        Jugador player = Instantiate(jugador);
        player.transform.position = this.transform.position;
        player.pause = false;
        Pared wall = Instantiate(pared);
        wall.transform.position = this.transform.position - new Vector3(0, -5, 0);

        //la camara segueix al personatge.
        GameObject.Find("Main Camera").GetComponent<SeguimetnCamara>().jugador = player;

        //es canvia el nivell
        levelManager.canviNivell(0, jugador);
    }

    public void gameOver()
    {
        mort = false;
        levelManager.spawner.noMolestar = true;
        deleteAll();

        //menu gameOver.
        panelGameOver.SetActive(true);

        play();
    }

    public void deleteAll()
    {
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.CompareTag("Enemy") || go.CompareTag("Boss") || go.CompareTag("Moneda") || go.CompareTag("ProyectilPlayer")) Destroy(go);
        }
        
    }
}
