using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	float slowrate = -50;
	float wateraccrate = 50;
	float airaccrate = 150;
	
	// Update is called once per frame
	void Update () 
	{
		float change;
		
		//if they're under water
		if (this.transform.position.y < 0)
		{
			if (AmbientSpeed > 100) //if we're going faster than 100, slow down
				change = slowrate;
			else //if we're going slower than 100, speed up
				change = wateraccrate;
		}
		else //if they're in the air
		{
			change = airaccrate;
		}
		
		change *= Time.deltaTime;
		AmbientSpeed += change;
		
		float mul = AmbientSpeed / BaseAmbientSpeed;
		this.particleSystem.emissionRate = mul * BasePartRate;
		this.particleSystem.startSpeed = mul * BasePartSpeed;
		
		UpdateFunction();
		
		//if (this.transform.position.y > 0)
		//	this.rigidbody.velocity += Physics.gravity;
		
		//Debug.Log("Speed: " + AmbientSpeed);	
	}
	
	public float BasePartRate = 100f;
	public float BasePartSpeed = -5;
	public float BaseAmbientSpeed = 100.0f;
	public float AmbientSpeed = 100.0f;

    public float RotationSpeed = 200.0f;

	void UpdateFunction()
    {        
		Quaternion AddRot = Quaternion.identity;
        float roll = 0;
        float pitch = 0;
        float yaw = 0;
        roll = Input.GetAxis("Roll") * (Time.deltaTime * RotationSpeed);
        pitch = Input.GetAxis("Pitch") * (Time.deltaTime * RotationSpeed);
        yaw = Input.GetAxis("Yaw") * (Time.deltaTime * RotationSpeed);
        
		AddRot.eulerAngles = new Vector3(-pitch, yaw, -roll);
        this.rigidbody.rotation *= AddRot;
        
		Vector3 AddPos = Vector3.forward;
        AddPos = this.rigidbody.rotation * AddPos;
        this.rigidbody.velocity = AddPos * (Time.deltaTime * AmbientSpeed);
    }
}
