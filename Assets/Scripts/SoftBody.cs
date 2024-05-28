using UnityEngine;
using UnityEngine.U2D;

public class SoftBody : MonoBehaviour
{
	public Transform[] points;
	SpriteShapeController spriteShapeController;

	void Start() => Init();

	void Update()
	{
		// update sprite shape
		// get center of bounding box
		var center = Vector3.zero;

		foreach (var point in points)
		{
			center += point.position;
		}

		center /= points.Length;


		var spline = spriteShapeController.spline;
		for (int i = 0; i < points.Length; i++)
		{
			var worldPos = points[i].position - transform.position;
			var normal = (worldPos - center).normalized;
			spline.SetPosition(i, worldPos + normal * 0.5f);

			// update tangents 2d

			var last = points[(i - 1 + points.Length) % points.Length].position - transform.position;
			var next = points[(i + 1) % points.Length].position - transform.position;

			var tangent = (next - last) / 2;
			tangent.Normalize();

			spline.SetLeftTangent( i , -tangent);
			spline.SetRightTangent( i , tangent);
		}
	}

	void Init()
	{
		points = transform.GetComponentsInChildren<Transform>()[1..];

		// connect neighbours with springs
		for (int i = 0; i < points.Length; i++)
		{
			var next = points[(i + 1) % points.Length];

			var hinge = points[i].gameObject.AddComponent<HingeJoint2D>();

			hinge.connectedBody = next.GetComponent<Rigidbody2D>();
			hinge.limits = new JointAngleLimits2D { min = -10, max = 10 };

		}

		// add points to sprite shape
		spriteShapeController = GetComponent<SpriteShapeController>();
		var spline = spriteShapeController.spline;
		spline.Clear();
		for (int i = 0; i < points.Length; i++)
		{
			spline.InsertPointAt(i, points[i].position);
			// point tangents
			spline.SetTangentMode(i, ShapeTangentMode.Continuous);
		}
	}
}