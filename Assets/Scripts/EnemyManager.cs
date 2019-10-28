using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    
    public BulletManager bulletManager;
    public Vector3 offScreen = new Vector3(-10, 0, 0);
    public GameObject[] enemyPrefabs;
    public int numEnemies;

    private Queue<GameObject>[] enemyPools;

    // temp
    public float spawnInterval;
    public Vector2 spawnLocation;

    private float timer;

    void Start() {
        enemyPools = new Queue<GameObject>[enemyPrefabs.Length];
        for (int i = 0; i < enemyPrefabs.Length; i++) {
            enemyPools[i] = new Queue<GameObject>();
            for (int j = 0; j < numEnemies; j++) {
                GameObject obj = Instantiate(enemyPrefabs[i], spawnLocation, Quaternion.identity);
                Enemy enemy = obj.GetComponent<Enemy>();
                enemy.enemyManager = this;
                enemy.bulletManager = bulletManager;
                enemy.origin = i;
                obj.SetActive(false);
                enemyPools[i].Enqueue(obj);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        if (timer > spawnInterval) {
            GameObject enemy = getEnemy(0);
            enemy.transform.position = spawnLocation;
            timer = 0;
        } else {
            timer += Time.deltaTime;
        }
    }

    public GameObject getEnemy(int index) {
        GameObject nextBullet = enemyPools[index].Dequeue();
        nextBullet.SetActive(true);
        return nextBullet;
    }

    public void returnEnemy(GameObject obj) {
        obj.transform.position = offScreen;
        obj.SetActive(false);
        enemyPools[obj.GetComponent<Enemy>().origin].Enqueue(obj);
    }
}
