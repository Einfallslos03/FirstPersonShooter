using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider healthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100;
    public float health;
    private float lerpSpeed = 0.05f;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        if (healthSlider.value != health)
        {
            healthSlider.value = health;
        }
        if (Mathf.Abs(easeHealthSlider.value - health) > 0.5f)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed);
        }
        else
        {
            easeHealthSlider.value = health;
        }
    }

    public void TakeDamage(float damage)
    {
        health = Mathf.Max(0, health - damage);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
