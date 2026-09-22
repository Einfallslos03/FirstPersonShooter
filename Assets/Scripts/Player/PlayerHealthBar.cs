using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider playerHealthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100;
    public float health;
    private float lerpSpeed = 0.05f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        if (playerHealthSlider.value != health)
        {
            playerHealthSlider.value = health;
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
        health -= damage;
        if (health <= 0)
        {
            RestartGame();
        }
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
