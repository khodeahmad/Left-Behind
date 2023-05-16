using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;

/// <summary>
/// Enables the Rover to interact with Interactable elements nearby
/// </summary>
public class RoverInteraction : MonoBehaviour
{
    public KeyCode interactKey;
    public KeyCode altInteractKey;
    public LayerMask everythingLayer;
    public float interactRange = 10f;
    

    [SerializeField] Text TextMessage;
    [SerializeField] Text LightMessage;
    [SerializeField] Text RocketMessage;


    private void Start()
    {
        TextMessage.gameObject.SetActive(false);
        LightMessage.gameObject.SetActive(false);
        RocketMessage.gameObject.SetActive(false);
    }
    void Update()
    {
        InteractArea();
    }

    public void InteractArea()
    {
        var colliders = Physics.OverlapSphere(transform.position, interactRange, everythingLayer);

        foreach (Collider col in colliders)
        {

            if (col.gameObject.CompareTag("Interactable"))
            {
                if (Input.GetKeyDown(interactKey) || Input.GetKeyDown(altInteractKey) || Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    col.GetComponent<IInteractable>().Interact();

                }
            }
        }
        
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }

    private string getControllerType()
    {
        string[] joystickNames = Input.GetJoystickNames();

        foreach (string joystickName in joystickNames)
        {
            if (joystickName.ToLower().Contains("xbox"))
            {
                return "XBOX";
            }
            else if (joystickName.ToLower().Contains("playstation"))
            {
                return "PS";
            }
            else if(joystickName.ToLower().Contains("gamepad"))
            {
                return "GM";
            }
        }
        return "OTHER";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (getControllerType() == "XBOX" || getControllerType() == "PS" || getControllerType() == "GM")
        {
            TextMessage.text = "Press A";
            LightMessage.text = "Press Y to turn the car lights on or off";
            RocketMessage.text = "Complete the rocket then press A to board it";
        }
        else
        {
            TextMessage.text = "Press E or Space";
            LightMessage.text = "Press Q or L to turn the car lights on or off";
            RocketMessage.text = "Complete the rocket then press E or space to board it";
        }
        if (other.gameObject.CompareTag("MessageShow"))
        {
            TextMessage.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("LightHelper"))
        {
            LightMessage.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("RocketHelper"))
        {
            RocketMessage.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("MessageShow"))
        {
            TextMessage.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("LightHelper"))
        {
            LightMessage.gameObject.SetActive(false);
        }
        if (other.gameObject.CompareTag("RocketHelper"))
        {
            RocketMessage.gameObject.SetActive(false);
        }
    }
}
