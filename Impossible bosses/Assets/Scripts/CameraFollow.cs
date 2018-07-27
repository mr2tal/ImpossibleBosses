using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public bool ShowCursor = false;
    public GameObject player;
    public static readonly Plane plane = new Plane(Vector3.up, Vector3.zero);
    public float maxDistance;

    private Vector3 offset = new Vector3(0f, 10f, 0f);

    // Use this for initialization
    void Start() {
        //show cursor
        if (ShowCursor == false) {
            Cursor.visible = true;
        }

        //start position
        Camera.main.transform.position = player.transform.position + offset;

        //direction between target and start point
        Vector3 dir = player.transform.position - Camera.main.transform.position;

        RaycastHit hit;

        //testing if my ray collides with the player object
        if (Physics.Raycast(Camera.main.transform.position, dir, out hit)) {
            //print(hit.collider);
        }

        //making new angle for camera (face down)
        Vector3 newdir = Vector3.RotateTowards(transform.forward, dir, 360f + Time.deltaTime, 0.0f);

        Camera.main.transform.rotation = Quaternion.LookRotation(newdir);
    }

    // Update is called once per frame
    void Update() {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;

        //testing my ray
        //print(ray);

        //if the ray hits the plane, gives back distance to the plane
        if (plane.Raycast(ray, out distance)) {

            // making a vector 3 of the position i have hit
            Vector3 hit = ray.GetPoint(distance);

            //print(hit);  

            //x axis limitation
            if (player == null) {
                //   print("player dead");
            }
            else if (hit.x > player.transform.position.x + maxDistance) {
                hit.x = player.transform.position.x + maxDistance;
            }
            else if (hit.x < player.transform.position.x - maxDistance) {
                hit.x = player.transform.position.x - maxDistance;
            }

            //z axis limitation
            if (player == null) {
                //   print("player dead");
            }
            else if (hit.z > player.transform.position.z + maxDistance) {
                hit.z = player.transform.position.z + maxDistance;
            }
            else if (hit.z < player.transform.position.z - maxDistance) {
                hit.z = player.transform.position.z - maxDistance;
            }

            //transform camera position
            if (player != null) {
                transform.position = ((player.transform.position + hit) / 2) + offset;
            }
            
            //print(hit);
        }
        // test for my ray from mouse to plane (true if it hits)
        //print(plane.Raycast(ray, out distance));
    }
}
