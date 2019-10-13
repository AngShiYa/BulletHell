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
            GameObject newBullet = Instantiate(bullet, offScreen, Quaternion.identity);
            newBullet.GetComponent<Bullet>().bulletManager = this;
            bullets.Enqueue(newBullet);
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
            bullet.GetComponent<Bullet>().setVelocity(0);
            bullet.transform.position = offScreen;
            bullets.Enqueue(bullet);
        } else {
            Debug.Log("GameObject is not tagged as Bullet");
        }
    }
}
