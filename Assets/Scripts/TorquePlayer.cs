using UnityEngine;

public class TorquePlayer : MonoBehaviour
{
	Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		var myAngle = transform.eulerAngles.z;
		var myNextAngle = myAngle + rb.angularVelocity * Time.deltaTime * 10;

		var dirToMouse = (mousePos - transform.position).normalized;
		var angleToMouse = Vector2.SignedAngle( transform.right,dirToMouse);

		var a = Mathf.DeltaAngle(myNextAngle, angleToMouse);

		var torque = 10 * Mathf.InverseLerp( 90,0,a) * Mathf.Sign(a);
		rb.AddTorque(torque);


		print( rb.inertia);
	}
}