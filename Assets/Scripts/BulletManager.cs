using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
    public GameObject[] bullets;
    public Vector3 offScreen = new Vector3(-10, 0, 0);
    public int numBullets = 100;

    Queue<GameObject>[] bulletPools;

    // Start is called before the first frame update
    void Start() {
        bulletPools = new Queue<GameObject>[bullets.Length];
        for (int i = 0; i < bullets.Length; i++) {
            bulletPools[i] = new Queue<GameObject>();
            for (int j = 0; j < numBullets; j++) {
                GameObject newPlayerBullet = Instantiate(bullets[i], offScreen, Quaternion.identity);
                Bullet bullet = newPlayerBullet.GetComponent<Bullet>();
                bullet.bulletManager = this;
                bullet.origin = i;
                newPlayerBullet.SetActive(false);
                bulletPools[i].Enqueue(newPlayerBullet);
            }
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public GameObject getBullet(int index) {
        GameObject nextBullet = bulletPools[index].Dequeue();
        nextBullet.SetActive(true);
        return nextBullet;
    }

    public void returnBullet(GameObject obj) {
        Bullet bullet = obj.GetComponent<Bullet>();
        bullet.velocity = Vector2.zero;
        obj.transform.position = offScreen;
        obj.SetActive(false);
        bulletPools[bullet.origin].Enqueue(obj);
    }
}
