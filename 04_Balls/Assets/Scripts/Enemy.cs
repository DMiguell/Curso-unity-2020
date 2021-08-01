using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float moveForce;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Recordar siempre poner normalize, formula para hallr la distancia entre el enimgo y yo :
        Vector3 direction = (player.transform.position - this.transform.position).normalized;
        _rigidbody.AddForce(moveForce * direction);
        if(this.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
