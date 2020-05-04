/* Credits to amirebrahimi on the Unity Forums for this script.
 * This script will only make it so only part of the camera is rendered.
 */

using UnityEngine;

public class Scissor : MonoBehaviour
{
    public Rect ScissorRect = new Rect(0, 0, 1, 1);

    public static void SetScissorRect(Camera cam, Rect r) {
        if (r.x < 0) {
            r.width += r.x;
            r.x = 0;
        }
        if (r.y < 0) {
            r.height += r.y;
            r.y = 0;
        }
        r.width = Mathf.Min(1 - r.x, r.width);
        r.height = Mathf.Min(1 - r.y, r.height);
        cam.rect = new Rect(0, 0, 1, 1);
        cam.ResetProjectionMatrix();
        Matrix4x4 m = cam.projectionMatrix;
        cam.rect = r;
        Matrix4x4 m1 = Matrix4x4.TRS(new Vector3(r.x, r.y, 0), Quaternion.identity, new Vector3(r.width, r.height, 1));
        Matrix4x4 m2 = Matrix4x4.TRS(new Vector3((1 / r.width - 1), (1 / r.height - 1), 0), Quaternion.identity, new Vector3(1 / r.width, 1 / r.height, 1));
        Matrix4x4 m3 = Matrix4x4.TRS(new Vector3(-r.x * 2 / r.width, -r.y * 2 / r.height, 0), Quaternion.identity, Vector3.one);
        cam.projectionMatrix = m3 * m2 * m;	
    }

    void OnPreRender() {
        SetScissorRect(GetComponent<Camera>(), ScissorRect);
    }
}
