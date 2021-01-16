using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHold : MonoBehaviour
{
    public bool hold;
	public bool hasKey = false;
	public float key;
	public GameObject KeyCanvas;
	public AudioSource soundkey;

	void Start () 
	{
		
	}

	private void OnTriggerEnter2D(Collider2D other)
    {		
        if(other.CompareTag("key"))
        {
			key ++;
			if (key == 1)
			{			
				hasKey = true;
				hold = true;
				soundkey.Play();
			}
			

			if (key > 1)
			{
				key = 1;
			}

			if (key <= 0) 
			{
				key = 0;
			}
				  
            Destroy(other.gameObject);

			
			if (key >= 1)
			{
				KeyCanvas.SetActive(true);
			}
			
        }
    }
	
	private void Update()
	{
		if (key == 0)
			{
				hasKey = false;
				hold = false;
				KeyCanvas.SetActive(false);
			}
	}
}

