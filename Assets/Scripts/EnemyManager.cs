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
    public Vector2[] spawnLocations;
    public Vector2[][] movementPositions = new Vector2[4][];

    private float timer;

    void Start() {
        enemyPools = new Queue<GameObject>[enemyPrefabs.Length];
        for (int i = 0; i < enemyPrefabs.Length; i++) {
            enemyPools[i] = new Queue<GameObject>();
            for (int j = 0; j < numEnemies; j++) {
                GameObject obj = Instantiate(enemyPrefabs[i], new Vector2(9999, 9999), Quaternion.identity);
                BaseEnemy enemy = obj.GetComponent<BaseEnemy>();
                enemy.enemyManager = this;
                enemy.bulletManager = bulletManager;
                enemy.origin = i;
                obj.SetActive(false);
                enemyPools[i].Enqueue(obj);
            }
        }

        movementPositions[0] = new Vector2[2] {new Vector2(-2,0), new Vector2(-3.5f,0)};
        movementPositions[1] = new Vector2[2] {new Vector2(2,0), new Vector2(3.5f,0)};
        movementPositions[2] = new Vector2[2] {new Vector2(-2,4), new Vector2(-2,5.5f)};
        movementPositions[3] = new Vector2[2] {new Vector2(2,4), new Vector2(2,5.5f)};
    }

    // Update is called once per frame
    void Update() {
        if (timer > spawnInterval) {
            /*
            GameObject enemy = getEnemy(0);
            enemy.transform.position = spawnLocation;
            */
            for (int i = 0; i < spawnLocations.Length; ++i) {
                Enemy1 enemy = getEnemy(1).GetComponent<Enemy1>();
                enemy.transform.position = spawnLocations[i];
                enemy.positions = movementPositions[i];
                enemy.initialize();
            }
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
        enemyPools[obj.GetComponent<BaseEnemy>().origin].Enqueue(obj);
    }
}
