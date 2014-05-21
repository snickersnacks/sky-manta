using UnityEngine;
using System.Collections;

public class Playerton : ThingStats 
{
	public static Playerton i;

	public static int points = 0;

    public bool IsRift = false;

	public Transform manta;

	public Texture HPBar;
	public Texture RestartTexture;
	public Texture HealthTexture;
	public Texture PointsBG;
	public Texture WinTexture;

	public GameObject deadsound;
	public GameObject music;

	public GUISkin BLOODSKIN;

	void Awake()
	{
		i = this;

		//Screen.lockCursor = true;
		//Screen.showCursor = false;
		//GUIStyle generic_style = new GUIStyle();
	}
	
	void Update()
	{
		/*if (Input.GetMouseButtonDown(0))
			Screen.lockCursor = true;

		if (Input.GetKeyUp(KeyCode.Escape))
		{
			Screen.lockCursor = !Screen.lockCursor;
		}*/

		if (Camera.main.transform.position.y <= 0)
			UnderwaterEffect.Instance.enabled = true;
		else
			UnderwaterEffect.Instance.enabled = false;
	}

	private bool winnrar = false;
	public void Win()
	{
		//Screen.lockCursor = false;
		//Screen.showCursor = true;

		points += 1000000;
		winnrar = true;

		wintimebuttonpoop = Time.time + 2;
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

	private float wintimebuttonpoop = float.MaxValue;

	void OnGUI()
	{
		GUI.skin = BLOODSKIN;
		GUI.skin.box = new GUIStyle();
		GUI.skin.box.alignment = TextAnchor.MiddleCenter;
		GUI.skin.box.fontSize = 20;
		GUI.skin.box.fontStyle = FontStyle.Bold;

        if (IsRift)
        {
            DrawGUI(new Rect(0, (Screen.height / 2) / 2, Screen.width / 2, Screen.height / 2));
            DrawGUI(new Rect(Screen.width / 2, (Screen.height / 2) / 2, Screen.width / 2, Screen.height / 2));
        }
        else
        {
            DrawGUI(new Rect(0, 0, Screen.width, Screen.height));
        }
    }

    Rect DrawInside(Rect outside, Rect inside)
    {
        float xScaleFactor = Screen.width / outside.width;
        float yScaleFactor = Screen.height / outside.height;

        Rect newrect = new Rect(outside.left + (inside.left / xScaleFactor), outside.top + (inside.top / yScaleFactor), inside.width / xScaleFactor, inside.height / yScaleFactor);

        return newrect;
    }

    void DrawGUI(Rect outside)
    {
		GUI.color = new Color(1, 1, 1, 0.3f);
		GUI.DrawTexture(DrawInside(outside, new Rect(Screen.width/2 - 100/2, 10, 100, 40)), PointsBG);
		GUI.color = new Color(1, 1, 1, 1f);
		GUI.Box(DrawInside(outside, new Rect(Screen.width/2 - 100/2, 10, 100, 40)), points.ToString());

		if (winnrar)
		{
			if (GUI.Button(DrawInside(outside, new Rect(Screen.width/2 - WinTexture.width/2, Screen.height/2 - WinTexture.height/2, WinTexture.width, WinTexture.height)), WinTexture))
			{
				if (wintimebuttonpoop < Time.time)
				{
					Screen.showCursor = false;
					Playerton.points = 0;
					Application.LoadLevel(0);
				}
			}
			return;
		}

		if (OctoGun.i != null)
		{
			//Debug.Log(OctoGun.HPPercent());
			GUI.DrawTexture(DrawInside(outside, new Rect(Screen.width/2 - 1005/2, 60, 1005, 131)), HPBar);

			//player
			GUI.DrawTexture(DrawInside(outside, new Rect(Screen.width/2 - 1005/2 + 181, 62, this.hpperc() * 320, 59)), HealthTexture);

			//octo
			float octowidth = OctoGun.HPPercent() * 320;
			GUI.DrawTexture(DrawInside(outside, new Rect(Screen.width/2 + 1005/2 - 181 - octowidth, 62, octowidth, 59)), HealthTexture);
		}

		if (deaded)
		{
			Screen.lockCursor = false;
			Screen.showCursor = true;
			if (GUI.Button(DrawInside(outside, new Rect(Screen.width/2 - 800/2, Screen.height/2 - 400/2, 800, 400)), RestartTexture))
			{
				Screen.showCursor = false;
				Playerton.points = 0;
				Application.LoadLevel(0);
			}
		}


	}
}
