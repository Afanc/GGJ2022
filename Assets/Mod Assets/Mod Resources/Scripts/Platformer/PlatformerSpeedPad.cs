using System.Collections;
using UnityEngine;
using Platformer.Mechanics;

public class PlatformerSpeedPad : MonoBehaviour
{
    public float maxSpeed;

    [Range (0, 5)]
    public float duration = 1f;

    void OnTriggerEnter2D(Collider2D other){
        var rb = other.attachedRigidbody;
        if (rb == null) return;
        var player = rb.GetComponent<PlayerController>();
        if (player == null) return;
        player.StartCoroutine(PlayerModifier(player, duration));
    }

    IEnumerator PlayerModifier(PlayerController player, float lifetime){
        var initialSpeed1 = player.maxSpeed1;
        var initialSpeed2 = player.maxSpeed2;
        player.maxSpeed1 = maxSpeed;
        player.maxSpeed2 = maxSpeed;
        yield return new WaitForSeconds(lifetime);
        player.maxSpeed1 = initialSpeed1;
        player.maxSpeed2 = initialSpeed2;
    }

}
