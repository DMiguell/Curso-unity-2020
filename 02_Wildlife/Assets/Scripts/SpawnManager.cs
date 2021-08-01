using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    private int animalIndex;

    private float spawnRangeX = 14f;
    private float spawnPosZ;

    // Variables para la aparicion de enemigos
    [SerializeField,Range(2,5)]
    private float startDelay = 2f;
    [SerializeField,Range(0.1f,3f)]
    private float spawnInterval = 0.5f;


    void Start() {
        spawnPosZ = this.transform.position.z;
        InvokeRepeating("SpawnRandonAnimal", // Nombre del Metodo
        startDelay, // Tiempo de espera
        spawnInterval); // Tiempo de respawn
    }

    

    private void SpawnRandonAnimal(){
        //Generar la posicion donde aparece el proximo enemigo
                float xRand = Random.Range(-spawnRangeX,spawnRangeX);
                Vector3 spawnPos = new Vector3(xRand,0,spawnPosZ);

                //Generar Enemigos Aleatorios 
                animalIndex = Random.Range(0,enemies.Length);

                //La instancia del enemigo
                Instantiate(enemies[animalIndex], // Objeto a Instanciar
                spawnPos, // Posicion a instanciar (x,y,z)
                enemies[animalIndex].transform.rotation); // La rotacion del objeto
    }
}
