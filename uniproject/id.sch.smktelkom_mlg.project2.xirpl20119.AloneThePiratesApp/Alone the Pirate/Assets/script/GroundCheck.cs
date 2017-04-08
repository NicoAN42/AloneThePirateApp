using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    private Player player;

    void Start()
    {
        player = gameObject.GetComponentInParent<Player>();

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        player.Grounded = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        player.Grounded = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        player.Grounded = false;
    }
}
