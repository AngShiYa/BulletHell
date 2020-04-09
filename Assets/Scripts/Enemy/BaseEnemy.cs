using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour {

    public EnemyManager enemyManager;
    public BulletManager bulletManager;
    public int origin;

    [Header("Stats")]
    public int maxHealth;

    protected float timer;
    protected int currentHealth;

    void Update() {
        timer += Time.deltaTime;
        move();
        attack();
    }

    public void getHit(int damageTaken) {
        currentHealth -= damageTaken;
        if (currentHealth <= 0) {
            enemyManager.returnEnemy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "PlayerBullet") {
            getHit(other.GetComponent<Bullet>().damage);
            bulletManager.returnBullet(other.gameObject);
        }
    }

    public abstract void initialize();

    protected abstract void move();

    protected abstract void attack();
}
