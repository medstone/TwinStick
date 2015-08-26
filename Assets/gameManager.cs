using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
	public Text nanoCount;
	public Text tankGrade;
	public Text valueGrade;
	public Text reloadGrade;
	public Text speedGrade;
	public GameObject enemyPrefab;
	public playerController player;
	public int spawn = 0;
	public int spawnTimer = 100;
	public int startval = 10;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<playerController>();
		enemyPrefab.GetComponent<enemyManager> ().value = startval;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawn == 0) {
			float ran = Random.value;
			Vector3 spawnLoc = Vector3.zero;
			spawnLoc.y = 1.5f;
			ran = ran * 7;
			if(ran >= 0 && ran < 1){
				spawnLoc.x = 45f;
				spawnLoc.z = 45f;
			}
			else if(ran >= 1 && ran < 2){
				spawnLoc.x = 45f;
				spawnLoc.z = 0f;
			}
			else if(ran >= 1 && ran < 2){
				spawnLoc.x = 45f;
				spawnLoc.z = -45f;
			}
			else if(ran >= 2 && ran < 3){
				spawnLoc.x = 0f;
				spawnLoc.z = -45f;
			}
			else if(ran >= 3 && ran < 4){
				spawnLoc.x = -45f;
				spawnLoc.z = -45f;
			}
			else if(ran >= 4 && ran < 5){
				spawnLoc.x = -45f;
				spawnLoc.z = 0f;
			}
			else if(ran >= 5 && ran < 6){
				spawnLoc.x = -45f;
				spawnLoc.z = 45f;
			}
			else{
				spawnLoc.x = 0f;
				spawnLoc.z = 45f;
			}
			GameObject enemySpw = Instantiate(enemyPrefab) as GameObject;
			enemySpw.transform.position = spawnLoc;
			spawn = spawnTimer;
		}
	}

	void FixedUpdate(){
		if (spawn > 0)
			spawn--;
	}
}
