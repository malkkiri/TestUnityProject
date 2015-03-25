using UnityEngine;

public class WayPoint : MonoBehaviour {
	
	const float GIZMO_RADIUS = 0.2f;
	
	void OnDrawGizmos() {
		Color oldColor = Gizmos.color;
		
		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere(transform.position, GIZMO_RADIUS);
		
		Gizmos.color = oldColor;
	}

}
