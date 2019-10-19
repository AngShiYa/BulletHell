using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Rigidbody2D rb2d;
    public BulletManager bulletManager;

    // Start is called before the first frame update
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Enemy") {
            Debug.Log("HIT ENEMY");
            other.GetComponent<Enemy>().getHit(1);
            bulletManager.returnBullet(gameObject);
        }
    }

    public void setVelocity(Vector2 velocity) {
        rb2d.velocity = velocity;
        var angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        rb2d.MoveRotation(angle - 90);
    }
}
