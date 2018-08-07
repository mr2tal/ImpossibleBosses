using UnityEngine;
using System.Linq;
using System.Collections.Generic;

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
        public static IEnumerable<GameObject> getTagsInRadius(string tag, Vector3 center, float radius) {
            return GameObject.FindGameObjectsWithTag(tag)
                .Where(x => Vector3.Distance(x.transform.position, center) <= radius);
        }

        public static IEnumerable<GameObject> getTagsInCone(string tag, Vector3 center, Vector3 direction, float radius, float angle) {
            return getTagsInRadius(tag, center, radius)
                .Where(x => Vector3.Angle((x.transform.position - center), direction) <= angle);
        }
    }
}