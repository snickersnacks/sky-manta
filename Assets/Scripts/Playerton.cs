using UnityEngine;
using System.Collections;

public class Playerton : ThingStats 
{
	public static Playerton i;

	public Transform manta;

	public Texture HPBar;
	public Texture RestartTexture;
	public Texture HealthTexture;

	public GameObject deadsound;
	public GameObject music;

	void Awake()
	{
		i = this;

		Screen.showCursor = false;
		//GUIStyle generic_style = new GUIStyle();
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
		Destroy(music);
		deadsound.audio.Play();
		hp = 0;
		this.GetComponent<Movement>().enabled = false;
		this.GetComponent<ParticleSystem>().enableEmission = false;
		Destroy(manta.gameObject);
	}

	void OnGUI()
	{
		GUI.skin = new GUISkin();

		if (OctoGun.i != null)
		{
			//Debug.Log(OctoGun.HPPercent());
			GUI.Box(new Rect(Screen.width/2 - 1005/2, 60, 1005, 131), HPBar);

			//player
			GUI.DrawTexture(new Rect(Screen.width/2 - 1005/2 + 181, 62, this.hpperc() * 320, 59), HealthTexture);

			//octo
			float octowidth = OctoGun.HPPercent() * 320;
			GUI.DrawTexture(new Rect(Screen.width/2 + 1005/2 - 181 - octowidth, 62, octowidth, 59), HealthTexture);
		}

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
