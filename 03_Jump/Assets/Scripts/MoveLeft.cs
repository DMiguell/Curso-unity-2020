using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player")//GameObject
        .GetComponent<PlayerController>();//PlayerController
    }

    // Update is called once per frame
    void Update()
    {
        if(!_playerController.GameOver){
            transform.Translate(Vector3.left*speed*Time.deltaTime);
        }
        
    }
}
