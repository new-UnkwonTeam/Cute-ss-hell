using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe corresponet als metodes de moviment.
public class Moviment : MonoBehaviour {

    // Start is called before the first frame update
    void Start()
    {
      
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
    public static void Moures(int x, int y, float speed, GameObject personatge) {
        personatge.transform.position = personatge.transform.position + new Vector3(speed * x * Time.deltaTime, speed * y * Time.deltaTime, 0);
    }
}
