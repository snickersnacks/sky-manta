using UnityEngine;
using System.Collections;

public class BOSSSPAWN : MonoBehaviour 
{
	public Transform BOSS;
	public float TimeToSpawn;

	void Start()
	{
		StartCoroutine(WaitToSpawn(TimeToSpawn));
	}

	public IEnumerator WaitToSpawn(float TimeToSpawn)
	{
		yield return new WaitForSeconds(TimeToSpawn);

		Transform boss = (Transform)GameObject.Instantiate(BOSS);
		boss.GetComponent<ThingStats>().enabled = true;
		boss.position = new Vector3(Random.Range(-750, 750), -200, Random.Range(-750, 750));
		boss.rigidbody.AddRelativeForce(0, 3000, 0);

		yield return new WaitForSeconds(5);
		
		boss.GetComponent<ThingStats>().enabled = true;
		boss.GetComponent<Octopoop>().enabled = true;
		boss.GetComponent<OctoGun>().enabled = true;
		boss.GetComponent<MeshCollider>().enabled = true;
		boss.GetComponent<BossMove>().enabled = true;
		boss.GetComponent<BossMove>().Launch(1);
	}

	void OnGUI()
	{
		//if (Time.realtimeSinceStartup < TimeToSpawn)
		//	GUI.Label(new Rect(0, 0, 30, 30), ((int)(TimeToSpawn - Time.realtimeSinceStartup)).ToString());
	}
}
