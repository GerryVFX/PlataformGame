using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    [SerializeField] TMP_Text dialogs;
    [SerializeField] GameObject dialogPanel;
    [SerializeField] GameManager gameManager;
    [SerializeField] Animator doorAnim;

    bool doorOpen;



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(true);
            if(gameManager.haveKey == false && !doorOpen)
            {
                dialogs.text = "¡Necesitas encontrar una llave!";
            }
            else 
            {
                dialogs.text = "Presiona 'K' para abrir la puerta";
            }

            if (Input.GetKey(KeyCode.K))
            {
                doorAnim.SetBool("UseKey", true);
                doorOpen = true;
            }
            if (doorOpen)
            {
                dialogs.text = "Felicidades avanza al siguiente nivel";
            }
               

        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            dialogPanel.SetActive(false);
        }
    }
}
