using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float MoveSpeed;//Horizontal move speed
    public float JumpHeight;//Jump Height
    

    private float currentMoveSpeed;
    private Vector3 Inputs= Vector3.zero;
    private Rigidbody JKCRigidbody;
    private Animator JKCAnim;//Animator component attached to Junkochan
                             // Start is called before the first frame update
    FMOD.Studio.EventInstance BGM;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BossGate")
        {
           
            BGM.setParameterByName("Conditon", 0.5f);
        }

        if (other.tag == "VictoryGate")
        {
            Debug.Log("VictoryGate");
            BGM.setParameterByName("Conditon", 0.8f);
        }
    }

    void Start()
    {
        BGM = FMODUnity.RuntimeManager.CreateInstance("event:/BGM");
        BGM.start();
        JKCRigidbody = this.GetComponent<Rigidbody>();
        JKCAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        #region ACTION
        if (CheckGrounded() && Input.GetMouseButtonDown(0))
        {//When left clicked while Junkochan is on the ground
            JKCAnim.SetTrigger("Slash");//Play "Sword_Iai" animation in "ActionLayer" in Animator
        }
        if (CheckGrounded() && Input.GetMouseButton(1))
        {//When right clicked while Junkochan is on the ground
            JKCAnim.SetBool("Guard", true);//Play "Sword_Guard" animation in "ActionLayer" in Animator
        }
        else
        {//When the end of right click pressing 
            JKCAnim.SetBool("Guard", false);//End of "Sword_Guard" animation
        }

        if (JKCAnim.GetCurrentAnimatorStateInfo(1).IsName("Sword_Iai") || JKCAnim.GetCurrentAnimatorStateInfo(1).IsName("Sword_Guard") || JKCAnim.GetCurrentAnimatorStateInfo(1).IsName("Sword_Store"))
        {
            return;//While the attacking / guarding animation is playing, do not go to below "MOVEMENT" process  
        }
        #endregion

        #region MOVEMENT
        Inputs = Vector3.zero;
        Inputs.x = Input.GetAxis("Horizontal");//Get keyboard input
        Inputs.z = Input.GetAxis("Vertical");//Get keyboard input
        
        if (Inputs.magnitude > 0)
        {//When any WASD key is pushed
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Inputs), 0.2f);//Rotate Junkochan to Inputting direction
            currentMoveSpeed = MoveSpeed;
            JKCAnim.SetBool("Move", true);//Set Junkochan's "Move" parameter in Animator component
        }
        else
        {
            JKCAnim.SetBool("Move", false);
        }

        if (CheckGrounded())
        {//When Junkochan is on the ground
            JKCAnim.SetBool("Grounded", true);//Set Junkochan's "Grounded" parameter in Animator component
            JKCAnim.SetBool("Jump", false);
        }
        else
        {
            currentMoveSpeed *= 0.7f;
            JKCAnim.SetBool("Grounded", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {//When shift key is pushed
            currentMoveSpeed *= 2f;//Set Junkochan's moving speed as Running speed
            JKCAnim.SetBool("Run", true);//Set Junkochan's "Run" parameter in Animator component
        }
        else
        {
            JKCAnim.SetBool("Run", false);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {//When Control key is pushed
            currentMoveSpeed *= 0.5f;//Set Junkochan's moving speed as crouching walk speed
            JKCAnim.SetBool("Crouch", true);//Set Junkochan's "Crouch" parameter in Animator component
        }
        else
        {
            JKCAnim.SetBool("Crouch", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && CheckGrounded())
        {
            JKCRigidbody.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            JKCAnim.SetBool("Jump", true);
        }

        if (!CheckGrounded() && JKCRigidbody.velocity.y < 0)
        {//When Junkochan is falling, tansit animation state from "Ascending" to "Falling"
            JKCAnim.SetBool("Fall", true);//Set Junkochan's "Run" parameter in Animator component
        }
        else
        {
            JKCAnim.SetBool("Fall", false);
        }
        #endregion
    }
    void FixedUpdate()
    {
        Vector3 delta = JKCRigidbody.position + Inputs * currentMoveSpeed * Time.fixedDeltaTime;
        if (!float.IsNaN(delta.x) && !float.IsNaN(delta.y) && !float.IsNaN(delta.z))
            JKCRigidbody.MovePosition(delta);
    }
    bool CheckGrounded()
    {//Judge whether Junkochan is on the ground or not
        Ray ray = new Ray(this.transform.position + Vector3.up * 0.05f, Vector3.down * 0.1f);//Shoot ray at 0.05f upper from Junkochan's feet position to the ground with its length of 0.1f
        return Physics.Raycast(ray, 0.1f);//If the ray hit the ground, return true
    }
}
