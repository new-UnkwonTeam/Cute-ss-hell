using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreTextScript : MonoBehaviour
{
    public int coinAmount;
    public TMP_Text coinCounter;
   

    // Start is called before the first frame update
    void Start()
    {

        coinAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinCounter.text = "Monedes: " + coinAmount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Coin>())
        {
            coinAmount += 1;
        }
    }
}
