using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DetectGoal : MonoBehaviour {
    private void OnTriggerEnter(Collider collision) {
        PlayerController player = collision.GetComponent<PlayerController>();
        if(player != null) {
            player.HitScore();
        }
    }
}
