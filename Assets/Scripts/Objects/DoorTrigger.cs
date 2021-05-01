using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;
	KeyHold keyHold;

	public bool twokey = false;

	private void Awake()
	{
		keyHold = FindObjectOfType<KeyHold>();
	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if(twokey == true)
		{
			return;
		}
		if (col.tag == "Player") 
		{

			if (keyHold.key == 1) 
			{ 
				twokey = true;
				door.Open ();
				keyHold.key--;
			}
		}

		if(keyHold.key > 1)
		{
			keyHold.key = 1;
		}

		if(keyHold.key < 0)
		{
			keyHold.key = 0;
		}
	}
}

