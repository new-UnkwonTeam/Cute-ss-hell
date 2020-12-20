using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Classe corresponet als metodes de moviment.
public class Moviment : MonoBehaviour {

    /**
     * Moure un element en una direccio determinada per els valors x i y.
     * @pram x vector que determina quian distacia en l'eix x es moura l'element.
     * @pram y vector que determina quian distacia en l'eix y es moura l'element.
     * @pram speed velocitat a la que es moura el element.
     */
    public static void Moures(Vector3 move, float speed, Rigidbody2D rb, GameObject personatge) {
        personatge.transform.Translate(move * speed * Time.deltaTime);
        rb.MovePosition(rb.position * speed * move * Time.deltaTime);
    }
}
