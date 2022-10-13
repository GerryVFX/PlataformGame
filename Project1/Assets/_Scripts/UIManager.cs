using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Image lifeIndicator;
    [SerializeField] Sprite[] lifesprites;

    [SerializeField] GameObject[] panelController;
    

    private void Update()
    {
        if(lifeIndicator != null)
        {
            lifeIndicator.sprite = lifesprites[gameManager.lifes];
        }
        if(gameManager.inGame)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                panelController[0].SetActive(true);
                Time.timeScale = 0;
            }
        }    
    }

    

    public void QuitPause()
    {
        panelController[0].SetActive(false);
        Time.timeScale = 1;
    }

    public void StarGame()
    {
        SceneManager.LoadScene(1);
    }
}
