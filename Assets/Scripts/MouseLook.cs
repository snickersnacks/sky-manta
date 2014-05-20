using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLook : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 1f;
    public float sensitivityY = 1f;
    public float sensitivityZ = 1f;

	float magic = 20f;

	void Update ()
	{
        print(Input.GetAxis("SideToSide"));
        float rotationZ = Input.GetAxis("SideToSide") * sensitivityZ * Time.deltaTime;
    	float rotationX = Input.GetAxis("Horizontal") * sensitivityX * Time.deltaTime;
        float rotationY = Input.GetAxis("Vertical") * sensitivityY * Time.deltaTime;
        Vector3 rot = new Vector3(-rotationY, rotationZ, rotationX);

        transform.Rotate(rot, Space.Self);
        //transform.eulerAngles += new Vector3(-rotationY, 0, rotationX);
        //transform.localEulerAngles += rot;
	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
}