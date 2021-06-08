using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Money : MonoBehaviour
{
    public static int coinAmount;
    Text coinCounter;
   

    // Start is called before the first frame update
    void Start()
    {
        coinCounter = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        coinCounter.text = coinAmount.ToString();
    }
}
