using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    bool gamePaused = false;
    bool gameOver = false;
    bool lento = false;
    [SerializeField] AlienMovimiento player;
    [SerializeField] int numEnemies;
    [SerializeField] int nivel;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)&&gameOver==false)
        {
            PauseGame();
        }

        if (Input.GetKeyDown(KeyCode.RightControl) && gameOver == false && lento==false)
        {
            TiempoLento();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("juego");
    }

    public void Nivel2()
    {
        SceneManager.LoadScene("juego2");
    }

    public void Nivel3()
    {
        SceneManager.LoadScene("juego3");
    }

    public void MenuPrin()
    {
        SceneManager.LoadScene("Menu");
    }


    void PauseGame()
    {
        gamePaused = gamePaused ? false : true; //cambia estados

        player.gamePaused = gamePaused;

        canvas.SetActive(gamePaused);
        Time.timeScale = gamePaused ? 0 : 1; //time escale dependiendo del estado
    }

    public void TiempoLento()
    {
        lento = lento ? false : true; 

        player.lento = lento;

        
        Time.timeScale = gamePaused ? 0.5f : 1;
    }

    public void ReducirNumEnemigos()
    {
        numEnemies = numEnemies - 1;
        if (numEnemies<1 && nivel==1)
        {
            Level2();
        }

        else if (numEnemies < 1 && nivel == 2)
        {
            Level3();
        }

        else if (numEnemies < 1 && nivel == 3)
        {
            Ganar();
        }
    }

    void Ganar()
    {
        gameOver = true;
        Time.timeScale = 0;
        player.gamePaused = true;
        SceneManager.LoadScene("fin");

    }

    void Level2()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("medio1");
    }

    void Level3()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("medio2");
    }

   


}
