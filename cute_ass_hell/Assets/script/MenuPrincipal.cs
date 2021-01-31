using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPrincipal : MonoBehaviour
{
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play()
    {
        Debug.Log("play");
        SceneManager.LoadScene("SampleScene");
    }

    public void exit()
    {
        Debug.Log("Exit");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
