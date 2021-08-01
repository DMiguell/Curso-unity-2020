using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0,20)]
    public float speed = 10.0f;
    public float horizontalInput;
    public float xRange = 15.0f;
    
    public GameObject projectilePrefab;

    
    void Update()
    {
        //Movimiento del personaje
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(speed*Vector3.right*Time.deltaTime*horizontalInput);

        if(transform.position.x<-xRange){
            transform.position = new Vector3(-xRange,
            transform.position.y,
            transform.position.z);
        }
        if(transform.position.x>xRange){
            transform.position = new Vector3(xRange,
            transform.position.y,
            transform.position.z);
        }

        // Acciones del personaje
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab,// el objeto a instanciar
            transform.position, // donde lo voy a instanciar
            projectilePrefab.transform.rotation); // la rotacion
        }
    }
}
