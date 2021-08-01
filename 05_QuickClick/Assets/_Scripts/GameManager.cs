using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private const string MAX_SCORE = "MAX_SCORE";
    public enum GameState
    {
        loading,
        inGame,
        gameOver
    }
    public GameState gameState;
    public List<GameObject> targetPrefabs;
    public float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    // recordad variables autocomputadas (get y set)
    // la que tiene el valor es _score

    private int _score;
    private int score
    {
        set
        {
            // revisar la documentacion mathf unity ya que casi todo es matematica
            _score = Mathf.Clamp(value,0,9999);
            //mathf.clamp() es lo mismo que esl if que esta comentado

            /*if(value <0)
            {
                score = 0;
            }
            else if(value >9999)
            {
                _score = 9999;
            }*/

        }
        get
        {
            // simpre hay q devolver el valor
            return _score;
        }
    }
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public Button restartButton;
    private int numberOfLives = 4;
    public List<GameObject> lives;
    
    private void Start()
    {
        ShowMaxScore();
    }

    // Start is called before the first frame update
    ///<summary>
    /// Metodo que inicia la partida cambiado el valor del estado del juego
    ///</summary>
    public void StartGame(int difficulty)
    {
        gameState = GameState.inGame;
        
        titleScreen.gameObject.SetActive(false);
        // x op= y <-> x= x op y (op = operacion(+ - / *))
        spawnRate /= difficulty;
        numberOfLives -= difficulty ;

        for(int i = 0 ;i<numberOfLives;i++)
        {
            lives[i].SetActive(true);
        }

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        
    }

    IEnumerator SpawnTarget()
    {
        while(gameState == GameState.inGame)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targetPrefabs.Count);
            Instantiate(targetPrefabs[index]);
            
        }
    }
    /// <summary>
    /// Actualiza la puntuacion y lo muestra por pantalla
    /// </summary>
    ///<param name="scoreToAdd">Numero de puntos a añadir a la puntuacion global</param>
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void ShowMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE,0);
        scoreText.text = "Max Score: \n" + maxScore;
    }

    
    private void setMaxScore()
    {
        int maxScore = PlayerPrefs.GetInt(MAX_SCORE,0);
        if(score > maxScore)
        {
            PlayerPrefs.SetInt(MAX_SCORE,score);
            
        }
    }
    
    public void GameOver()
    {
        numberOfLives--;
        
        if(numberOfLives>=0)
        {
            Image heartImage = lives[numberOfLives].GetComponent<Image>();
            var tempColor = heartImage.color;
            tempColor.a = 0.3f;
            heartImage.color = tempColor;
        }
        

        

        if(numberOfLives<=0)
        {
            setMaxScore();
            gameState = GameState.gameOver;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
        }
        
    }
    public void RestartGame()
    {
        //remplazndo a el otro ya que esta nos da el nombre de la escena 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
