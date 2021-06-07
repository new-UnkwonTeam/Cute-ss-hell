using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevelBox : MonoBehaviour
{
    public int actualLevel;
    public GameObject keyPass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        keyPass.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(actualLevel + 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        keyPass.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;
        keyPass.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(actualLevel + 1);
        }
    }
}
