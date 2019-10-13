using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    
    public BulletManager bulletManager;
    public GameObject enemyPrefab;

    public float spawnInterval;
    public Vector2 spawnLocation;

    private float timer;

    // Update is called once per frame
    void Update() {
        if (timer > spawnInterval) {
            EnemyAttackSpread eas = Instantiate(enemyPrefab, spawnLocation, Quaternion.identity).GetComponent<EnemyAttackSpread>();
            eas.bulletManager = bulletManager;
            timer = 0;
        } else {
            timer += Time.deltaTime;
        }
    }
}
