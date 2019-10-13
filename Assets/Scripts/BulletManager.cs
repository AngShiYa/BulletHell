using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
    public GameObject bullet;
    public Vector3 offScreen = new Vector3(-10, 0, 0);
    public int numBullets = 100;

    private Queue<GameObject> bullets; 

    // Start is called before the first frame update
    void Start() {
        bullets = new Queue<GameObject>();
        for (int i = 0; i < numBullets; i++) {
            bullets.Enqueue(Instantiate(bullet, offScreen, Quaternion.identity));
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public GameObject getBullet() {
        return bullets.Dequeue();
    }

    public void returnBullet(GameObject bullet) {
        if (bullet.tag == "Bullet") {
            bullets.Enqueue(bullet);
        }
        Debug.Log("GameObject is not tagged as Bullet");
    }
}
