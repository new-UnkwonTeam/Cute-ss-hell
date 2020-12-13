using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe corresponet als metodes de moviment.
public class Moviment : MonoBehaviour {
    public static float thrust = 1.0f;
    public static Rigidbody2D rb;

    /**
     * Moure un element en una direccio determinada per els valors x i y.
     * @pram x vector que determina quian distacia en l'eix x es moura l'element.
     * @pram y vector que determina quian distacia en l'eix y es moura l'element.
     * @pram speed velocitat a la que es moura el element.
     */
    public static void Moures(float x, float y, float speed, GameObject personatge) {
        personatge.transform.position += new Vector3(speed * x * Time.deltaTime, speed * y * Time.deltaTime, 0);

        //personatge.transform.Translate(speed * x * Time.deltaTime, speed * y * Time.deltaTime, 0);

        //rb = personatge.GetComponent<Rigidbody2D>();
        //rb.AddForce(new Vector3(speed * x * Time.deltaTime, speed * y * Time.deltaTime, 0), ForceMode2D.Impulse);
    }
}
