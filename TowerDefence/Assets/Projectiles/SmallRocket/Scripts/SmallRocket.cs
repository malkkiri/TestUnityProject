using UnityEngine;

public class SmallRocket : Projectile {

	public float Range = 40f;
	
	float distance;
	float time;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * Speed);
		distance += Time.deltaTime * Speed;
		if(Target != null) {
			transform.LookAt(Target);
		} else {
			Explode();
		}
		if(distance >= Range) {
			Explode();
		}
	}
	
}
