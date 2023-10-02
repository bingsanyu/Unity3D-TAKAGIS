using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour {
	public AudioClip collectSound;
	bool haveMatches = false;
	public GUITexture matchGUIprefab;
	GUITexture matchGUI;
	public GUIText textHints;
	bool fireIsLit = false;
	public GameObject winObj;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void MatchPickup(){
		haveMatches = true;
		AudioSource.PlayClipAtPoint (collectSound, transform.position);
		GUITexture matchHUD = Instantiate (matchGUIprefab, new Vector3 (0.15f, 0.1f, 0), transform.rotation) as GUITexture;
		matchGUI = matchHUD;
	}
	void OnControllerColliderHit(ControllerColliderHit col){
		if (col.gameObject.name == "campfire") {
			if(haveMatches && !fireIsLit){
				LightFire(col.gameObject);
			}
			else if (!haveMatches && !fireIsLit){
				textHints.SendMessage("ShowHint","I could use this campfire to signal for help..."+
				                      "if only I could light it...");
			}
		}
	}
	void LightFire(GameObject campfire){
		ParticleSystem[] pSystems;
		pSystems = campfire.GetComponentsInChildren<ParticleSystem> ();
		foreach (ParticleSystem pSystem in pSystems) {
			pSystem.Play();
		}
		campfire.audio.Play ();
		Destroy (matchGUI);
		haveMatches = false;
		fireIsLit = true;
		winObj.SendMessage ("GameOver");
	}
}
