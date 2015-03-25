using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour {

	public float Speed = 10f;
	public float Damage = 10f;
	public float Splash = 0f;
	public float SplashReduce = 0.5f;
	[Range(0, 100)]
	public int CriticalChance = 0;
	public GameObject Explosion;
	[HideInInspector]
	public Transform Target;
	[HideInInspector]
	public Type TowerType;
	[HideInInspector]
	public Vector3 Aim;

	// Use this for initialization
	void Start() {
	
	}
	
	// Update is called once per frame
	void Update() {
	
	}

	void OnTriggerEnter(Collider other) {
		GameObject otherGO = other.gameObject;
		if(canDamage(otherGO)) {
			Explode();
			int critical = Random.Range(0, 100);
			if(critical < CriticalChance) {
				Critical(otherGO);
			}
			if(Splash > 0) {
				SplashDamage();
			} else {
				DoDamage(otherGO, Damage);
			}
		} else if(other.gameObject.tag == "Obstacle") {
			Explode();
			if(Splash > 0) {
				SplashDamage();
			}
		}
	}

	public virtual void Critical(GameObject other) {
		other.SendMessage("Critical", SendMessageOptions.DontRequireReceiver);
	}

	public virtual void DoDamage(GameObject other, float damage) {
		other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
	}

	public virtual void SplashDamage() {
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, Splash);
		foreach(Collider hit in hitColliders) {
			GameObject hitGO = hit.gameObject;
			if(canDamage(hitGO)) {
				float dist = Vector3.Distance(transform.position, hit.transform.position);
				DoDamage(hitGO, Damage * (Splash - dist * SplashReduce) / Splash);
			}
		}
	}

	public virtual void Explode() {
		Instantiate(Explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

	bool canDamage(GameObject go) {
		return go.tag == TowerType + " Enemy" || (TowerType == Type.Both && go.tag.EndsWith("Enemy"));
	}

}
