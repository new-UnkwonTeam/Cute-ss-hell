using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemic : MonoBehaviour
{

    //vida del enemic
    public int vida=50;
    public int qualityScore;
    public bool bateria = false;
    public GameObject moneda;
    public EnemyStates currrentStates;
    Animator animator;
    // Start is called before the first frame update

    void Start()
    {
        //animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bateria)
        {
            RestarVida(5);
            bateria = false;
        }
        
    }

    public enum EnemyStates
    {
        move, attack, death
    }

    //Detecta si algo colisiona amb l'enemic.
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        //si la colisio es un proyectil del jugador es resta vida.
        if (collision.gameObject.CompareTag("ProyectilPlayer"))
        {
            RestarVida(collision.gameObject.GetComponent<Proyectil>().dany);

            Debug.Log("Enemic hit by" + collision.gameObject.name);
        }
    }

    //Resta vida del enemic segons la cantitat introduida per parametre.
    void RestarVida(int vidaNegativa)
    {
        vida -= vidaNegativa;

        //si la vida es menor de 1 el enemic mor.
        if (vida < 1) morir();
    }

    //si hi ha alguna animacio al morir es posa en aquest metode
    void morir()
    {
        currrentStates = Enemic.EnemyStates.attack;
        

        GameObject.Find("GameManager").GetComponent<GameManager>().score += qualityScore;
        if (this.CompareTag("Enemy")) GameObject.Find("LevelManager").GetComponent<LevelManager>().deathEnemy++;
        else GameObject.Find("LevelManager").GetComponent<LevelManager>().deathBoss = true;

        for(int i = 0; i<Random.Range(3, 5); i++)
        {
            Instantiate(moneda, transform.position + new Vector3(Random.Range(0, 0.5f), Random.Range(0, 0.5f), 0), Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
