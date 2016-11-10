using UnityEngine;
using System.Collections;

public class VideoPlayer : MonoBehaviour {

	MovieTexture movieTexture;


	// Use this for initialization
	void Start () {
		movieTexture = (MovieTexture)GetComponent<Renderer> ().material.mainTexture;
		movieTexture.Play ();
		movieTexture.loop = true;
	}
	
}
