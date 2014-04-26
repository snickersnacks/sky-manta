using UnityEngine;
using System.Collections;

public class FishyStats : MonoBehaviour 
{
	public int hp = 5;
	
	public Transform explosion;
	
	public void Hit(int damage)
	{
		hp -= damage;
		
		Debug.Log("Hit for " + damage + " damage. HP: " + hp);
		
		if (hp <= 0)
			Die();
	}
	
	public void Die()
	{
		Transform exp = (Transform)GameObject.Instantiate(explosion);
		exp.position = this.transform.position;
		exp.GetComponent<Detonator>().size = this.transform.localScale.x;
		
		//explode
		Destroy(this.gameObject);
	}
}
