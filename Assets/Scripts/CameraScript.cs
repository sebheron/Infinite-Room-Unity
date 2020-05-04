/* The rotation script for the camera container.
 * Moves it around the origin, looking slightly towards the ground.
 */

using UnityEngine;

public class CameraScript : MonoBehaviour
{
    void LateUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, Time.deltaTime * 20);
        transform.LookAt(Vector3.down / 3f);
    }
}
