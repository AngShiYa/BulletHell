using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public PlayerStats playerStats;
    
    private Image display;

    void Start() {
        display = GetComponent<Image>();
    }

    void Update() {
        display.fillAmount = (playerStats.GetCurrentHealth() * 1.0f) / playerStats.maxHealth;
    }
}
