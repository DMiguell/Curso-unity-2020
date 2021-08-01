using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    
    //PROPIEDADES O VARIABLES
    //[HideInInspector] = Sirve para Ocultar la siguiente variable
    //[Range(0,20)]  Crea un slider
    //[SerializeField]  Convierte un private a poder realizar cambios (Maximo en seguridad)
    //[Tooltip("Velocidad actual del Coche")]  Documentar(Comentario) lo que hacemos en unity

    [Range(0,20), SerializeField, Tooltip("Velocidad lineal maxima del Coche")]
    private float speed ;
    [Range(0,90), SerializeField, Tooltip("Velocidad de giro Maxima del coche")]
    private float turnSpeed ;

    private float horizontalInput, verticalInput;

    

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Esto es el metodo Start del PC" +gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        //Debug.Log("Movimiento horizontal: "+ horizontalInput);
        //Mover el vehiculo hacia delante
        //S(Spacio nuevo)= s0(Spacio antiguo) + V*t*(direccion) 
        transform.Translate(speed*Time.deltaTime*Vector3.forward* verticalInput);
        transform.Rotate(turnSpeed * Time.deltaTime*Vector3.up * horizontalInput);
    }
}
