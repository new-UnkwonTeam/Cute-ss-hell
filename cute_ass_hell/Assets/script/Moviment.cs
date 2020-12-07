using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe corresponet als metodes de moviment.
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

    /**
     * Moure un element en una direccio determinada per els valors x i y.
     * @pram x vector que determina quian distacia en l'eix x es moura l'element.
     * @pram y vector que determina quian distacia en l'eix y es moura l'element.
     * @pram speed velocitat a la que es moura el element.
     */
    public static void Moures(int x, int y, float speed) {
        personatge2.transform.position = personatge2.transform.position + new Vector3(speed * x * Time.deltaTime, speed * y * Time.deltaTime, 0);
    }
}
