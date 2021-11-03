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
    public GameObject CompleteLevelUI;
    public GameObject StartupFade;

    private bool isCollided;

    private void Start() {
        FadeAnimation();

        ControlCar.cc.movementEnabled = true; /*kezdesnel mindenkepp fusson a mozgato script*/

        CHPoint_position = gameObject.transform.position;
        
        float xrot = transform.eulerAngles.x;
        float yrot = transform.eulerAngles.y;
        float zrot = transform.eulerAngles.z;

        CHPoint_rotation.x = xrot;
        CHPoint_rotation.y = yrot;
        CHPoint_rotation.z = zrot;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.R) && !isCollided)
        {
            CollidingWithObjects();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "RoadBlock"){
            PlaceOnCheckpoint();
        }
        if (other.gameObject.tag == "CheckPoint"){
            RegisterCheckPoint();
        }
        if (other.gameObject.tag == "End"){
            CompleteLevel();
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "CollidableObject" && !isCollided){
            CollidingWithObjects();
        }
        FindObjectOfType<AudioManager>().Play("Crash");
    }

    private void CollidingWithObjects()
    {
        isCollided = true;

        ControlCar.cc.movementEnabled = false;

        cameraSet.ZoomOut();

        Invoke("PlaceOnCheckpoint", 2.0f);
    }

    private void FadeAnimation(){
        StartupFade.SetActive(true);
    }

    private void CompleteLevel(){
        CompleteLevelUI.SetActive(true);
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
        isCollided = false;

        cameraSet.ZoomIn();

        if (!ControlCar.cc.movementEnabled) ControlCar.cc.movementEnabled = true;

        Car.velocity = Vector3.zero;
        gameObject.transform.position = CHPoint_position;
        gameObject.transform.eulerAngles = CHPoint_rotation;
        gameObject.transform.position = CHPoint_position; //csak hogy ne pattanjon fel az autó
    }
}