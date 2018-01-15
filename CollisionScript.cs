using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScript : MonoBehaviour {

	public GameObject target ;
	public GameObject[] obstacle;

	private Renderer renderer;
	private float[] origPosition = new float[3];
	private float[] origScale = new float[3];

	private void Start(){
		renderer = GetComponent<Renderer> ();
		target.GetComponent<Renderer> ().material.color = Color.red;

		for(int i=0;i<obstacle.Length;i++){
			origPosition [i] = obstacle [i].transform.position.x;
			origScale [i] = obstacle [i].transform.localScale.x;
		}
	}

	private void OnCollisionEnter( Collision collision){
		
		if(collision.gameObject.tag == "CollisionObject"){
			transform.position = Vector3.zero;
			transform.rotation = Quaternion.Euler(Vector3.zero);

			for(int i=0;i<obstacle.Length;i++){
				obstacle [i].transform.position = new Vector3 (Random.Range(origPosition[i]-5,origPosition[i]+5),obstacle [i].transform.position.y,0f);
				obstacle [i].transform.localScale = new Vector3(Random.Range(origScale[i],origScale[i]+3),obstacle [i].transform.localScale.y,1);
			}
		} 

		if(collision.gameObject.tag == "Target"){
			target.GetComponent<Renderer> ().material.color = Color.green;
		} else {
			target.GetComponent<Renderer> ().material.color = Color.red;
		}
	} 
}
