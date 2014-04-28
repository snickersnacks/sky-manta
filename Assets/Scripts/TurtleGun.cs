using UnityEngine;
using System.Collections;

public class TurtleGun : Gun 
{
	public Transform LaserBeam;
	public Transform ChargeBeam;

	private float nextfire = 0;
	private float delay = 0.75f;
	private float chargeDelay = 0.25f;
	private float chargeTime = 1f;
	private float chargeEnd = float.MaxValue;
	private float chargeStart;

	private float longtime;
	private float shorttime;

	void Awake()
	{
		shorttime = this.audio.time;
		longtime = shorttime * 2;
	}

	private Transform currentCharge;
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButton("Fire2"))
		{
			if (chargeEnd == float.MaxValue && nextfire < Time.time)
			{
				chargeStart = Time.time;
				chargeEnd = Time.time + chargeTime;

				if (currentCharge != null)
					DestroyImmediate(currentCharge.gameObject);
				
				currentCharge = (Transform)GameObject.Instantiate(ChargeBeam);
				currentCharge.GetComponent<Bullet>().Firererer = this.GetStatsObject();
				currentCharge.parent = this.transform;
				currentCharge.localPosition = Vector3.zero;
				currentCharge.localScale = Vector3.one * 0.1f;
			}

			if (chargeEnd != float.MaxValue && chargeEnd > Time.time)
			{
				currentCharge.localScale = Vector3.one * 10f * (Time.time - chargeStart);
				Debug.Log(currentCharge.localScale);
			}

			if (chargeEnd < Time.time)
			{
				print ("FIRING");
				this.audio.time = longtime;
				this.audio.Play();
				currentCharge.parent = null;
				currentCharge.gameObject.AddComponent<Rigidbody>();
				currentCharge.rotation = this.transform.rotation;
				currentCharge.rigidbody.useGravity = false;
				currentCharge.rigidbody.velocity = this.transform.parent.rigidbody.velocity; //lol //why is this funny
				currentCharge.rigidbody.AddRelativeForce(0, 5000, 0);

				nextfire = Time.time + chargeDelay;
				chargeEnd = float.MaxValue;
				chargeStart = -1;
				currentCharge = null;
			}
		}
		else if (Input.GetButtonUp("Fire2"))
		{
			chargeEnd = float.MaxValue;
			if (currentCharge != null)
				DestroyImmediate(currentCharge.gameObject);
		}
		else if (Input.GetButton("Fire1"))
		{
			if (nextfire < Time.time)
			{
				StartCoroutine(FireShot(0.01f));
				StartCoroutine(FireShot(0.1f));
				nextfire = Time.time + delay;
			}
		}
	}

	IEnumerator FireShot(float insec)
	{
		yield return new WaitForSeconds(insec);
		
		this.audio.time = shorttime;
		this.audio.Play();
		Transform laserbeam = (Transform)GameObject.Instantiate(LaserBeam);
		laserbeam.GetComponent<Bullet>().Firererer = this.GetStatsObject();
		laserbeam.position = this.transform.position;
		laserbeam.rotation = this.transform.rotation;
		laserbeam.rigidbody.useGravity = false;
		laserbeam.rigidbody.velocity = this.transform.parent.rigidbody.velocity; //lol
		laserbeam.rigidbody.AddRelativeForce(0, 5000, 0);
	}
}
