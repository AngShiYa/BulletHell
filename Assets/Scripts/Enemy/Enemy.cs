using UnityEngine;

public class Enemy : BaseEnemy {
    [Header("Movement")]
    public Vector2 direction;

    [Header("Attack Pattern")]
    public float cooldown;
    public float speed;
    public int numProjectile;
    public float spreadAngle;
    
    private Vector2[] velocities;

    void Start() {
        initialize();
    }

    public override void initialize() {
        timer = 0;
        currentHealth = maxHealth;

        velocities = new Vector2[numProjectile];
        float start = speed * (spreadAngle / 90.0f);
        float offset = (start * 2) / (numProjectile - 1);
        for (int i = 0; i < numProjectile; ++i) {
            velocities[i] = new Vector2(start, speed);
            start -= offset;
        }
    }

    protected override void move() {
        transform.Translate(direction * Time.deltaTime);
    }

    protected override void attack() {
        if (timer > cooldown) {
            for (int i = 0; i < velocities.Length; ++i) {
                Bullet bullet = bulletManager.getBullet(1).GetComponent<Bullet>();
                bullet.transform.position = transform.position;
                bullet.velocity = velocities[i];
                bullet.damage = 1;
            }
            timer = 0;
        }
    }
}
