using UnityEngine;

public class ArtilleryShell : Projectile {
	
	public float Angle = 88;
	
	float time;
	Vector3 pos;
	float airTime;
	float a, b, c; // Parabola coeficients
	
	// Use this for initialization
	void Start () {
		float tan = Mathf.Tan(Angle * Mathf.PI / 180);
		pos = transform.position;
		airTime = Mathf.Sqrt(Mathf.Pow(pos.x - Aim.x, 2) + Mathf.Pow(pos.z - Aim.z, 2)) / Speed;
		a = (Aim.y - tan * airTime - pos.y) / Mathf.Pow(airTime, 2);
		b = tan;
		c = pos.y;
	}
	
	// Update is called once per frame
	void Update () {
		float x = Aim.x * time / airTime + pos.x * (1 - time / airTime);
		float z = Aim.z * time / airTime + pos.z * (1 - time / airTime);
		float y = a * Mathf.Pow(time, 2) + b * time + c;
		transform.position = new Vector3(x, y, z);
		float xt = Aim.x - pos.x;
		float zt = Aim.z - pos.z;
		float yt = 2 * a * time + b;
		transform.up = new Vector3(xt, yt, zt);
		time += Time.deltaTime;
	}
}
