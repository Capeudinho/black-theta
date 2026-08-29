using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerHealthDisplay : MonoBehaviour
{
	private PlayerHealth playerHealth;
	public Sprite healthEmpty;
	public Sprite healthFull;
	public Image[] healthIcons;

	void Awake()
	{
		playerHealth = GetComponent<PlayerHealth>();
	}

	void FixedUpdate()
	{
		for (int index = 0; index < healthIcons.Length; index++)
		{
			if (index < playerHealth.currentHealth)
			{
				healthIcons[index].sprite = healthFull;
			}
			else
			{
				healthIcons[index].sprite = healthEmpty;
			}
			if (index < playerHealth.maximumHealth)
			{
				healthIcons[index].SetEnabled(true);
			}
			else
			{
				healthIcons[index].SetEnabled(false);
			}
		}
	}
}