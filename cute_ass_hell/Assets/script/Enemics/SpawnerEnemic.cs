using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemic : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 1.5f;
    public float enemyCounter = 20;

    public GameObject[] enemics;
    public GameObject[] boss;
    public Jugador jugador;

    public bool noMolestar = true;
    public bool bossIsHere = false;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemic());
    }

    IEnumerator SpawnEnemic()
    //Això és un test
    {
        if(!noMolestar){
            Vector2 spawnPosicio = jugador.transform.position;
            spawnPosicio += Random.insideUnitCircle.normalized * spawnRadius;

            if (enemyCounter >= 0)
            {
                Instantiate(enemics[level], spawnPosicio, Quaternion.identity);
                yield return new WaitForSeconds(time);
                StartCoroutine(SpawnEnemic());
                enemyCounter--;
            }else
            {
                Debug.Log("BossIsHere / "+bossIsHere);
                if (bossIsHere)
                {
                    Instantiate(boss[level], spawnPosicio, Quaternion.identity);
                    noMolestar = true;

                    yield return new WaitForSeconds(time);
                    StartCoroutine(SpawnEnemic());
                }
                else
                {
                    yield return new WaitForSeconds(time);
                    StartCoroutine(SpawnEnemic());
                }
            }
        }
        else
        {
            yield return new WaitForSeconds(time);
            StartCoroutine(SpawnEnemic());
        }
    }
}
