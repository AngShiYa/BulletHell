using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public BulletManager bulletManager;

    public int maxHealth;
    public int damage;

    private int currentHealth;
    private bool isDead;

    void Start() {
        currentHealth = maxHealth;
        isDead = false;
    }

    public bool IsDead() {
        return isDead;
    }

    public int GetCurrentHealth() {
        return currentHealth;
    }

    public void getHit(int damageTaken) {
        currentHealth -= damageTaken;
        if (currentHealth < 0) {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "EnemyBullet") {
            getHit(other.GetComponent<Bullet>().damage);
            bulletManager.returnBullet(other.gameObject);
        }
    }
}
