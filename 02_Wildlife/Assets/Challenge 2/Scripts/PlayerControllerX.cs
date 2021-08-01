using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    // Variables para lanzar cada 5 Segundos
    // private float counter = 0;
    // private float nextcounter = 5;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            
        }

        /* Codigo para Disparar cada 5 segundos

        counter = counter + Time.deltaTime;

        if(counter >= nextcounter){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                counter = 0;
            }
        
        }*/
        
    }
}
