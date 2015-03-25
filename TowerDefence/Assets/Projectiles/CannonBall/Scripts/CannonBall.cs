using UnityEngine;

public class CannonBall : Projectile {
	
	public float Range = 10f;

	float distance;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * Speed);
		distance += Time.deltaTime * Speed;
		if(distance >= Range) {
			Explode();
		}
	}
}
