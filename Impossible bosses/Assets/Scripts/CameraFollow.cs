using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public bool ShowCursor = false;
    public GameObject player;
    public GameObject plane;
    public float cameraSpeed;
    public float maxDistance;


    private Vector3 offset = new Vector3(0f, 5f, 0f);

	// Use this for initialization
	void Start () {
        if (ShowCursor == false)
        {
            Cursor.visible = true;
        }
        

        Camera.main.transform.position = player.transform.position + offset;

        Vector3 dir = player.transform.position - Camera.main.transform.position;

        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, dir, out hit))
        {
            print(hit.collider);
        }

        Vector3 newdir = Vector3.RotateTowards(transform.forward, dir, 360f + Time.deltaTime, 0.0f);

        Camera.main.transform.rotation = Quaternion.LookRotation(newdir);


        
    }
	
	// Update is called once per frame
	void Update () {


        Plane plane = new Plane(Vector3.up, Vector3.zero);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float distance;

        print(ray);

        if (plane.Raycast(ray, out distance)) {

            Vector3 hit = ray.GetPoint(distance);

            print(hit);  

            //x axis limitation
            if (!player)
            {
                print("player dead");
            }else if (hit.x > player.transform.position.x + maxDistance)
            {
                hit.x = player.transform.position.x + maxDistance;
            }else if (hit.x < player.transform.position.x - maxDistance)
            {
                hit.x = player.transform.position.x - maxDistance;
            }

            //z axis limitation
            if (!player)
            {
                print("player dead");
            }else if (hit.z > player.transform.position.z + maxDistance)
                {
                    hit.z = player.transform.position.z + maxDistance;
                }
                if (hit.z < player.transform.position.z - maxDistance)
                {
                    hit.z = player.transform.position.z - maxDistance;
                }
            

            transform.position = ((Time.deltaTime + cameraSpeed) * hit) + offset;

        }

        print(plane.Raycast(ray, out distance));


    }
}
