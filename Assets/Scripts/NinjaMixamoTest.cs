using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class NinjaMixamoTest : MonoBehaviour
{
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.numpad1Key.wasPressedThisFrame)
        {
            anim.SetBool("flyingKick", true);
            StartCoroutine(StopCurrentAnimationOnComplete("flyingKick"));
        }

        if (Keyboard.current.numpad2Key.wasPressedThisFrame)
        {
            anim.SetBool("butterflyTwirl", true);
            StartCoroutine(StopCurrentAnimationOnComplete("butterflyTwirl"));
        }
    }

    private IEnumerator StopCurrentAnimationOnComplete(string animName)
    {
        float animLength = anim.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(animLength);

        anim.SetBool(animName, false);
    }
}
