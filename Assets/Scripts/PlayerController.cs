using UnityEngine;

public class PlayerController : MonoBehaviour {
    public BulletManager bulletManager;
    public float cooldown = 0.1f;
    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    private bool isMouseDown;
    private Vector2 clickPosition;
    private Vector2 currentPosition;
    private float timer = 0;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        move();

        timer += Time.deltaTime;
        if (timer > cooldown) {
            attack();
            timer = 0;
        }
    }

    private void move() {
        if (Input.GetMouseButtonDown(0)) {
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentPosition = transform.position;
            isMouseDown = true;
        } 
        else if (Input.GetMouseButtonUp(0)) {
            isMouseDown = false;
        }

        if (isMouseDown) {
            Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 offset = position - clickPosition;
            Vector2 screenPosition = Camera.main.WorldToScreenPoint(currentPosition + offset);
            if (screenPosition.x < 0) {
                screenPosition.x = 0;
            }
            if (screenPosition.x > Screen.width) {
                screenPosition.x = Screen.width;
            }

            if (screenPosition.y < 0) {
                screenPosition.y = 0;
            }
            if (screenPosition.y > Screen.height) {
                screenPosition.y = Screen.height;
            }
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
            worldPosition.z = 0;
            transform.position = worldPosition;
        }
    }

    private void attack() {
        Bullet bullet = bulletManager.getBullet(0).GetComponent<Bullet>();
        bullet.transform.position = transform.position + bulletOffset;
        bullet.velocity = new Vector2(0, 10);
        bullet.damage = 1; // To change when player has stats
    }
}
