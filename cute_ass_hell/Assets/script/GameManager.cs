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

    // Start is called before the first frame update
    void Start()
    {
        //comenza la partida
        play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        //Es crean els objectes.
        Jugador player = Instantiate(jugador);
        player.transform.position = this.transform.position;
        Pared wall = Instantiate(pared);
        wall.transform.position = this.transform.position - new Vector3(0, -5, 0);

        //la camara segueix al personatge.
        GameObject.Find("Main Camera").GetComponent<SeguimetnCamara>().jugador = player;

        //es canvia el nivell.
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.canviNivell(0, jugador);
    }
}
