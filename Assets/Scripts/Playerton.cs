using UnityEngine;
using System.Collections;

public class Playerton : ThingStats 
{
	public static Playerton i;

	public Transform manta;

	public Texture RestartTexture;
	
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

	void OnGUI()
	{
		if (deaded)
		{
			Screen.showCursor = true;
			if (GUI.Button(new Rect(Screen.width/2 - 800/2, Screen.height/2 - 400/2, 800, 400), RestartTexture))
			{
				Screen.showCursor = false;
				Application.LoadLevel(0);
			}
		}
	}
}
