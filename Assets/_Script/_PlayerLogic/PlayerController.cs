using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float Speed;
	Rigidbody2D thisRig;
	public float fireRate;
	float currentTime;
	WeaponController weaponController;
	// Use this for initialization
	void Start () {
		thisRig = GetComponent<Rigidbody2D> ();
		weaponController = GetComponent<WeaponController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxis ("Horizontal") * Speed;
		float v = Input.GetAxis ("Vertical") * Speed;
		thisRig.velocity = new Vector2 (h, v);

		currentTime += Time.deltaTime;
		if (currentTime > fireRate &&  Input.GetButton("Fire1")	) {
			weaponController.SplitFire (this.gameObject.transform.position);
			currentTime = 0;
		}
			
	}
}
