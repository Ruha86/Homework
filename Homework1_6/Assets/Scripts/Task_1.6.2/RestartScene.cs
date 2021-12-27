using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartScene : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) { Restart(); }
    }

    private void Restart()
    {
        Debug.Log("Scene Loaded!.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
