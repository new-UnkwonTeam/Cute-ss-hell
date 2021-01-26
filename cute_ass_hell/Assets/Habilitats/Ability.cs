using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public float speed;
    public float timeToDelete;
    float actualTime;
    Vector3 rotacio;
    public int dany = 50;

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
}
