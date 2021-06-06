using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //objectes que es crean al principi del joc.
    public Jugador jugador;
    public Enemic enemic;
    public Pared pared;
    public LevelManager levelManager;
    public int score = 0;
    public static GameManager _instance;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager._instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
            play();
        }
        else
        {
            Destroy(this.gameObject);
            GameManager._instance.play();
        }
        //comenza la partida
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        //Es crean els objectes.
        Jugador player = Instantiate(jugador, this.transform);
        //player.transform.position = this.transform.position;

        //la camara segueix al personatge.
        GameObject.Find("Main Camera").GetComponent<SeguimetnCamara>().jugador = player;

        //es canvia el nivell.
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        levelManager.jugador = player;
    }
}
