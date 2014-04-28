using UnityEngine;
using System.Collections;

public class OctoSpawner : MonoBehaviour 
{
	public Transform Octo;

	void Start () 
	{
	
		for (int ctr = 0; ctr < 100; ctr++)
		{
			Transform fishy = (Transform)GameObject.Instantiate(Octo);
			fishy.position = new Vector3(Random.Range(-500, 500), Random.Range(-50, 0), Random.Range(-500, 500));
			fishy.eulerAngles = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));

			float rand = Random.Range(20, 50);

			fishy.transform.localScale = Vector3.one * rand;
		}
	}
}
