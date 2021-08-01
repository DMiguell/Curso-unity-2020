using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float topBound = 30f;
    public float lowerBound = -10f;
    

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.z>topBound)
        {
            Destroy(this.gameObject);
        }
        if (this.transform.position.z<lowerBound)
        {
            Debug.Log("Game Over!!!");
            Destroy(this.gameObject);
            Time.timeScale=0;
        }
        
    }
}
