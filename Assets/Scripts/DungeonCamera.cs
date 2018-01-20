using UnityEngine;
using System.Collections;

//public class ThirdPersonCam : MonoBehaviour
//{

//    public float speedH = 2.0f;
//    public float speedV = 2.0f;

//    private float yaw = 0.0f;
//    private float pitch = 0.0f;

//    void Update()
//    {
//        yaw += speedH * Input.GetAxis("Mouse X");
//        pitch -= speedV * Input.GetAxis("Mouse Y");

//        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
//    }
//}
public class DungeonCamera : MonoBehaviour
{
    public GameObject target;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}