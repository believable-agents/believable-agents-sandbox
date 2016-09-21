using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour {
	
	Animator anim;
	SWS.navMove nav;
	
	void Start() {
		anim = GetComponent<Animator>();
		nav = GetComponent<SWS.navMove>();
	}
	
	// Update is called once per frame
	public IEnumerator WaveCoroutine () {
		nav.Pause();
		anim.Play("Wave");
		yield return new WaitForSeconds(3);
		anim.CrossFade("Grounded", 0.5f);
		yield return new WaitForSeconds(1);
		nav.Resume();
	}
	
	public void Wave () {
		StartCoroutine(WaveCoroutine());
	}
}
