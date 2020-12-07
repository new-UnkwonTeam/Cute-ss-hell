using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour {

    public GameObject personatge;
    public static GameObject personatge2;

    // Start is called before the first frame update
    void Start()
    {
        personatge2 = personatge;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Moures(int x, int y, float speed) {
        personatge2.transform.position = personatge2.transform.position + new Vector3(speed * x * Time.deltaTime, speed * y * Time.deltaTime, 0);
    }
}
