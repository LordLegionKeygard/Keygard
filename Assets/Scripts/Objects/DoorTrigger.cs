using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Door door;
	KeyHold keyHold;
	public GameObject keys;

	private void Awake()
	{
		keyHold = FindObjectOfType<KeyHold>();
	}


	void Update () {

	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{

			if (keyHold.key == 1) 
			{ 
				door.Open ();
				Destroy (keys);
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


	public void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{

			door.Close ();

		}

	}

}

