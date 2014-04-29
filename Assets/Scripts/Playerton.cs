using UnityEngine;
using System.Collections;

public class Playerton : ThingStats 
{
	public static Playerton i;

	public static int points = 0;

	public Transform manta;

	public Texture HPBar;
	public Texture RestartTexture;
	public Texture HealthTexture;
	public Texture PointsBG;
	public Texture WinTexture;

	public GameObject deadsound;
	public GameObject music;


	void Awake()
	{
		i = this;

		Screen.lockCursor = true;
		//Screen.showCursor = false;
		//GUIStyle generic_style = new GUIStyle();
	}
	
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			Screen.lockCursor = !Screen.lockCursor;
		}

		if (this.transform.position.y <= 0)
			UnderwaterEffect.Instance.enabled = true;
		else
			UnderwaterEffect.Instance.enabled = false;
	}

	private bool winnrar = false;
	public void Win()
	{
		points += 1000000;
		winnrar = true;
	}

	public void DieDie()
	{
		if (winnrar)
			return;

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
		GUI.skin.box = new GUIStyle();
		GUI.skin.box.alignment = TextAnchor.MiddleCenter;
		GUI.skin.box.fontSize = 20;
		GUI.skin.box.fontStyle = FontStyle.Bold;


		GUI.color = new Color(1, 1, 1, 0.3f);
		GUI.DrawTexture(new Rect(Screen.width/2 - 100/2, 10, 100, 40), PointsBG);
		GUI.color = new Color(1, 1, 1, 1f);
		GUI.Box(new Rect(Screen.width/2 - 100/2, 10, 100, 40), points.ToString());

		if (winnrar)
		{
			GUI.DrawTexture(new Rect(Screen.width/2 - WinTexture.width/2, Screen.height/2 - WinTexture.height/2, WinTexture.width, WinTexture.height), WinTexture);
			return;
		}

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
				Playerton.points = 0;
				Application.LoadLevel(0);
			}
		}


	}
}
