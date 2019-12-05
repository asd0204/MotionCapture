using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;

    public float speedMove = 10.5f;
    public float speedTurn = 10.5f;

    private void Update()
    {
        Track();
    }

    private void Track()
    {
        transform.position = Vector3.Slerp(transform.position, target.position, 0.1f * Time.deltaTime * speedMove);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, 0.1f * Time.deltaTime * speedTurn);
    }
}
