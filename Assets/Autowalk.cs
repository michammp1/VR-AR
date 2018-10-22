
using UnityEngine;
using System.Collections;

public class Autowalk : MonoBehaviour 
{
	private const int RIGHT_ANGLE = 90; 
	
	// This variable determinates if the player will move or not 
	private bool isWalking = false;

	GvrHeadset head = null;
	
	//This is the variable for the player speed
	[Tooltip("With this speed the player will move.")]
	public float speed;
	
	[Tooltip("Activate this checkbox if the player shall move when the Cardboard trigger is pulled.")]
	public bool walkWhenTriggered;
	
		
	void Start () 
	{
		head = Camera.main.GetComponent<GvrHeadset>();
	}

	void Update () 
	{
        if (Input.GetButtonDown("Fire1"))
        {
            isWalking = !isWalking;
        }
        // Walk when the Cardboard Trigger is used 
        if (walkWhenTriggered && !isWalking) 
		{
			isWalking = true;
		} 
		else if (walkWhenTriggered && isWalking) 
		{
			isWalking = false;
		}

        if (isWalking) 
		{
			Vector3 direction = new Vector3(head.transform.forward.x, 0, head.transform.forward.z).normalized * speed * Time.deltaTime;
			Quaternion rotation = Quaternion.Euler(new Vector3(0, -transform.rotation.eulerAngles.y, 0));
			transform.Translate(rotation * direction);
		}

	}
}
