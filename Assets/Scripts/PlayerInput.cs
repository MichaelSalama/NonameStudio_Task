using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerInput
{
    public bool rightKeyDown, leftKeyDown, jumpKeyDown, jumpKeyUp, jumpKeyHeldDown;
    public float rightAxis, leftAxis;

    public void Set(PlayerInput input)
    {
        leftKeyDown = input.leftKeyDown;
        rightKeyDown = input.rightKeyDown;

        jumpKeyDown = input.jumpKeyDown;
        jumpKeyHeldDown = input.jumpKeyHeldDown;
        jumpKeyUp = input.jumpKeyUp;

        leftAxis = input.leftAxis;
        rightAxis = input.rightAxis;

    }

    public bool IsEqual(PlayerInput input)
    {
        return leftKeyDown == input.leftKeyDown &&
            rightKeyDown == input.rightKeyDown &&

            jumpKeyDown == input.jumpKeyDown &&
            jumpKeyHeldDown == input.jumpKeyHeldDown &&
            jumpKeyUp == input.jumpKeyUp &&

            leftAxis == input.leftAxis &&
            rightAxis == input.rightAxis;
    }

    public bool IsDirectionKeyDown()
    {
        return leftKeyDown || rightKeyDown || leftAxis != 0f || rightAxis != 0f;
    }

}
