using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float translateSpeed = 1 ;
    public float rotatespeed = 60;
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
        transform.localPosition += Vector3.left*translateSpeed*Time.deltaTime;
        transform.Rotate(Vector3.up*rotatespeed*Time.deltaTime);
        }
    }
    
}
