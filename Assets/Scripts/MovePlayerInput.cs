using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayerInput : MonoBehaviour
{
    public PlayerInput input;

    public virtual void Update()
    {
        input = GetInputs();
    }

    public PlayerInput GetInputs()
    {
        MovementInputAxis("Left", ref this.input.leftKeyDown);
        MovementInputAxis("Right", ref this.input.rightKeyDown);

        if (Input.GetButtonDown("Jump")) input.jumpKeyDown = true;
        else input.jumpKeyDown = false;

        if (Input.GetButton("Jump")) input.jumpKeyHeldDown = true;
        else input.jumpKeyHeldDown = false;

        if (Input.GetButtonUp("Jump")) input.jumpKeyUp = true;
        else input.jumpKeyUp = false;

        this.input.leftAxis = GetAxis("Left");
        this.input.rightAxis = GetAxis("Right");

        return input;
    }

    protected void MovementInputAxis(string axisName, ref bool isKeyDown)
    {
        if (Input.GetButtonDown(axisName))
            isKeyDown = true;

        if (Input.GetButton(axisName))
            isKeyDown = true;

        if (Input.GetButtonUp(axisName))
            isKeyDown = false;
    }

    public float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }

    //public void OnPause(bool state)
    //{
    //    if (state)
    //    {
    //        enabled = false;
    //        input.leftKeyDown = false;
    //        input.rightKeyDown = false;
    //        input.jumpKeyDown = false;
    //        input.jumpKeyHeldDown = false;
    //        input.jumpKeyUp = true;
    //        this.input.leftAxis = 0;
    //        this.input.rightAxis = 0;
    //        Input.ResetInputAxes();
    //    }
    //    else enabled = true;
    //}
}
