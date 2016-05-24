using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour {

	//http://answers.unity3d.com/questions/212464/destroy-object-after-a-delay.html
	public float delay = 5f;

	//Quelle:https://unity3d.com/learn/tutorials/projects/tanks-tutorial/tank-health?playlist=20081

	public float m_StartingHealth = 3f;               // The amount of health each tank starts with.
	public Slider m_Slider;                             // The slider to represent how much health the tank currently has.
	public Image m_FillImage;                           // The image component of the slider.

	public Color m_FullHealthColor = Color.green;       // The color the health bar will be when on full health.
	public Color m_ZeroHealthColor = Color.red;         // The color the health bar will be when on no health.
	//public GameObject m_ExplosionPrefab;                // A prefab that will be instantiated in Awake, then used whenever the tank dies.


	//private AudioSource m_ExplosionAudio;               // The audio source to play when the tank explodes.
	//private ParticleSystem m_ExplosionParticles;        // The particle system the will play when the tank is destroyed.
	private float m_CurrentHealth;                      // How much health the tank currently has.
	private bool m_Dead;                                // Has the tank been reduced beyond zero health yet?

	private void OnEnable()
	{
		// When the tank is enabled, reset the tank's health and whether or not it's dead.
		m_CurrentHealth = m_StartingHealth;
		m_Dead = false;

		// Update the health slider's value and color.
		SetHealthUI();
	}
	/*private void Awake ()
	{
		// Instantiate the explosion prefab and get a reference to the particle system on it.
		m_ExplosionParticles = Instantiate (m_ExplosionPrefab).GetComponent<ParticleSystem> ();

		// Get a reference to the audio source on the instantiated prefab.
		m_ExplosionAudio = m_ExplosionParticles.GetComponent<AudioSource> ();

		// Disable the prefab so it can be activated when it's required.
		m_ExplosionParticles.gameObject.SetActive (false);
	}*/


	public void TakeDamage (float amount)
	{
		// Reduce current health by the amount of damage done.
		m_CurrentHealth -= amount;

		// Change the UI elements appropriately.
		SetHealthUI ();

		// If the current health is at or below zero and it has not yet been registered, call OnDeath.
		if (m_CurrentHealth <= 0f && !m_Dead)
		{
			OnDeath ();
		}
	}


	private void SetHealthUI ()
	{
		// Set the slider's value appropriately.
		m_Slider.value = m_CurrentHealth;

		// Interpolate the color of the bar between the choosen colours based on the current percentage of the starting health.
		m_FillImage.color = Color.Lerp (m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
	}


	private void OnDeath ()
	{
		// Set the flag so that this function is only called once.
		m_Dead = true;

		// Move the instantiated explosion prefab to the tank's position and turn it on.
		//m_ExplosionParticles.transform.position = transform.position;
		//m_ExplosionParticles.gameObject.SetActive (true);

		// Play the particle system of the tank exploding.
		//m_ExplosionParticles.Play ();

		// Play the tank explosion sound effect.
		//m_ExplosionAudio.Play();

		// Turn the tank off.
		gameObject.SetActive (false);
		//http://answers.unity3d.com/questions/405737/c-wait-x-seconds-in-code-before-continue-in-code.html
		//http://forum.unity3d.com/threads/any-way-to-reset-the-scene.23986/
		//yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
