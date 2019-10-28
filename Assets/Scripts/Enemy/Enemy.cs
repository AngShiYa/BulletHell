using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public BulletManager bulletManager;

    [Header("Stats")]
    public int health;

    [Header("Movement")]
    public Vector2 direction;

    [Header("Attack Pattern")]
    public float cooldown = 2;
    public float speed = -10;
    public int numProjectile = 3;
    public float spreadAngle = 45;
    
    private float timer;
    private Vector2[] velocities;

    void Start() {
        initializeAttackPattern();
    }

    void Update() {
        move();
        timer += Time.deltaTime;
        if (timer > cooldown) {
            attack();
            timer = 0;
        }
    }

    public void getHit(int damage) {
        health -= damage;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Bullet") {
            getHit(1);
            bulletManager.returnBullet(other.gameObject);
        }
    }

    private void move() {
        transform.Translate(direction * Time.deltaTime);
    }

    private void initializeAttackPattern() {
        timer = 0;
        velocities = new Vector2[numProjectile];
        float start = speed * (spreadAngle / 90.0f);
        float offset = (start * 2) / (numProjectile - 1);
        for (int i = 0; i < numProjectile; ++i) {
            velocities[i] = new Vector2(start, speed);
            start -= offset;
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
