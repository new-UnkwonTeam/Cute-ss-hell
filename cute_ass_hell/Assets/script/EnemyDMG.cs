using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDMG : MonoBehaviour
{
    public HealthbarController barraDeVida;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (barraDeVida)
            {
                Debug.Log("Take dmg" );
                //barraDeVida.onTakeDamage(1);
            }
        }
    }
}
