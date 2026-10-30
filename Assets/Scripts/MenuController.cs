using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;
    private GameController gameController;

    void Start()
    {
      gameController = FindObjectOfType<GameController>();
      menuCanvas.SetActive(false);  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //menuCanvas.SetActive(!menuCanvas.activeSelf);
            if (!menuCanvas.activeInHierarchy)
            {
                menuCanvas.SetActive(true);
                gameController.PauseGame();
            }
            else
            {
                menuCanvas.SetActive(false);
                gameController.UnpauseGame();
            }
        }
    }
}
