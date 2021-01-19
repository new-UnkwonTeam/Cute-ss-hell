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
    public int dany = 10;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("pared"))
        {
            if (!arpa) Destroy(this.gameObject);
            /*else
            {
                Debug.Log("arpa");
                //transform.rotation = Vector3.Reflect(GetComponent<Rigidbody2D>().velocity, collision.GetContacts());
                //transform.rotation = Quaternion.Euler(0, 0, rotacio.z + 250);
            }*/ 
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (guitarra)
            {
                Debug.Log("guitarra");

                RaycastHit2D areaHits = Physics2D.CircleCast(transform.position - Vector3.down, 3, transform.position - Vector3.down);
                
                if (areaHits.collider.CompareTag("Enemy"))
                {
                    Vector3 nextEnemy = areaHits.collider.GetComponent("Enemic").transform.position - transform.position;

                    transform.rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(nextEnemy, Vector3.down * speed * Time.deltaTime, new Vector3(1, -1, 0)));
                }
            }
            else Destroy(this.gameObject);
        }
        Debug.Log("colision with " + collision.gameObject.name);
    }
}
