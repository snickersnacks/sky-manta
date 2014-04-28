using UnityEngine;
using System.Collections;

public class FishySpawner : MonoBehaviour 
{
	public Transform Fishy;

	void Start () 
	{
	
		for (int ctr = 0; ctr < 100; ctr++)
		{
			Transform fishy = (Transform)GameObject.Instantiate(Fishy);
			fishy.position = new Vector3(Random.Range(-1000, 1000), Random.Range(-200, -25), Random.Range(-1000, 1000));
			fishy.eulerAngles = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));

			fishy.transform.localScale = Vector3.one * Random.Range(1, 5);
		}
	}
}
