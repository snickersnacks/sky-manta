using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
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
		if (deaded)
			return;

		if (killtime < Time.time)
			Destroy(this.gameObject);
	}

	private bool deaded = false;
	
	void OnTriggerEnter(Collider col)
	{
		if (deaded)
			return;

		ThingStats stats = null;
		Transform trans = col.gameObject.transform;

		while (stats == null && trans != null)
		{
			stats = trans.GetComponent<ThingStats>();
			trans = trans.parent;
		}

		if (stats != null && stats.gameObject != Firererer)
		{
			stats.Hit(damage);
			Destroy(this.gameObject);
			deaded = true;
		}

	}
}
