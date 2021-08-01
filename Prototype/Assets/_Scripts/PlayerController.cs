using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(0,180)]
    public float speed, rotateSpeed, force;
    
    private Rigidbody _rigidbody;
    private float verticalInput, horizontalInput;

    public bool usePhysicsEngine;
    // Start is called before the first frame update
    void Start()
    {
        //Capturando el rigbody
        _rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        if(usePhysicsEngine){
        // si utilizas la fisica se utiliza:
        // El AddForce sobre el rigidbody porque todo se base en fuerza, la fuerza sirve para trasladar
        _rigidbody.AddForce(Vector3.forward*force*Time.deltaTime*verticalInput);
        _rigidbody.AddTorque(Vector3.up*force*Time.deltaTime*horizontalInput);
        }else{
            // Si no utilizas la fisica se utiliza:
        // El Translate sobre el transform -> para mover
        // el rotate -> para rotar

        transform.Translate(Vector3.forward*speed*Time.deltaTime*verticalInput);
        transform.Rotate(Vector3.up*rotateSpeed*Time.deltaTime*horizontalInput);
        }

        
    }
}
