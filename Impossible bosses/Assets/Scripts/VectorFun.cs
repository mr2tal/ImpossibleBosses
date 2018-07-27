using UnityEngine;

namespace Utilities {
    public static class VectorFun {
        public static readonly Plane plane = new Plane(Vector3.up, Vector3.zero);

        public static Vector3 GetMouseCoordinatesOnPlane() {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;
            if (plane.Raycast(ray, out distance)) {
                return ray.GetPoint(distance);
            }
            else {
                // happens if mouse doesn't hit the plane anywhere, ie. the 
                // camera is somewhere (or at some angle) where it should not be.
                return Vector3.zero;
            }
        }
    }
}