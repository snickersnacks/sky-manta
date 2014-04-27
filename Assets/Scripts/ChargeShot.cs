using UnityEngine;
using System.Collections;

public class ChargeShot : MonoBehaviour 
{
	public GameObject Firererer;
	public int damage = 10;
	
	private float timetokill = 5;
	private float killtime;
	
	void Start()
	{
		killtime = Time.time + timetokill;
	}
	
	void Update()
	{
		if (deaded)
			return;

		if (killtime < Time.time)
			DestroyImmediate(this.gameObject);
	}

	private bool deaded = false;
	
	void OnTriggerEnter(Collider col)
	{
		if (deaded)
			return;

		if (col.gameObject != Firererer)
		{
			FishyStats stats = col.gameObject.GetComponent<FishyStats>();
			if (stats != null)
			{
				stats.Hit(damage);
				Destroy(this.gameObject);
				deaded = true;
			}
			else
			{
				Playerton player = col.gameObject.GetComponent<Playerton>();
				if (player != null)
				{
					player.Hit(damage);
					Destroy(this.gameObject);
					deaded = true;
				}
				else
					Debug.Log("Hit thing, but no fishy stats");
			}
		}

	}
}
