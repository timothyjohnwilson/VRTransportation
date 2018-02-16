using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideToNextLevel : MonoBehaviour {

	public string tagName;
	public int sceneNumber;
	AsyncOperation asyncLoadLevel;
	void OnCollisionEnter(Collision collision){

		if (collision.gameObject.tag == tagName) {
			//asyncLoadLevel = SceneManager.LoadSceneAsync (sceneNumber, LoadSceneMode.Single);
			SceneManager.LoadScene(sceneNumber);
		}
	}


}
