using UnityEngine;
using System.Collections;

public class Octopoopgun : Gun 
{
	public Transform LaserBeam;
	private float nextfire = 0;
	private float delay = 0.4f;

	public float distToShoot = 100f;
	
	// Update is called once per frame
	void Update () 
	{
		if (nextfire < Time.time)
		{
			if (Vector3.Distance(Playerton.i.transform.position, this.transform.position) < distToShoot)
			{
				this.audio.Play();
				Transform laserbeam = (Transform)GameObject.Instantiate(LaserBeam);
				laserbeam.GetComponent<Bullet>().Firererer = this.GetStatsObject();
				laserbeam.position = this.transform.position;
				laserbeam.rotation = this.transform.rotation;
				//laserbeam.rigidbody.velocity = this.transform.rigidbody.velocity; //lol
				laserbeam.rigidbody.AddRelativeForce(0, 5000, 0);

			}
			nextfire = Time.time + Random.Range(delay - 0.2f, delay + 0.2f);
		}
	}
}
