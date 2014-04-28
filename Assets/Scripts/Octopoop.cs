using UnityEngine;
using System.Collections;

public class Octopoop : MonoBehaviour 
{
	public int maxpoop = 10;
	public Transform miniocto;

	void Start () 
	{
		StartCoroutine(poop());
	}

	IEnumerator poop()
	{
		do
		{
			//print ("waiting");
			yield return new WaitForSeconds(Random.Range(1, 10));

			if (GameObject.FindGameObjectsWithTag("miniocto").Length < maxpoop)
			{
				//print ("launching");
				Transform go = (Transform)GameObject.Instantiate(miniocto);
				go.position = this.transform.position;
				go.rotation = this.transform.rotation;
				go.rigidbody.AddRelativeForce(0, -2000, 0);
				go.GetComponent<OctoMove>().Launch(3);
			}
		} while (true);
	}
}
