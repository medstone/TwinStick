using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {
	public float speed = 10f;
	public float spawnDist = 0;
	public float bulletSpeed = 20f;
	public GameObject bulletPrefab;
	public int reloadTime = 25;
	public int reload = 0;
	public int inv = 0;
	public int maxInv = 50;
	public int health = 3;
	int maxhealth = 3;

	// Use this for initialization
	void Start () {
		spawnDist = (this.transform.lossyScale.x + bulletPrefab.transform.lossyScale.x) / 2f;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Application.LoadLevel("_Scene_0");
		}
		if (health > maxhealth) {
			health = maxhealth;
		}
		//print(health);
		Vector3 speedVec = Vector3.zero;
		Vector3 bulletVel = Vector3.zero;
		GetMove(ref speedVec);
		this.GetComponent<Rigidbody>().velocity = speedVec;
		if (reload > 0)
			return;
		Vector3 bulletPos = this.transform.position;
		GetBullet(ref bulletVel, ref bulletPos);
		if (bulletVel == Vector3.zero) return;
		GameObject bulletMake = Instantiate (bulletPrefab) as GameObject;
		bulletMake.transform.position = bulletPos;
		bulletMake.GetComponent<Rigidbody>().velocity = bulletVel;
		reload = reloadTime;
	}

	void FixedUpdate(){
		if (reload > 0) reload--;
		if (inv > 0) inv--;
		if (inv % 2 == 1) {
			this.GetComponent<Renderer>().enabled = !this.GetComponent<Renderer>().enabled;
		}
		if (inv == 0) {
			this.GetComponent<Renderer>().enabled = true;
		}
	}

	public void OnHit(){
		if (inv == 0) {
			health--;
			inv = maxInv;
		}
	}

	void GetMove(ref Vector3 speedVec){
		//Add code for phone controller api for movement here.
		//If there is an connected/disconnected function maybe wrap the keyboard controlls in an if so they only run when no phone is connected?
		if (Input.GetKey (KeyCode.A)) {
			speedVec.x -= speed;
		}
		if (Input.GetKey (KeyCode.D)) {
			speedVec.x += speed;
		}
		if (Input.GetKey (KeyCode.W)) {
			speedVec.z += speed;
		}
		if(Input.GetKey(KeyCode.S)){
			speedVec.z -= speed;
		}
	}

	void GetBullet(ref Vector3 bulletVel, ref Vector3 bulletPos){
		//Add code for phone controller api for shooting here.
		//If there is an connected/disconnected function maybe wrap the keyboard controlls in an if so they only run when no phone is connected?
		if(Input.GetKey(KeyCode.UpArrow)){
			bulletVel.z += bulletSpeed;
			bulletPos.z += spawnDist;
		}
		if(Input.GetKey(KeyCode.DownArrow)){
			bulletVel.z -= bulletSpeed;
			bulletPos.z -= spawnDist;
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			bulletVel.x -= bulletSpeed;
			bulletPos.x -= spawnDist;
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			bulletVel.x += bulletSpeed;
			bulletPos.x += spawnDist;
		}
	}
}
