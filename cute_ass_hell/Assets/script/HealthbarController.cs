using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarController : MonoBehaviour
{
    public Image barraDeVida;
    public int vida=0;
    public static float startHealth=40;
    public Jugador jugador;

    private void Update()
    {
            jugador.startHealth = vida-1;
            barraDeVida.fillAmount = (vida / startHealth)/100;
        }
    }

