using UnityEngine;

public class Explosion : MonoBehaviour
{
	public float blastRadius = 5;
	public float blastForce = 10;
	public int rayCount = 10;
	public GameObject explosionPrefab;
	AudioClip explosionSound;

	void Update()
	{
		 if(Input.GetMouseButtonDown( 0 ))
		 {
			 var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			 pos.z = 0;
			 transform.position = pos;

			 //Explode();
			 ExplodeRays( pos, blastRadius,rayCount);
			 var obj = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			 Destroy( obj, 0.1f);
		 }
	}

	void Explode()
	{
		print("Explode");
		var min = transform.position - new Vector3(5, 5);
		var max = transform.position + new Vector3(5, 5);
		var bodies = Physics2D.OverlapCircleAll( transform.position, blastRadius);
		foreach (var body in bodies)
		{
			var rb = body.GetComponent<Rigidbody2D>();
			if (rb)
			{
				ApplyBlastImpulse(rb, transform.position, blastRadius, blastForce);
			}
		}
	}

	void ExplodeRays(Vector3 pos, float range, int count)
	{
		var angleStep = 360 / count;
		for (int i = 0; i < count; i++)
		{
			var angle = i * angleStep;
			var dir = Quaternion.Euler( 0,0,angle) * Vector3.right;
			var hit = Physics2D.Raycast(pos, dir, range);
			if (hit)
			{
				Debug.DrawLine(pos, hit.point, Color.red, 1);
				var rb = hit.collider.GetComponent<Rigidbody2D>();
				if (rb)
				{
					var p = hit.point;
					ApplyBlastImpulse(rb, p, range, blastForce);
				}
			}
		}
	}

	void ApplyBlastImpulse(Rigidbody2D body, Vector3 blastPoint,float radius,  float f)
	{
		var dir = (body.transform.position - blastPoint);
		var distance = dir.magnitude;
		if (distance == 0) return;

		var percentage =  Mathf.InverseLerp(radius, 0, distance);
		percentage = Mathf.Pow(percentage, 2);

		var force = percentage * f * dir.normalized;
		body.AddForceAtPosition(force, blastPoint, ForceMode2D.Impulse);
		// get torque based on blast position;
		var torque = Vector3.Cross(dir, force);
		body.AddTorque(100 * Mathf.Deg2Rad * body.inertia, ForceMode2D.Impulse);
	}
}