using UnityEngine;

public class Enemy1 : BaseEnemy {
    [Header("Movement")]
    public Vector2[] positions;
    public float moveDuration;

    [Header("Attack Pattern")]
    public float cooldown;
    public float baseSpeed;
    public float incrementSpeed;
    public int shotsPerAttack;
    public int numAttacks;

    private GameObject target;
    private Vector2 startPosition;
    private Vector2 endPosition;
    private int currentPosition;
    private int currentAttack;

    private bool isMovePhase;

    void Start() {
        initialize();
    }

    private void findTarget() {
        target = GameObject.FindGameObjectWithTag("Player");
    }


    public override void initialize() {
        findTarget();
        startPosition = transform.position;
        currentPosition = 0;
        endPosition = positions[currentPosition];

        timer = 0;
        isMovePhase = true;
        currentAttack = 1;
        currentHealth = maxHealth;
    }

    protected override void move() {
        if (!isMovePhase) return;

        if (timer < moveDuration) {
            transform.position = Vector2.Lerp(startPosition, endPosition, timer / moveDuration);
        } else {
            if (positions.Length > currentPosition + 1) {
                isMovePhase = false;
                startPosition = positions[currentPosition++];
                endPosition = positions[currentPosition];
            } else {
                enemyManager.returnEnemy(this.gameObject);
            }
        }
    }

    protected override void attack() {
        if (isMovePhase) return;
        if (currentAttack > numAttacks) {
            isMovePhase = true;
            currentAttack = 1;
            return;
        }

        if (timer > cooldown) {
            float speed = baseSpeed;
            for (int i = 0; i < shotsPerAttack; ++i) {
                Bullet bullet = bulletManager.getBullet(1).GetComponent<Bullet>();
                bullet.transform.position = transform.position;
                bullet.velocity = (target.transform.position - transform.position).normalized * speed;
                bullet.damage = 1;
                speed += incrementSpeed;
            }
            timer = 0;
            ++currentAttack;
        }
    }
}
