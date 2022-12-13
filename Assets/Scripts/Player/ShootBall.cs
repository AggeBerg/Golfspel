using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class ShootBall : MonoBehaviour {

    [SerializeField] private PlayerController playerController;
    [SerializeField] private CinemachineVirtualCamera cameraTransform;
    [SerializeField] private GameObject shootUI;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float dragModifier;
    [SerializeField] private float ballSpeed;
    [SerializeField] private float ballDrag;

    public AudioSource PuttSound;

    Vector3 mouseStartPos = new();
    private bool startedShoot = false;
    [NonSerialized] public float charge = 0.0f;
    [NonSerialized] public int amountOfShoots = 0;

    [SerializeField] private GameObject CurrentScoreObject;
     private TextMeshProUGUI CurrentScoreText;
    

    private void Start() {
        rb.angularDrag = ballDrag;
        CurrentScoreText = CurrentScoreObject.GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        if(!playerController.isShooting) {
            shootUI.SetActive(false);
            return;
        }
        shootUI.SetActive(true);

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            mouseStartPos = Input.mousePosition;
            startedShoot = true;
        }
        if(!startedShoot) return;

        // man kanske kan l�gga till skruvning ifall man flyttar musen �t sidan
        Vector3 mouseReleasePos = Input.mousePosition; 
        charge = Mathf.Min(100f, dragModifier*Mathf.Max(0f, mouseStartPos.y-mouseReleasePos.y));
        if(Input.GetKeyUp(KeyCode.Mouse0)) {
            rb.velocity = cameraTransform.transform.forward * ballSpeed * charge/100; 
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // just nu anv�nds inte y v�rdet man skulle kunna �ndra den
            if(charge == 0f) {
                charge = 0f;
                return;
            }
            else
            {
                PuttSound.Play();
            };
            charge = 0f;
            amountOfShoots++;
            CurrentScoreText.text = amountOfShoots.ToString();

            playerController.isShooting = false;
            startedShoot = false;
        }
    }

}
