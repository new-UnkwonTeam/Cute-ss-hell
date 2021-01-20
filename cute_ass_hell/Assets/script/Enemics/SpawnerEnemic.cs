using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemic : MonoBehaviour
{
    [SerializeField]
    private float spawnRadius = 7, time = 1.5f, enemycounter = 20;

    public GameObject[] enemics; 


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemic());
    }

    IEnumerator SpawnEnemic()
    //Això és un test
    {
        if (enemycounter >= 0) {
        
            Vector2 spawnPosicio = GameObject.Find("Jugador").transform.position;
            spawnPosicio += Random.insideUnitCircle.normalized * spawnRadius;

            Instantiate(enemics[Random.Range(0, enemics.Length)], spawnPosicio, Quaternion.identity);
            yield return new WaitForSeconds(time);
            StartCoroutine(SpawnEnemic());
            enemycounter--;
        } 
    }
}
