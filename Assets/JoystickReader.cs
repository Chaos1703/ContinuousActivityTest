using UnityEngine;
using System;
//This class is used to read the joystick input and move the player.
public class JoystickReader : MonoBehaviour
{
     public   Vector2 touchDirection = Vector2.zero;
    private void Start()
    {
    //Subscribe to the action in JoyStick.cs
        JoystickScript.onJoyStickMoved += GetJoyStickDirection;
    }
 
    void GetJoyStickDirection(Vector2 touchPosition)
    {
    //Touch direction updating every time joystick is moved.
        touchDirection = touchPosition;
        //Call player move function here to move player.
    }
}
