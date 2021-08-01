using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    // OnTriggerEnter se llamara automaticamente cuando
    // un objeto fisico entre dentro del trigger del GameObject
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile")){
            Destroy(this.gameObject); // Destruye el animal
            Destroy(other.gameObject); // Destruye lo otro
        }
        
    }
}
