using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public BulletManager bulletManager { get; set; }
    public int origin { get; set; }
    public Vector2 velocity { get; set; }
    public int damage { get; set; }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(velocity * Time.deltaTime);
    }
}
