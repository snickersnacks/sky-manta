using UnityEngine;
using System.Collections;

public class FishySpawner : MonoBehaviour 
{
	public Transform Fishy;
	
	// Use this for initialization
	void Start () 
	{
	
		for (int ctr = 0; ctr < 100; ctr++)
		{
			Transform fishy = (Transform)GameObject.Instantiate(Fishy);
			fishy.position = new Vector3(Random.Range(-500, 500), Random.Range(-50, 0), Random.Range(-500, 500));
			fishy.eulerAngles = new Vector3(Random.Range(-360, 360), Random.Range(-360, 360), Random.Range(-360, 360));
			fishy.transform.localScale = new Vector3(Random.Range(1, 5), Random.Range(1, 5), Random.Range(1, 5));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
