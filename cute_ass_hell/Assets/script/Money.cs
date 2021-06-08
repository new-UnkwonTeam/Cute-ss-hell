using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int moneyAmount;

    [SerializeField]
    public Text coinCounter;
    // Start is called before the first frame update
    void Start()
    {
        moneyAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinCounter.text = "Monedes:" + moneyAmount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            moneyAmount += 1;
            Destroy(collision.gameObject);
        }
    }
}
