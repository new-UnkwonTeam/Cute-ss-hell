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
    public int dany = 10;
    public bool arpa, guitarra;
    public int rebots = 3;
    public int hitsGuitara = 3;

    // Start is called before the first frame update
    void Start()
    {
        actualTime = Time.time;
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
            if (arpa && rebots>0)
            {
                Debug.Log("arpa");
                rebots--;
            }
            else Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Boss"))
        {
            if (guitarra && hitsGuitara>0)
            {
                Debug.Log("guitarra");

                RaycastHit2D[] areaHits = Physics2D.CircleCastAll(transform.position - Vector3.down, 2, transform.position - Vector3.down);

                bool thereIsNoEnemy = true;

                for (int i = 0; (i < areaHits.Length) && thereIsNoEnemy; i++)
                {
                    if (areaHits[i].collider.CompareTag("Enemy") || areaHits[i].collider.CompareTag("Boss"))
                    {
                        Vector3 nextEnemy = areaHits[i].collider.GetComponent<Enemic>().transform.position - transform.position;

                        transform.rotation = Quaternion.Euler(0, 0, Vector3.SignedAngle(nextEnemy, Vector3.down * speed * Time.deltaTime, new Vector3(1, -1, 0)));

                        thereIsNoEnemy = false;
                        hitsGuitara--;
                    }
                }

                if(thereIsNoEnemy) Destroy(this.gameObject);

            }
            else Destroy(this.gameObject);
        }
        Debug.Log("colision with " + collision.gameObject.name);
    }
}
