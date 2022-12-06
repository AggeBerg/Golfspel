using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Pair<T, U> {
    public Pair() {
    }

    public Pair(T first, U second) {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
};

public class PlayerController : MonoBehaviour{

    [SerializeField] private float playerSpeed;
    [SerializeField] private float decelerate_p;
    [SerializeField] private float ShootRotateSpeed;
    [SerializeField] private float camAutoRotateSpeed;
    [SerializeField] private GameObject ShootingCam;
    [SerializeField] private Transform camOffsetTransform;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject GoalMenuObject;

    [SerializeField] private float cameraDelay;
    private Queue<Pair<Vector3, float>> positionHistory = new();
    private bool lastStill = false;
    public bool isShooting = false;

    [NonSerialized] private bool inGoal = false;
    [SerializeField] private LayerMask obstacle;

    private void Update() {
        if(inGoal) return;
        // Debug.Log(Mathf.Sqrt(Mathf.Pow(rb.velocity.x, 2)+ Mathf.Pow(rb.velocity.z, 2)));
        isShooting = (0.6f > rb.velocity.magnitude && lastStill);
        lastStill = (0.6f > rb.velocity.magnitude);
        CameraUpdate();

        if(isShooting) ShootUpdate();
        else rb.velocity = new Vector3(rb.velocity.x- rb.velocity.x*decelerate_p*Time.deltaTime, rb.velocity.y, rb.velocity.z - rb.velocity.z * decelerate_p * Time.deltaTime);
        // rb.velocity = new Vector3(Input.GetAxis("Horizontal")*playerSpeed, rb.velocity.y, Input.GetAxis("Vertical")*playerSpeed);
    }


    private void ShootUpdate() {
        rb.velocity = new Vector3(0f, rb.velocity.y, 0f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        // rb.velocity = Vector3.zero;
        ShootingCam.transform.RotateAround(transform.position, new Vector3(0, 1, 0), Input.GetAxis("Horizontal")* ShootRotateSpeed * Time.deltaTime);
    }
    private void CameraUpdate() {
        //positionHistory.Enqueue(new Pair<Vector3, float>(transform.position, Time.time));
        //while(positionHistory.Count > 1 && (positionHistory.Peek().Second + cameraDelay < Time.time)) {
        //    positionHistory.Dequeue();
        //}

        Vector3 look = transform.position - ShootingCam.transform.position;
        float angle = Mathf.Atan2(look.z, look.x) * Mathf.Rad2Deg;
        float angle2 = Mathf.Atan2(rb.velocity.z, rb.velocity.x) * Mathf.Rad2Deg;
        //Debug.Log(angle-angle2);

        // Debug.Log(Time.time-positionHistory.Peek().Second);
        camOffsetTransform.position = transform.position;
        if(isShooting) camOffsetTransform.position = transform.position;
        else {
            // camOffsetTransform.position = Vector3.Lerp(camOffsetTransform.position, positionHistory.Peek().First, 1f);

            ShootingCam.transform.RotateAround(transform.position, new Vector3(0, 1, 0), Mathf.Lerp(0f, angle - angle2, camAutoRotateSpeed * Time.deltaTime) * Mathf.Pow(rb.velocity.magnitude, 0.8f));
        }

        Vector3 dir = (ShootingCam.transform.position - transform.position).normalized;
        Vector4 vec = ShootingCam.transform.position - transform.position;
        Debug.DrawRay(transform.position, dir*vec.magnitude, Color.green);
        Vector3 dirLower = new Vector3(dir.x, dir.y-0.15f, dir.z);
        Debug.DrawRay(transform.position, dirLower*vec.magnitude, Color.red);
        Debug.DrawRay(transform.position, dir*vec.magnitude, Color.green);
        if(Physics.Raycast(transform.position, dir, vec.magnitude, obstacle)) {
            ShootingCam.transform.RotateAround(transform.position, new Vector3(1, 0, 1), Time.deltaTime * 40f);
            return;
            //Debug.Log("Blocked");
        }
        Debug.Log(ShootingCam.transform.position.y - transform.position.y);
        if(!Physics.Raycast(transform.position, dirLower, vec.magnitude, obstacle) && ShootingCam.transform.position.y-transform.position.y > 0.6f) {
            Debug.Log("Ner");
            ShootingCam.transform.RotateAround(transform.position, new Vector3(1, 0, 1), Time.deltaTime * -40f);
            //Debug.Log("Blocked");
        }
        //else Debug.Log("Free");
    }

    public void HitScore() {
        inGoal = true; 
        GoalMenuObject.SetActive(true);
    }

}
