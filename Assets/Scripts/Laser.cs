using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour 
{
	public GameObject Firererer;
	public int damage = 1;
	
	private float timetokill = 5;
	private float killtime;
	
	void Start()
	{
		killtime = Time.time + timetokill;
	}
	
	void Update()
	{
		if (killtime < Time.time)
			Destroy(this.gameObject);
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject != Firererer)
		{
			FishyStats stats = col.gameObject.GetComponent<FishyStats>();
			if (stats != null)
			{
				stats.Hit(damage);
				Destroy(this.gameObject);
			}
			else
			{
				Playerton player = col.gameObject.GetComponent<Playerton>();
				if (player != null)
				{
					player.Hit(damage);
					Destroy(this.gameObject);
				}
				else
					Debug.Log("Hit thing, but no fishy stats");
			}
		}

	}
}
