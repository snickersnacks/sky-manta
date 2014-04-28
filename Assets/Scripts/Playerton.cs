using UnityEngine;
using System.Collections;

public class Playerton : ThingStats 
{
	public static Playerton i;

	public Transform manta;
	
	void Awake()
	{
		i = this;

		Screen.showCursor = false;
	}
	
	void Update()
	{
		if (this.transform.position.y <= 0)
			UnderwaterEffect.Instance.enabled = true;
		else
			UnderwaterEffect.Instance.enabled = false;
	}

	public void DieDie()
	{
		this.GetComponent<Movement>().enabled = false;
		this.GetComponent<ParticleSystem>().enableEmission = false;
		Destroy(manta.gameObject);
	}
}
