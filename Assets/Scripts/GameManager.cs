using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] int numAnimals;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    public void Nivel1()
    {
        SceneManager.LoadScene(1);
    }
    public void Nivel2()
    {
        SceneManager.LoadScene(2);
    }
    public void Nivel3()
    {
        SceneManager.LoadScene(3);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    void PauseGame()
    {
        //pausar y "despausar" el juego
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
        //setActive
        //variable serializada
    }

    public void CaptureAnimal()
    {
        numAnimals = numAnimals - 1;
        if(numAnimals < 1)
        {
            Time.timeScale = 0;
            gameOverMenu.SetActive(true);
        }
    }

}
