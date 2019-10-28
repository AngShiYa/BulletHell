using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    public BulletManager bulletManager;
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PlayerBullet" || other.tag == "EnemyBullet") {
            bulletManager.returnBullet(other.gameObject);
        } else if (other.tag == "Enemy") {
            enemyManager.returnEnemy(other.gameObject);
        }
    }
}
