using UnityEngine;
using System.Collections;

public class enemyManager : MonoBehaviour {
	GameObject player;
	public float speed = 5f;
	public int damage = 10;
	public int value = 10;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 enemyVel = Vector3.zero;
		float diffx = this.transform.position.x - player.transform.position.x;
		float diffz = this.transform.position.z - player.transform.position.z;
		if ((diffx < 1 && diffx > -1) || (diffz < 1 && diffz > -1))
			return;
		enemyVel.x = -(diffx / Mathf.Sqrt (diffx * diffx + diffz * diffz)) * speed;
		enemyVel.z = -(diffz / Mathf.Sqrt (diffx * diffx + diffz * diffz)) * speed;
		this.GetComponent<Rigidbody>().velocity = enemyVel;
	}

	void OnCollisionEnter(Collision coll){
		if(coll.gameObject.tag=="Player"){
			coll.gameObject.GetComponent<playerController>().OnHit();
		}
	}

	void OnCollisionStay(Collision coll){
		OnCollisionEnter (coll);
	}

	void OnDestroy(){
	}
}
