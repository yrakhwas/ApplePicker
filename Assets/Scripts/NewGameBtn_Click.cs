using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBtn_Click : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene("Scene_0");
    }
   
}
