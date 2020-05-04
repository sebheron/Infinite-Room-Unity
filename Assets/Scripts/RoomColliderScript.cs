using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script just changes the layer based on its state.
 * And modifies the rotation as necessary.
 */

public class RoomColliderScript : MonoBehaviour
{
    public int MaxRotations;

    private void OnTriggerEnter(Collider other) {
        RotationsBeforeShowing rotations = other.GetComponent<RotationsBeforeShowing>();
        if (rotations.Rotations > 0) {
            rotations.Rotations--;
        } else if (other.gameObject.layer == LayerMask.NameToLayer("NoSides")) {
            other.gameObject.layer = LayerMask.NameToLayer("LeftSide");
        } else if (other.gameObject.layer == LayerMask.NameToLayer("BothSides")) {
            other.gameObject.layer = LayerMask.NameToLayer("RightSide");
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("RightSide")) {
            other.gameObject.layer = LayerMask.NameToLayer("NoSides");
            other.GetComponent<RotationsBeforeShowing>().Rotations = MaxRotations;
        } else if (other.gameObject.layer == LayerMask.NameToLayer("LeftSide")) {
            other.gameObject.layer = LayerMask.NameToLayer("BothSides");
        }
    }
}
