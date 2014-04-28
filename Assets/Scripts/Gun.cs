using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour 
{
	private GameObject _stats = null;

	public GameObject GetStatsObject()
	{
		if (_stats == null)
		{
			Transform trans = this.transform;
			ThingStats stats = trans.GetComponent<ThingStats>();

			while (stats == null && trans != null)
			{
				stats = trans.GetComponent<ThingStats>();
				if (stats == null)
					trans = trans.parent;
			}

			_stats = stats.gameObject;
		}
		return _stats;
	}
}
