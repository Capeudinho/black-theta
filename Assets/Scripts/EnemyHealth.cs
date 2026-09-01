using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 2;
    private int currentHealth;
    void Start() {
        currentHealth = health;
    }

    public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			gameObject.SetActive(false);
		}
	}
}
