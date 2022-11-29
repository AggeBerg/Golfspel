using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ShootBall : MonoBehaviour {
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float dragModifier;

    Vector3 mouseStartPos = new();
    private bool startedShoot = false;
    public float charge = 0.0f;

    private void Update() {
        if(!playerController.isShooting) return;

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            // Debug.Log("start");
            mouseStartPos = Input.mousePosition;
            startedShoot = true;
        }
        if(!startedShoot) return;

        // man kanske kan lägga till skruvning ifall man flyttar musen åt sidan
        Vector3 mouseReleasePos = Input.mousePosition; 
        charge = Mathf.Min(100f, dragModifier*Mathf.Max(0f, mouseStartPos.y-mouseReleasePos.y));
        Debug.Log(charge);
        if(Input.GetKeyUp(KeyCode.Mouse0)) {
            // Debug.Log("release");
            // playerController.isShooting = false;
            startedShoot = false;
        }
    }

}
