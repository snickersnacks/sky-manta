using UnityEngine;
using System.Collections;

public class ThingStats : MonoBehaviour 
{
	public int hp = 10;
	
	private static GameObject _explosion;
	public static GameObject explosion 
	{ 
		get 
		{ 
			if (_explosion == null)
			{
				_explosion = (GameObject)Resources.Load("Explosion");
			}

			return _explosion; 
		} 
	}
	
	public void Hit(int damage)
	{
		hp -= damage;
		
		Debug.Log("Hit for " + damage + " damage. HP: " + hp);
		
		if (hp <= 0)
			Die();
	}

	protected bool deaded = false;
	public void Die()
	{
		if (deaded == true)
			return;

		Transform exp = ((GameObject)GameObject.Instantiate(explosion)).transform;
		exp.position = this.transform.position;
		exp.GetComponent<Detonator>().size = this.transform.localScale.x;
		
		//explode
		if (this.gameObject != Playerton.i.gameObject)
			Destroy(this.gameObject);
		else
			Playerton.i.DieDie();

		deaded = true;
	}
}
