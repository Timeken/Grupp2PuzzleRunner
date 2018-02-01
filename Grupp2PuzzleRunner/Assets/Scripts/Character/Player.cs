using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private string horizontalAxis, verticleAxis, aButton, bButton, xButton, yButton;
    [SerializeField]
    private PlayerControler PC;
    [SerializeField]
    private SpriteRenderer characterRenderer;

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
    public IEnumerator ChangeSpeed(float speed, float duration)
    {
        PC.SetSpeed(speed);
        yield return new WaitForSeconds(duration);
        PC.SetSpeed();
    }
    public IEnumerator HideCharacter(float duration)
    {
        characterRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        characterRenderer.enabled = true;
    }
}
