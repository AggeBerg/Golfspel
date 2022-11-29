using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour{

    [SerializeField] private float playerSpeed;
    [SerializeField] private float ShootRotateSpeed;
    [SerializeField] private GameObject ShootingCam;
    [SerializeField] private Rigidbody rb;

    private bool isShooting = true;
    private void Update() {
        if(isShooting) ShootUpdate();

        // rb.velocity = new Vector3(Input.GetAxis("Horizontal")*playerSpeed, rb.velocity.y, Input.GetAxis("Vertical")*playerSpeed);
    }

    private void ShootUpdate() {
        ShootingCam.transform.RotateAround(transform.position, new Vector3(0, 1, 0), Input.GetAxis("Horizontal")* ShootRotateSpeed * Time.deltaTime);

    }

}
