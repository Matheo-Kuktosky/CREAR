using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CustomMonoBehaviour
{
    public GameObject interactionKey;
    private GameObject npcInRange;
    private SpriteRenderer interactionKeyRenderer;
    public Vector2 speed = new Vector2(2, 2);
    public Rigidbody2D rb;

    private void Start()
    {
        logPrefix = "Player >> ";
        npcInRange = new GameObject("null");
        interactionKeyRenderer = interactionKey.GetComponent<SpriteRenderer>();
        interactionKeyRenderer.enabled = false;
    }

    void handleMovement()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(0, 0);

        if (inputX != 0)
        {
            movement = new Vector2(speed.x * inputX, 0);
        }

        if (inputY != 0)
        {
            movement = new Vector2(0, speed.y * inputY);
        }

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

    void triggerInteractionKey(GameObject npc = null)
    {
        interactionKeyRenderer.enabled = (npc.name != "null");
        npcInRange = npc;
    }

    void handleInteraction()
    {
        if (interactionKeyRenderer.enabled == true &&
        Input.GetKeyDown(KeyCode.E) &&
        npcInRange.name != "null")
        {
            npcInRange.SendMessage("toggleDialog");
            consoleLog("handleInteraction", "passed");
        }

        /*if (npcInRange == null)
            consoleLog(nameof(npcInRange), "null");
        else
            consoleLog(nameof(npcInRange), npcInRange.name);*/

    }

    void Update()
    {
        handleMovement();
        handleInteraction();
    }

}
