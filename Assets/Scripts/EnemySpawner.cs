using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float spawnTimer = 5f;
    [SerializeField] float maxEnemy=10;
    float totalEnemy;
    List<GameObject> enemyList = new List<GameObject>();
    private void Start()
    {
        totalEnemy = 0;
    }
    private void OnEnable()
    {
        EventManager.onStartGame += StartSpawning;
        EventManager.onPlayerDeath += StopSpawning;
        EventManager.onPlayerDeath += WaitAminute;
    }
    private void OnDisable()
    {
        StopSpawning();
        EventManager.onStartGame -= StartSpawning;
        EventManager.onPlayerDeath -= StopSpawning;
        EventManager.onPlayerDeath -= WaitAminute;
    }
    private void Update()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null)
            {
                totalEnemy--;
            }
        }
    }
    void DestroyEnemy()
    {
        for(int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] != null)
            {
                enemyList[i].SetActive(false);
                Destroy(enemyList[i]);
            }
        }
        enemyList.Clear();
    }
    void WaitAminute()
    {
        totalEnemy = 0;
        Invoke("DestroyEnemy", 3f);
    }
    void SpawnEnemy()
    {
        if (totalEnemy < maxEnemy)
        {
            totalEnemy++;
            enemyList.Add(Instantiate(enemyPrefab, transform.position, Quaternion.identity));
        }
    }
    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);

    }
    void StopSpawning()
    {
        CancelInvoke();
    }
}
