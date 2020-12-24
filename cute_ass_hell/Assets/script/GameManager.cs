using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager    : MonoBehaviour
{
    //objectes que es crean al principi del joc.
    public Enemic enemic;
    public Pared pared;

    // Start is called before the first frame update
    void Start()
    {
        //Es crean els objectes.
        Enemic enemy = Instantiate(enemic) as Enemic;
        enemy.transform.position = this.transform.position - new Vector3(10, 0, 0);

        Pared wall = Instantiate(pared) as Pared;
        wall.transform.position = this.transform.position - new Vector3(0, -5, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
