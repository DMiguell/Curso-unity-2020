using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    private int enemyCount;
    public int enemyWave;
    public GameObject powerUpPrefab;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemyWave); 
        
        
    }
    private void Update() 
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        if(enemyCount == 0)
        {   enemyWave++;
            SpawnEnemyWave(enemyWave);
            Instantiate(powerUpPrefab,GenerateSpawnPosition(),powerUpPrefab.transform.rotation);
        }
    }
    
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosx = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosx,0,spawnPosZ);
        return randomPos;
    }
    ///<summary>
    /// Metodo que genera un numero determinado de enemigos en pantalla
    /// <param name="numberOfEnemies">Numero de enemigos a crear</param>
    ///</summary>
    private void SpawnEnemyWave(int numberOfEnemies)
    {
        for(int i=0;i<numberOfEnemies;i++)
        {
            Instantiate(enemyPrefab,GenerateSpawnPosition(),enemyPrefab.transform.rotation);
        }
    }
}
