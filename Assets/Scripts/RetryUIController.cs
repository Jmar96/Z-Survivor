using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryUIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayerRetry()
    {
        //reload the current scene
        SceneManager.LoadScene("Gameplay");
        Time.timeScale = 1;

    }
    public void HomeButton()
    {
        //load the MainMenu Scene
        SceneManager.LoadScene("MainMenu");
    }
}
