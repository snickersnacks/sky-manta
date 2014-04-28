using UnityEngine;
using System.Collections;

public class ThingStats : MonoBehaviour 
{
	public int hp = 10;
	
	private static GameObject explosion;

	void Awake()
	{
		if (explosion == null)
		{
			Debug.Log("Loading explosion");
			explosion = (GameObject)Resources.Load("Explosion");
		}
	}
	
	public void Hit(int damage)
	{
		hp -= damage;
		
		Debug.Log("Hit for " + damage + " damage. HP: " + hp);
		
		if (hp <= 0)
			Die();
	}
	
	public void Die()
	{
		Transform exp = ((GameObject)GameObject.Instantiate(explosion)).transform;
		exp.position = this.transform.position;
		exp.GetComponent<Detonator>().size = this.transform.localScale.x;
		
		//explode
		Destroy(this.gameObject);
	}
}
