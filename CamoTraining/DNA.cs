using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour {

	//gene for colour
	public float r;
	public float g;
	public float b;
	public float s;

	bool dead = false;
	public float timeToDie = 0;
	SpriteRenderer sRenderer;
	Collider2D sCollider;	

	void OnMouseDown()
	{
		dead = true;
		timeToDie = PopulationManager.elapsed;
		//Debug.Log("Dead At: " + timeToDie);
		sRenderer.enabled = false;
		sCollider.enabled = false;
	}	

	// Use this for initialization
	void Start () {
		sRenderer = GetComponent<SpriteRenderer>();
		sCollider = GetComponent<Collider2D>();	
		sRenderer.color = new Color(r,b,g);	
		this.transform.localScale = new Vector3(s,s,s);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
