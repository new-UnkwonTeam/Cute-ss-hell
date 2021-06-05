using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjjectilEnemic : MonoBehaviour
{
    public int damage;
    [SerializeField] private float destroyAfterSeconds = 5f;
    [SerializeField] public float launchForce = 10f;
    [SerializeField] private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //si el temps limit s'acaba s'elimina el proyectil.
        Invoke(nameof(DestroySelf), destroyAfterSeconds);
    }

    private void Update()
    {
        transform.Translate(Vector3.left * launchForce * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pared")) Destroy(this.gameObject);

        Debug.Log($"Touched enemy {collision.gameObject.name}");
        if (collision.gameObject.TryGetComponent<Jugador>(out Jugador player))
        {
            player.RestarVida(damage);
            DestroySelf();
        }

    }

    private void DestroySelf()
    {
        Debug.Log("proyectile kaboom");
        Destroy(gameObject);
    }
}
