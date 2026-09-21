using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthBar : MonoBehaviour
{
    public Slider playerHealthSlider;
    public Slider easeHealthSlider;
    public float maxHealth = 100;
    public float health;
    private float lerpSpeed = 2;
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

        if (Mathf.Abs(easeHealthSlider.value - health) > 0.7f)
        {
            easeHealthSlider.value = Mathf.Lerp(easeHealthSlider.value, health, lerpSpeed * Time.deltaTime);
        }
        else
        {
            easeHealthSlider.value = health;
        }
    }
}
