using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSpringJoint : MonoBehaviour
{
	// on mouse down create a spring joint with collider on mouse position
	SpringJoint2D spring;
	Camera _camera;
	LineRenderer line;

	void Start()
	{
		_camera = Camera.main;
		spring = GetComponent<SpringJoint2D>();
		line = GetComponent<LineRenderer>();
	}


	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
			var hit = Physics2D.OverlapPoint(mousePos);

			if (hit)
			{
				var rb = hit.GetComponent<Rigidbody2D>();
				if (rb)
				{
					spring.connectedBody = rb;
					spring.connectedAnchor = rb.transform.InverseTransformPoint(mousePos);
				}
			}
		}

		if (spring.connectedBody)
		{
			line.SetPosition(0, transform.position);
			line.SetPosition(1, spring.connectedBody.transform.TransformPoint(spring.connectedAnchor));
			var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
			spring.distance = 2;
			transform.position = mousePos;
		}

		if (Input.GetMouseButtonUp(0))
		{
			spring.connectedBody = null;
		}
	}
}