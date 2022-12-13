using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DetectGoal : MonoBehaviour {

    public AudioSource WinSound;
    private void OnTriggerEnter(Collider collision) {
        PlayerController player = collision.GetComponent<PlayerController>();
        WinSound.Play();
        if(player != null) {
            player.HitScore();
        }
    }
}
