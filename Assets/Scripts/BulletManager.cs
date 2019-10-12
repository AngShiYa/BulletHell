using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour {
    public GameObject bullet;
    public Vector3 offScreen = new Vector3(-10, 0, 0);
    public int numBullets = 100;

    private GameObject[] bullets; 
    private int nextBulletIndex;

    // Start is called before the first frame update
    void Start() {
        bullets = new GameObject[numBullets];
        nextBulletIndex = 0;
        for (int i = 0; i < numBullets; i++) {
            bullets[i] = Instantiate(bullet, offScreen, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public GameObject getBullet() {
        nextBulletIndex %= numBullets;
        return bullets[nextBulletIndex++];
    }
}
