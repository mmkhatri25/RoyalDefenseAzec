using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
[AddComponentMenu("")]
public class jRigidbodyFPSController : MonoBehaviour
{
	public float speed = 10f;

	public float gravity = 10f;

	public float maxVelocityChange = 10f;

	public bool canJump = true;

	public float jumpHeight = 2f;

	public float rotationSensitivity = 15f;

	public jMobileJoystick leftJoystick;

	public jMobileJoystick rightJoystick;

	public Collider groundCollider;

	private bool grounded;

	private bool desktopPlatform;

	private float mass;

	private Vector3 gravityVector;

	private Vector3 targetVelocity;

	private void Start()
	{
		GetComponent<Rigidbody>().freezeRotation = true;
		GetComponent<Rigidbody>().useGravity = false;
		mass = GetComponent<Rigidbody>().mass;
		gravityVector = new Vector3(0f, (0f - gravity) * mass, 0f);
		targetVelocity = new Vector3(0f, 0f, 0f);
		desktopPlatform = (Application.platform != RuntimePlatform.IPhonePlayer && Application.platform != RuntimePlatform.Android);
	}

	private void FixedUpdate()
	{
		if (grounded)
		{
			if (desktopPlatform)
			{
				targetVelocity[0] = UnityEngine.Input.GetAxis("Horizontal");
				targetVelocity[1] = 0f;
				targetVelocity[2] = UnityEngine.Input.GetAxis("Vertical");
			}
			else
			{
				targetVelocity[0] = leftJoystick.position.x;
				targetVelocity[1] = 0f;
				targetVelocity[2] = leftJoystick.position.y;
			}
			targetVelocity = base.transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;
			Vector3 velocity = GetComponent<Rigidbody>().velocity;
			Vector3 force = targetVelocity - velocity;
			force.x = Mathf.Clamp(force.x, 0f - maxVelocityChange, maxVelocityChange);
			force.z = Mathf.Clamp(force.z, 0f - maxVelocityChange, maxVelocityChange);
			force.y = 0f;
			GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
			if (canJump && Input.GetButton("Jump"))
			{
				GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, Mathf.Sqrt(2f * jumpHeight * gravity), velocity.z);
			}
			if (desktopPlatform)
			{
				base.transform.Rotate(0f, UnityEngine.Input.GetAxis("Mouse X") * rotationSensitivity, 0f);
			}
			else
			{
				base.transform.Rotate(0f, rightJoystick.position.x * rotationSensitivity, 0f);
			}
		}
		GetComponent<Rigidbody>().AddForce(gravityVector, ForceMode.Force);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider == groundCollider)
		{
			grounded = true;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.collider == groundCollider)
		{
			grounded = false;
		}
	}
}
