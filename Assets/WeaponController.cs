using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponController : MonoBehaviour {
	public GameObject bullet;
	public List<GameObject> poolBullet;
	public int totalPool;

	void Start()
	{
		poolBullet = new List<GameObject> ();

		for (int i = 0; i < totalPool; i++) {
			GameObject pool = (GameObject)Instantiate (bullet);
			poolBullet.Add (pool);
			pool.SetActive (false);
		}
	}

	public void NormalFire(Vector3 posPlayer)
	{
		Fire (new Vector2 (0, 15),new Vector2 (posPlayer.x, posPlayer.y+0.5f));
	}

	public void SplitFire(Vector3 posPlayer)
	{
		Fire (new Vector2 (-2, 15),new Vector2 (posPlayer.x-0.5f, posPlayer.y+0.5f));
		Fire (new Vector2 (2, 15),new Vector2 (posPlayer.x+0.5f, posPlayer.y+0.5f));
		Fire (new Vector2 (0, 15),new Vector2 (posPlayer.x, posPlayer.y+0.5f));
	}

	public void Fire(Vector2 _pos,Vector2 _speed)
	{
		for (int i = 0; i < poolBullet.Count; i++) {
			if (!poolBullet [i].activeSelf) {
				poolBullet [i].SetActive (true);
				poolBullet [i].GetComponent<BulletCore> ().SetAll (_pos, _speed);

				return;
			}
		}

		GameObject pool = (GameObject)Instantiate (bullet);
		poolBullet.Add (pool);
		pool.GetComponent<BulletCore> ().SetAll (_pos, _speed);
		return;

	}

}
