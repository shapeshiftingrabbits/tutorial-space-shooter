using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameController : MonoBehaviour {
	public GameObject hazard;

	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;

	public Text restartText;
	public Text gameOverText;

	private int score;
	private bool shouldRestart;
	private bool isGameOver;
	void Start () {
		score = 0;
		shouldRestart  = false;
		isGameOver  = false;

		restartText.enabled = shouldRestart;
		gameOverText.enabled = isGameOver;

		UpadteScore ();
		StartCoroutine (SpawnWaves ());
	}

	void Update (){
		if (shouldRestart){
			if (Input.GetKeyDown(KeyCode.R)){
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
			}
		}
	}

	 IEnumerator SpawnWaves (){
		 yield return new WaitForSeconds (startWait);
		 while(true){

			 for (int i = 0; i < hazardCount; ++i ){
				Vector3 spwanPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		
				Quaternion spawnRotation = Quaternion.identity;

				Instantiate (hazard, spwanPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);

			if (isGameOver){
				shouldRestart = true;
				restartText.enabled = shouldRestart;
				break;
			}
		}
	}

	public void AddScore  (int scoreIncrementValue){
		score += scoreIncrementValue;
		UpadteScore ();
	}

	void UpadteScore(){
		scoreText.text = "Score: " + score;
	}

	public void GameOver (){
		isGameOver = true;
		gameOverText.enabled = isGameOver;
	}
}
