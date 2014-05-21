using UnityEngine;
using System.Collections;

public class poopsky : MonoBehaviour 
{
    public Transform follow;
	void Update () 
    {
        this.transform.position = follow.position;
	
	}
}
