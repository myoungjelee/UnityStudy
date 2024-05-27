using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
     GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 3.0f;

    private Transform targetPlayer;
    private float currentTime;
    private float spawnTime;

    GameManager gameManager;
    void Start()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        currentTime = 0f; 
        targetPlayer = FindObjectOfType<DodgePlayer>().transform; 
        spawnTime = Random.Range(spawnRateMin, spawnRateMax);
        gameManager = FindObjectOfType<GameManager>();
    }


    void Update()
    {
        transform.LookAt(targetPlayer);
        currentTime += Time.deltaTime;

        if(currentTime >= spawnTime && gameManager.gameStart)
        {
            currentTime = 0;
            
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(targetPlayer);

            spawnTime = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
