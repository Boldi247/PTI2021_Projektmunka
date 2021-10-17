using System;
using UnityEngine;
    
public class CheckpointManager : MonoBehaviour
{
    public Transform CHPoint;
    public Rigidbody Car;
    Vector3 CHPoint_position;
    Vector3 CHPoint_rotation;

    public ControlCar movement;
    public CameraFollow cameraSet; //kamera hatrebbtolasa

    private void Start() {        
        movement.enabled = true; /*kezdesnel mindenkepp fusson a mozgato script*/
        
        CHPoint_position = gameObject.transform.position;
        
        float xrot = transform.eulerAngles.x;
        float yrot = transform.eulerAngles.y;
        float zrot = transform.eulerAngles.z;

        CHPoint_rotation.x = xrot;
        CHPoint_rotation.y = yrot;
        CHPoint_rotation.z = zrot;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "RoadBlock"){
            PlaceOnCheckpoint();
        }
        if (other.gameObject.tag == "CheckPoint"){
            RegisterCheckPoint();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "CollidableObject"){
            CollidingWithObjects();
        }
    }

    private void CollidingWithObjects()
    {
        /*...mozgato script kikapcsolasa
        kamera hatrebb es felulrebb tolasa
        slowmo...*/
        movement.enabled = false;

        cameraSet.ZoomOut();

        Invoke("PlaceOnCheckpoint", 2.0f);
    }

    private void RegisterCheckPoint()
    {
        CHPoint_position = gameObject.transform.position;
        
        float xrot = transform.eulerAngles.x;
        float yrot = transform.eulerAngles.y;
        float zrot = transform.eulerAngles.z;

        CHPoint_rotation.x = xrot;
        CHPoint_rotation.y = yrot;
        CHPoint_rotation.z = zrot;
    }

    public void PlaceOnCheckpoint() /*public az invoke miatt*/
    {
        cameraSet.ZoomIn();

        if (movement.enabled == false) movement.enabled = true;

        Car.velocity = Vector3.zero;
        gameObject.transform.position = CHPoint_position;
        gameObject.transform.eulerAngles = CHPoint_rotation;
        gameObject.transform.position = CHPoint_position; //csak hogy ne pattanjon fel az autó
    }
}