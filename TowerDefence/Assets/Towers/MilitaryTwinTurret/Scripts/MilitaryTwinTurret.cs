using UnityEngine;

public class MilitaryTwinTurret : Tower {

	public Transform TurretBall;

	public override void RotateTowardsTarget() {
		TurretBall.forward = Vector3.Lerp(TurretBall.forward, AimPoint - TurretBall.transform.position, Time.deltaTime * TurnSpeed);
	}

}
