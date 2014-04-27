using UnityEngine;
using System.Collections;

public class FishyGun : MonoBehaviour 
{
	public Transform LaserBeam;
	private float nextfire = 0;
	private float delay = 0.4f;

	private float distToShoot = 1f;
	
	// Update is called once per frame
	void Update () 
	{
		if (nextfire < Time.time)
		{
			if (Vector3.Distance(Playerton.i.transform.position, this.transform.position) < distToShoot)
			{
				this.audio.Play();
				Transform laserbeam = (Transform)GameObject.Instantiate(LaserBeam);
				laserbeam.GetComponent<Laser>().Firererer = this.transform.parent.gameObject;
				laserbeam.position = this.transform.position;
				laserbeam.rotation = this.transform.rotation;
				laserbeam.rigidbody.velocity = this.transform.parent.rigidbody.velocity; //lol
				laserbeam.rigidbody.AddRelativeForce(0, 5000, 0);

			}
			nextfire = Time.time + Random.Range(delay - 0.2f, delay + 0.2f);
		}
	}
}
