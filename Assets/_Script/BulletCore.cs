using UnityEngine;
using System.Collections;

public class BulletCore : MonoBehaviour {
	public Vector2 speedBullet;
	Rigidbody2D thisRig;

	// Use this for initialization
	void Awake () {
		thisRig = GetComponent<Rigidbody2D> ();
		//test
		//thisRig.velocity = speedXBullet;
	}
	void OnEnable()
	{
		Invoke ("DisableThis", 1);
	}

	public void DisableThis()
	{
		gameObject.SetActive (false);
	}
	void OnDisable()
	{
		CancelInvoke ("DisableThis");
	}
	public void SetAll(Vector2 _speed, Vector2 pos)
	{
		thisRig.velocity = _speed;
		gameObject.transform.position = new Vector3 (pos.x, pos.y, 0);
	}
}
