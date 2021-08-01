using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos; // variable para capturar la posicion inicial
    private float startDelay = 2;
    private float repeatRate = 2;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = this.transform.position; // capturadon la posicion inicial
        InvokeRepeating("SpawnObstacle", //nombre del metodo que vamos a llamar
        startDelay, // el tiempo a iniciar
        repeatRate);// el coldown a repetir
        
        _playerController = GameObject.Find("Player")
        .GetComponent<PlayerController>();
    }

    void SpawnObstacle(){
        if(!_playerController.GameOver){
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0,obstaclePrefabs.Length)];
        Instantiate(obstaclePrefab,// el objeto a instanciar
        spawnPos,//la ubicacion
        obstaclePrefab.transform.rotation);//la Rotacion
        }
        
    }
}
