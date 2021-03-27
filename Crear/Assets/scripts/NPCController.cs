using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public BoxCollider2D trigger;
    // ---------- Dialog properties 
    public GameObject dialogObject;
    private Animator dialogAnimator;
    private SpriteRenderer dialogRenderer;
    private float dialogDisappearTimer = 0.3f;
    private bool dialogTriggered = false;
    private bool dialogSubTrigger = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            other.gameObject.SendMessage("triggerInteractionKey", this.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            GameObject nullObj = new GameObject();
            nullObj.name = "null";
            other.gameObject.SendMessage("triggerInteractionKey", nullObj);
            Destroy(nullObj);
        }
    }
    private void disable()
    {
        if (dialogDisappearTimer > 0f)
            dialogDisappearTimer -= Time.deltaTime;
        else
        {
            dialogDisappearTimer = 0.3f;
            dialogRenderer.enabled = dialogAnimator.enabled
                = dialogSubTrigger = dialogTriggered = false;
            dialogAnimator.SetBool("isFinished", false);
            dialogAnimator.SetBool("isVisible", false);
        }
    }

    private void toggleDialog()
    {
        if (!dialogRenderer.enabled ||
            !dialogAnimator.enabled)
        {
            dialogRenderer.enabled = true;
            dialogAnimator.enabled = true;
            dialogAnimator.Play("dialogFadein_anim");
        }

        if (!dialogAnimator.enabled)
            dialogAnimator.enabled = true;

        if (dialogTriggered)
        {
            dialogAnimator.SetBool("isFinished", true);
            dialogSubTrigger = true;
        }

        if (dialogRenderer.enabled)
        {
            dialogAnimator.SetBool("isVisible", dialogTriggered = true);
        }

    }

    private void Update()
    {
        if (dialogSubTrigger)
            disable();
    }

    private void Start()
    {
        dialogRenderer = dialogObject.GetComponent<SpriteRenderer>();
        dialogAnimator = dialogObject.GetComponent<Animator>();
        dialogRenderer.enabled = dialogAnimator.enabled = false;
    }
}
