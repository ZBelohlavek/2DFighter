using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Restart : MonoBehaviour
{
    void endGame()
    {
        Debug.Log("GameOver");
        Invoke("gameOver", 5f);
    }

    void gameOver()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
