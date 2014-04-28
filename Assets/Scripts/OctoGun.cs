using UnityEngine;
using System.Collections;
using System.Linq;

public class OctoGun : MonoBehaviour 
{
	public static OctoGun i;
	public static ThingStats ostats;
	public static float HPPercent()
	{
		if (ostats == null)
			return 1;

		return ostats.hpperc();
	}

	public Transform[] Eyes;
	public ParticleSystem[] EyeParts;

	void Awake()
	{
		i = this;
		ostats = this.GetComponent<ThingStats>();
	}

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


	public float magic = 1;
	// Update is called once per frame
	void Update () 
	{
		if (nextFireTime < Time.time && Vector3.Distance(this.transform.position, Playerton.i.transform.position) < 1000)
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
					Quaternion from = eye.rotation;
					eye.LookAt(Playerton.i.transform);
					Quaternion to = eye.rotation;

					eye.rotation = Quaternion.Lerp(from, to, magic * Time.deltaTime);
					
					Ray ray = new Ray(eye.transform.position, eye.transform.TransformDirection(Vector3.forward));
					RaycastHit[] hits = Physics.SphereCastAll(ray, 6, 5000);
					bool didhit = hits.Any(hit => hit.collider.gameObject == Playerton.i.gameObject);

					if (didhit && Playerton.i.transform.position.y > 0)
						Playerton.i.Die();
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

			foreach (Transform eye in Eyes)
				eye.renderer.material.color = Color.black;
		}
	}
}
