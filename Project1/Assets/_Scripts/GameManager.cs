using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lifes = 3;
    public bool haveKey;
    public bool inGame;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lifes <= 0)
        {
            inGame = false;
            SceneManager.LoadScene(0);
        }
    }
}
