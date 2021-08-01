using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 movement;

    private Animator _animator;

    private Rigidbody _rigidbody;
    [SerializeField]
    private float turnSpeed;
    private Quaternion rotation = Quaternion.identity;

    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movement.Set(horizontal,0,vertical);
        movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal,0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical,0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        if(isWalking)
        {
            if(!_audioSource.isPlaying)
            {
                _audioSource.Play();
            }
        }
        else
        {
            _audioSource.Stop();
        }

        _animator.SetBool("isWalking", isWalking);

        // desireForward (Direccion deseado en la que me gustaria estar mirando) 
        Vector3 desireForward = Vector3.RotateTowards(
        transform.forward,// Donde estoy mirando ahora
        movement,// donde me gustaria mirar al final
        turnSpeed*Time.fixedDeltaTime,// la cantidad que se debe mover entre el vector de inicio y fin(angulos que debes moverte)
        0f);// que se mantenga la maginitud d elos vectores

        rotation = Quaternion.LookRotation(desireForward);


    }

    private void OnAnimatorMove()
    {
        // S = S0 + v*t   
        _rigidbody.MovePosition(_rigidbody.position+movement*
        _animator.deltaPosition.magnitude);//la cantidad debido a a la animacion, el truco que ese utiliza cuando la animacion ya aporta movimiento
        _rigidbody.MoveRotation(rotation);

    }
}
