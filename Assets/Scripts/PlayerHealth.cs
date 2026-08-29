//using Unity.Mathematics;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public int maximumHealth = 4;
	public int currentHealth = 4;

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