using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float minForce = 12,
        maxForce = 16,
        maxTorque = 10 ,
        xRange = 4,
        ySpawnPos= -6;
    private GameManager gameManager;
    public int valuePoint;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(RandomForce(),ForceMode.Impulse);
        _rigidbody.AddTorque(RandomTorque(),
            RandomTorque(),
            RandomTorque(),
            ForceMode.Impulse);
        transform.position= RandomSpawnPosition();
        gameManager =  GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Genera un vector Aleatiorio en 3D
    /// </summary>
    ///<returns>Fuerza aleatoria para arriba</returns>
    private Vector3 RandomForce()
    {
        return Vector3.up*Random.Range(minForce,maxForce);
    }
    /// <summary>
    /// Genera un numero aleatorio
    /// </summary>
    ///<returns>Posicion aleatoria en 3D, con la corrdenada z=0</returns>
    private float RandomTorque()
    {
        return Random.Range(-maxTorque,maxTorque);
    }
    /// <summary>
    /// Genera un aposicon aleatoria
    /// </summary>
    ///<returns>Fuerza aleatoria para arriba</returns>
    private Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange,xRange), ySpawnPos);
    }
    private void OnMouseOver()
    {
        if(gameManager.gameState == GameManager.GameState.inGame)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
            gameManager.UpdateScore(valuePoint);
        }
        

        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KillZone"))
        {
            Destroy(gameObject);
            if(gameObject.CompareTag("God"))
            {
                gameManager.GameOver();
            }
            
            
        }
    }
}
