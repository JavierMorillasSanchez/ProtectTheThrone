using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //Este es el script para que la camara siga al personaje

    public Transform target;

    public float smoothSpeed = 0.125F;

    public Vector3 offSet;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

}
