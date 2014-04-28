using UnityEngine;
using System.Collections;

public class OctoMove : MonoBehaviour 
{
	public float AmbientSpeed = 400.0f;
    public float RotationSpeed = 200.0f;
	
	private float nextrottime = 0;
	private float nextroll = 0;
	private float nextpitch = 0;
	private float nextyaw = 0;
	
	private float damping = 10f;

	
	private float distToShoot = 100f;
	
	void Update () 
	{
		if (Vector3.Distance(Playerton.i.transform.position, this.transform.position) < distToShoot)
		{
			Quaternion rotation = Quaternion.LookRotation(Playerton.i.transform.position - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * damping);
		}
		else
		{
			if (nextrottime < Time.time)
			{
				nextrottime = Time.time + Random.Range(5, 10);
				nextroll = Random.Range(-1f, 1f);
				nextpitch = Random.Range(-1f, 1f);
				nextyaw = Random.Range(-1f, 1f);
			}
			
			UpdateFunction();
		}
	}
	
	

	void UpdateFunction()
    {        
		Quaternion AddRot = Quaternion.identity;
        float roll = nextroll * (Time.deltaTime * RotationSpeed);
        float pitch = nextpitch * (Time.deltaTime * RotationSpeed);
        float yaw = nextyaw * (Time.deltaTime * RotationSpeed);
        
		AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        this.rigidbody.rotation *= AddRot;
        
		Vector3 AddPos = Vector3.up;
        AddPos = this.rigidbody.rotation * AddPos;
        this.rigidbody.velocity = AddPos * (Time.deltaTime * AmbientSpeed);
    }
}
