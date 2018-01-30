using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private string horizontalAxis, verticleAxis, aButton, bButton, xButton, yButton;

    public string Horizontal()
    {
        return horizontalAxis;
    }
    public string Verticle()
    {
        return verticleAxis;
    }
    public string A()
    {
        return aButton;
    }
    public string B()
    {
        return bButton;
    }
    public string X()
    {
        return xButton;
    }
    public string Y()
    {
        return yButton;
    }
}
