using UnityEngine;
using System.Collections;

public class car_controller : MonoBehaviour {

	private float horizontalInput;
	private float verticalInput;
	private float steeringAngle;

	public WheelCollider frontLeftWheel, frontRightWheel;
	public WheelCollider rearLeftWheel, rearRightWheel;
	public Transform frontLeftTransform, frontRightTransform;
	public Transform rearLeftTransform, rearRightTransform;

	public float maxSteerAngle = 35;
	public float motorForce = 55;


	public void GetInput()
	{
		horizontalInput = Input.GetAxis("Horizontal");
		verticalInput = Input.GetAxis("Vertical");
	}

	public void Steer()
	{
		steeringAngle = maxSteerAngle * horizontalInput;
		frontLeftWheel.steerAngle = steeringAngle;
		frontRightWheel.steerAngle = steeringAngle;
	}

	public void Accelerate()
	{
		frontLeftWheel.motorTorque = verticalInput * motorForce;
		frontRightWheel.motorTorque = verticalInput * motorForce;
	}

	public void UpdateWheelPoses()
	{
		UpdateWheelPose(frontLeftWheel, frontLeftTransform);
		UpdateWheelPose(frontRightWheel, frontRightTransform);
		UpdateWheelPose(rearLeftWheel, rearLeftTransform);
		UpdateWheelPose(rearRightWheel, rearRightTransform);
	}

	public void UpdateWheelPose(WheelCollider collider, Transform transform)
	{
		Vector3 pos = transform.position;
		Quaternion quat = transform.rotation;

		collider.GetWorldPose(out pos, out quat);

		transform.position = pos;
		transform.rotation = quat;
	}

	public void FixedUpdate()
	{
		GetInput();
		Steer();
		Accelerate();
		UpdateWheelPoses();
	}



}
