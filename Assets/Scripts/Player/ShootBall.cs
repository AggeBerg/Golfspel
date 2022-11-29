using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ShootBall : MonoBehaviour {

    [SerializeField] private PlayerController playerController;
    [SerializeField] private CinemachineVirtualCamera cameraTransform;
    [SerializeField] private GameObject shootUI;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float dragModifier;
    [SerializeField] private float ballSpeed;
    [SerializeField] private float ballDrag;

    Vector3 mouseStartPos = new();
    private bool startedShoot = false;
    public float charge = 0.0f;

    private void Start() {
        rb.angularDrag = ballDrag;
    }

    private void Update() {
        if(!playerController.isShooting) {
            shootUI.SetActive(false);
            return;
        }
        shootUI.SetActive(true);

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            // Debug.Log("start");
            mouseStartPos = Input.mousePosition;
            startedShoot = true;
        }
        if(!startedShoot) return;

        // man kanske kan l�gga till skruvning ifall man flyttar musen �t sidan
        Vector3 mouseReleasePos = Input.mousePosition; 
        charge = Mathf.Min(100f, dragModifier*Mathf.Max(0f, mouseStartPos.y-mouseReleasePos.y));
        // Debug.Log(charge);
        if(Input.GetKeyUp(KeyCode.Mouse0)) {
            // Debug.Log("release");
            rb.velocity = cameraTransform.transform.forward * ballSpeed * charge/100; 
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // just nu anv�nds inte y v�rdet man skulle kunna �ndra den
            charge = 0f;
            // playerController.isShooting = false;
            startedShoot = false;
        }
    }

}
