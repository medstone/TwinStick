using UnityEngine;
using System.Collections;

public class bulletManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = this.transform.position;
		if(Mathf.Abs(pos.x) > 50 || Mathf.Abs(pos.z) > 50){
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Enemy") {
			Destroy(coll.gameObject);
			Destroy(this.gameObject);
		}
	}
}
