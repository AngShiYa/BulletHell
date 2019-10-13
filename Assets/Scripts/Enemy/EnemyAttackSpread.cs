using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSpread : MonoBehaviour {
    public BulletManager bulletManager;
    public float cooldown = 2;
    public float speed = -10;
    public int numProjectile = 3;
    public float spreadAngle = 45;
    
    private float timer;
    private Vector2[] velocities;

    // Start is called before the first frame update
    void Start() {
        timer = 0;
        velocities = new Vector2[numProjectile];
        Debug.Log(numProjectile / 2);
        float start = speed * (spreadAngle / 90.0f);
        float offset = (start * 2) / (numProjectile - 1);
        for (int i = 0; i < numProjectile; ++i) {
            velocities[i] = new Vector2(start, speed);
            Debug.Log(velocities[i]);
            start -= offset;
        }
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer > cooldown) {
            attack();
            timer = 0;
        }
    }

    private void attack() {
        for (int i = 0; i < velocities.Length; ++i) {
            GameObject bullet = bulletManager.getBullet();
            bullet.transform.position = transform.position;
            bullet.GetComponent<Bullet>().setVelocity(velocities[i]);
        }
    }
}
