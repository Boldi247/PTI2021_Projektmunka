using UnityEngine;
    
public class Chpoints : MonoBehaviour
{
    Vector3 spawnPoint;
    Vector3 carRBpos;
    public Rigidbody carRB;

    //setting back the rotation
    float x,y,z;
    Vector3 rotpos;
    private void Start() {
        spawnPoint = gameObject.transform.position;
        carRBpos = carRB.position;
        
        x = transform.eulerAngles.x;
        y = transform.eulerAngles.y;
        z = transform.eulerAngles.z;

        rotpos.x = x;
        rotpos.y = y;
        rotpos.z = z;
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "RoadBlock")
        {
            gameObject.transform.position = spawnPoint;
            carRB.velocity = Vector3.zero;
            gameObject.transform.eulerAngles = rotpos;
            gameObject.transform.position = carRBpos;
        }
    }
}