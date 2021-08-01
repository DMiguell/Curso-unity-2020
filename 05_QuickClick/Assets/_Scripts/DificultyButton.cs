using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DificultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    [Range(1,3)]
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }
    void SetDifficulty()
    {
        Debug.Log("El boton " + gameObject.name+" ha sido pulsado.");
        gameManager.StartGame(difficulty);
    }

}
