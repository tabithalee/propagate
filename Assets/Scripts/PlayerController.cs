using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 2f;
	public float turnSmoothTime = 0.2f;

	public float dropForce = 2.0f;
	public float podAirTime = 0.6f;

	// health variables
	public int maxHealth;
	public int currentHealth;
	public int damagePerHit;

	public HealthBar healthBar;

	// where the pod will be held
	public Vector3 PickUpPosition;
	public Vector3 PickUpRotation;
	public Vector3 DropRotation;

	// only use this to feed to SmoothDampAngle
	float turnSmoothVelocity;

	Animator animator;

	bool havePodAlready = false;

	public GameObject myPod;

	// for audio effects
	[SerializeField] AudioClip pickUpSFX;
	[SerializeField] AudioClip whooshSFX;
	[SerializeField] AudioClip lifeUpSFX;
	[SerializeField] AudioClip ouchSFX;
	[SerializeField] AudioClip gameOverSFX;
	[SerializeField] float FXVolume;
	AudioSource audioSource;


	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
		animator = GetComponent<Animator>();
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 inputDir = input.normalized;

		// prevent snapping back to 0 rotation if no input
		if (inputDir != Vector2.zero)
		{
			float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
			transform.eulerAngles = Vector3.up * 
				Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
		}

		float speed = walkSpeed * inputDir.magnitude;
		transform.Translate(transform.forward * speed * Time.deltaTime, Space.World);

		float animationSpeedPercent = 1 * inputDir.magnitude;
		animator.SetFloat("speedPercent", animationSpeedPercent);

	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{

			animator.SetTrigger("Releasing");
			audioSource.PlayOneShot(whooshSFX, FXVolume);

			if (myPod)
			{
				myPod.transform.parent = null;
				Rigidbody rbPod = myPod.AddComponent<Rigidbody>();
				rbPod.AddForce(transform.forward * dropForce, ForceMode.Impulse);
				StartCoroutine(ReleasePod(rbPod));
			}
			else
			{
				havePodAlready = false;
			}
			myPod = null;
		}
	}

	IEnumerator ReleasePod(Rigidbody rbPod)
	{
		yield return new WaitForSeconds(podAirTime);
		if (rbPod)
		{
			havePodAlready = false;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag != "Snake")
		{
			return;
		}

		audioSource.PlayOneShot(ouchSFX, FXVolume);
		currentHealth -= damagePerHit;
		healthBar.SetHealth(currentHealth);
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.tag == "heal")
		{
			audioSource.PlayOneShot(lifeUpSFX, FXVolume);
			GameObject healingPod = collider.gameObject;
			currentHealth += healingPod.GetComponent<Heal>().numHealthToRestore;
			currentHealth = Mathf.Min(currentHealth, maxHealth);
			healthBar.SetHealth(currentHealth);
			Destroy(healingPod);
		}

		if (collider.tag == "Pod")
		{
			if (havePodAlready)
			{
				return;
			}

			animator.ResetTrigger("Releasing");
			animator.SetTrigger("Holding");
			audioSource.PlayOneShot(pickUpSFX, FXVolume);

			havePodAlready = true;

			collider.isTrigger = false;
			collider.transform.parent = transform;
			collider.transform.localPosition = PickUpPosition;
			collider.transform.localEulerAngles = PickUpRotation;
			myPod = collider.gameObject;
			Evolve myEvolve = myPod.GetComponent<Evolve>();
			myEvolve.podActivated = true;
		}
	}

	public IEnumerator PlayGameOverFX ()
	{
		audioSource.PlayOneShot(gameOverSFX, FXVolume);

		yield return new WaitForSeconds(gameOverSFX.length);
		FXVolume = 0.0f;
	}

}
