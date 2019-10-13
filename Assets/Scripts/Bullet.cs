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
        if (other.tag == "WorldBound") {
            bulletManager.returnBullet(gameObject);
        }
    }

    public void setVelocity(float velocity) {
        rb2d.velocity = new Vector2(0, velocity);
    }
}
