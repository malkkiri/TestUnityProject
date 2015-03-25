using UnityEngine;

public class MilitaryRocketLauncher : Tower {

	public Transform RotorY;
	public Transform RotorX;

	int firePos;

	void OnMouseDown(){
		Debug.Log ("OnMouseDown");
	}

	public override void Fire() {
		firePos++;
		firePos %= MuzzlePositions.Length;
		InstantiateProjectile(MuzzlePositions[firePos]);
	}

	public override void RotateTowardsTarget() {
		Vector3 diffY = AimPoint - RotorY.transform.position;
		RotorY.forward = Vector3.Lerp(RotorY.forward, new Vector3(diffY.x, 0, diffY.z), Time.deltaTime * TurnSpeed);
		RotorX.LookAt(AimPoint);
	}
}
