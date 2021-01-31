using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager    : MonoBehaviour
{
    //objectes que es crean al principi del joc.
    public Jugador jugador;
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
        player.pause = true;
        //la camara segueix al personatge.
        GameObject.Find("Main Camera").GetComponent<SeguimetnCamara>().jugador = player;

        //es canvia el nivell
        levelManager.canviNivell(0, player);
    }

    public void gameOver()
    {
        mort = false;
        levelManager.spawner.noMolestar = true;

        //menu gameOver.
        panelGameOver.gameObject.SetActive(true);
    }

    public void menu()
    {
        Debug.Log("menu");
        SceneManager.LoadScene("MenuScene");
    }
}
