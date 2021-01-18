using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    //velocitat del proyectil
    public float speed;
    //temps abans que s'elimini el proyectil.
    public float timeToDelete;
    float actualTime;
    Vector3 rotacio;
    public bool arpa, guitarra;

    // Start is called before the first frame update
    void Start()
    {
        actualTime = Time.time;
        rotacio = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //en cada update es mou en la direccio marcada al crear el proyectil.
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        //si el temps limit s'acaba s'elimina el proyectil.
        if (actualTime + (timeToDelete * Time.deltaTime) < Time.time)
        {
            Destroy(this.gameObject);
        }  
    }

    //si el proyectil choca contra un objecte que no sigui el jugador o un altre proyectil s'elimina.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision.CompareTag("Player") || collision.CompareTag("ProyectilPlayer")))
        {
            if (collision.CompareTag("pared") && arpa)
            {
                Debug.Log("arpa");
                //transform.rotation = Vector3.Reflect(GetComponent<Rigidbody2D>().velocity, collision.GetContacts());
                transform.rotation = Quaternion.Euler(0, 0, rotacio.z + 250);
            }
            else Destroy(this.gameObject);

            if (collision.CompareTag("Enemy") && guitarra)
            {
                Debug.Log("guitarra");
            }else Destroy(this.gameObject);

            Debug.Log("colision with " + collision.name);
        }
    }
}
