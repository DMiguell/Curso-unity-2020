using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//requiere que el script tengo un rigibody(o puede ser un boxcolaider,otros)
[RequireComponent(typeof(Rigidbody))]//antes de la clase
public class PlayerController : MonoBehaviour
{

    private const string DEATH_B = "Death_b";
    private const string DEATHTYPE_INT = "DeathType_int";
    public float jumpForce;
    public float gravityMultiplier;
    public bool isOnGround = true;
    private Rigidbody playerRb;

    private bool _gameOver = false;
    public bool GameOver{get => _gameOver;}

    private Animator _animator;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public AudioClip JumpSound, crashSound;
    private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()// Inicia en el primer Frame
    {
        //Capturar el Rigidbody 
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplier*new Vector3(0, -9.81f , 0);
        
        /*aplicar fuerza se utiliza .AddForce("Direccion"), F = M*a
        playerRb.AddForce(Vector3.up*1000);*/

        _animator = GetComponent<Animator>();
        _animator.SetFloat("Speed_f", 1);

        _audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed multi", 1+Time.time/10);
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround && !_gameOver){
            playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            isOnGround = false;
            dirt.Stop();
            _animator.SetTrigger("Jump_trig");
            _audioSource.PlayOneShot(JumpSound,1);
            
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            if(!GameOver){
                isOnGround = true;
                dirt.Play();
            }
            
            

        }
        if(other.gameObject.CompareTag("Obstacle")){
            _gameOver = true;      
            
            explosion.Play();
            _audioSource.PlayOneShot(crashSound,1);
            dirt.Stop();
            _animator.SetBool(DEATH_B, true);    
            _animator.SetInteger(DEATHTYPE_INT,Random.Range(1,3));
            Invoke("RestartGame", 1.0f);
            
        }

        
    }
    void RestartGame(){
        SceneManager.LoadScene("Prototype 3");
    }
}
