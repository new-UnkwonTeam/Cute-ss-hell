using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager= GameObject.Find("GameManager").GetComponent<GameManager>();

        scoreText.text = $"score {gameManager.score} p";
        Destroy(gameManager.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) ||
            Input.GetMouseButtonDown(1))
        {
            SceneManager.LoadScene(0);
        }
    }
}
