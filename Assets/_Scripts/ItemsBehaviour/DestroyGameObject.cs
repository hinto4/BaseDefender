using UnityEngine;
using System.Collections;

public class DestroyGameObject : MonoBehaviour
{
    public float TimeTillDestroy = 1f;

    void Start ()
    {
	    DestroyObject(this.transform.gameObject, TimeTillDestroy);  
	}
	
}
