using UnityEngine;
using System.Collections;

public class OctoGun : MonoBehaviour 
{
	public Transform[] Eyes;
	public ParticleSystem[] EyeParts;

	// Use this for initialization
	void Start () 
	{

	}

	public float fireForTime = 2;
	public float fireCooldown = 5;
	public float nextFireTime = 0;
	public float stopFireAtTime = -1;
	public float startFireAtTime = 0;
	public float warningPeriod = 3;

	// Update is called once per frame
	void Update () 
	{
		if (nextFireTime < Time.time && Vector3.Distance(this.transform.position, Playerton.i.transform.position) < 500)
		{
			if (stopFireAtTime == -1)
			{
				startFireAtTime = Time.time + warningPeriod;
				stopFireAtTime = startFireAtTime + fireForTime;

				foreach (Transform eye in Eyes)
					eye.renderer.material.color = Color.red;
			}

			if (startFireAtTime < Time.time)
			{
				foreach (Transform eye in Eyes)
					eye.renderer.material.color = Color.white;

				foreach (Transform eye in Eyes)
				{
					eye.LookAt(Playerton.i.transform);
				}

				foreach (ParticleSystem par in EyeParts)
				{
					par.enableEmission = true;
				}
			}

			if (stopFireAtTime < Time.time)
			{
				stopFireAtTime = -1;
				nextFireTime = Time.time + fireCooldown;

				foreach (Transform eye in Eyes)
					eye.renderer.material.color = Color.black;
			}
		}
		else
		{
			foreach (ParticleSystem par in EyeParts)
			{
				par.enableEmission = false;
			}
		}
	}
}
