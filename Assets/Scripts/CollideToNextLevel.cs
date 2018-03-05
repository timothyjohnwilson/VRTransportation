using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollideToNextLevel : MonoBehaviour {

	public string tagName;
	public int sceneNumber;
	AsyncOperation asyncLoadLevel;
	void OnCollisionEnter(Collision collision){
        Debug.Log(gameObject.tag);
		if (collision.gameObject.tag == tagName) {
			SceneManager.LoadScene(sceneNumber);
		}
	}


}
