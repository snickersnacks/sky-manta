using UnityEngine;
using System.Collections;

public class Playerton : MonoBehaviour 
{
	public static Playerton i;
	
	void Awake()
	{
		i = this;
	}
	
	void Update()
	{
		if (this.transform.position.y <= 0)
			UnderwaterEffect.Instance.enabled = true;
		else
			UnderwaterEffect.Instance.enabled = false;
	}
}
