using UnityEngine;

public enum Type {Ground, Air, Both};

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(AudioSource))]
public class Tower : MonoBehaviour {

	public Type TowerType = Type.Ground;

	public GameObject Projectile;
	public GameObject MuzzleEffect;

	public float TurnSpeed;
	public float ReloadTime = 1f;
	public float ReloadDelay = 0.5f;
	public float FirePauseTime = 0.25f;

	public float ErrorAmount = 0.5f;

	public Transform Target;
	public Transform[] MuzzlePositions;

	public delegate void SelectAction(Vector3 value);
	public static event SelectAction OnSelect;

	protected float NextFireTime;
	protected float NextMoveTime;
	protected Vector3 AimError;
	protected Vector3 AimPoint;

	// Use this for initialization
	void Start () {

	}
	void OnMouseDown(){
        
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Update");
		if(Target == null) return;
		if(NextMoveTime <= 0) {
			CalculateAimPosition(Target.position);
			RotateTowardsTarget();
		}
		NextFireTime -= Time.deltaTime;
		NextMoveTime -= Time.deltaTime;
		if(NextFireTime <= 0) {
			FireProjectile();
		}
	}

	void OnTriggerStay(Collider other) {
		Debug.Log ("OnTriggerStay");
		if(Target != null) return;
		GameObject otherGO = other.gameObject;
		if(otherGO.tag == TowerType + " Enemy" || TowerType == Type.Both) {
			NextFireTime = ReloadTime * ReloadDelay;
			Target = otherGO.transform;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if(other.gameObject.transform == Target) {
			Target = null;
		}
	}

	public Vector3 CalculateAimError() {
		float radius = Random.Range(0f, ErrorAmount);
		float alpha = Random.Range(0, 360);
		float beta = Random.Range(0f, 180f);
		float x = radius * Mathf.Sin(beta) * Mathf.Cos(alpha);
		float y = radius * Mathf.Cos(beta);
		float z = radius * Mathf.Sin(beta) * Mathf.Sin(alpha);
		return new Vector3(x, y, z);
	}

	public void CalculateAimPosition(Vector3 targetPos) {	
		AimPoint = new Vector3(targetPos.x, targetPos.y, targetPos.z) + AimError;
	}

	public void FireProjectile() {
		GetComponent<AudioSource>().Play();
		NextFireTime = ReloadTime;
		NextMoveTime = FirePauseTime;	
		AimError = CalculateAimError();

		Fire();
	}

	public void InstantiateProjectile(Transform muzzlePos) {
		GameObject projectile = Instantiate(Projectile, muzzlePos.position, muzzlePos.rotation) as GameObject;
		Projectile projectileScript = projectile.GetComponent<Projectile>();
		projectileScript.Target = Target;
		projectileScript.Aim = AimPoint;
		projectileScript.TowerType = TowerType;
		Instantiate(MuzzleEffect, muzzlePos.position, muzzlePos.rotation);
	}

	public virtual void Fire() {
		foreach(Transform muzzlePos in MuzzlePositions) {
			InstantiateProjectile(muzzlePos);
		}
	}

	public virtual void RotateTowardsTarget() {}

}
