using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    PlayerController playerController;
    CharacterController characterController;
    GameObject avatar;
    GameObject mainCamera;
    Health health;
    float moveSpeed = 3f;

    private void Awake()
    {
        avatar = transform.parent.gameObject;
        health = avatar.GetComponent<Health>();
        mainCamera = avatar.transform.Find("Main Camera").gameObject;
        characterController = avatar.GetComponent<CharacterController>();
        playerController = new PlayerController();
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        Vector2 m = playerController.DesktopPlayer.Movement.ReadValue<Vector2>();
        Vector2 m2 = playerController.JoystickPlayer.Movement.ReadValue<Vector2>();
        Vector3 movement;
        if (m2.x == 0 && m2.y == 0)
        {
            if (m.y > 0.9f)
            {
                movement = mainCamera.transform.forward;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            else if (m.y < -0.9f)
            {
                movement = -mainCamera.transform.forward;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            else if (m.x > 0.9f)
            {
                movement = mainCamera.transform.right;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            else if (m.x < -0.9f)
            {
                movement = -mainCamera.transform.right;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            //Forward Right
            else if (m.y > 0.5f && m.x > 0.5f)
            {
                movement = (mainCamera.transform.forward + mainCamera.transform.right) / 2;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            //Back Right
            else if (m.y < -0.5f && m.x > 0.5f)
            {
                movement = (-mainCamera.transform.forward + mainCamera.transform.right) / 2;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            //Forward Left
            else if (m.y > 0.5f && m.x < -0.5f)
            {
                movement = (mainCamera.transform.forward + -mainCamera.transform.right) / 2;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            //Back Left
            else if (m.y < -0.5f && m.x < -0.5f)
            {
                movement = (-mainCamera.transform.forward + -mainCamera.transform.right) / 2;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
        }
        else if(m.x == 0 && m.y == 0)
        {
            if (m2.y > 0.9f)
            {
                movement = mainCamera.transform.forward;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            else if (m2.y < -0.9f)
            {
                movement = -mainCamera.transform.forward;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            else if (m2.x > 0.9f)
            {
                movement = mainCamera.transform.right;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            else if (m2.x < -0.9f)
            {
                movement = -mainCamera.transform.right;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            //Forward Right
            else if (m2.y > 0.5f && m2.x > 0.5f)
            {
                movement = (mainCamera.transform.forward + mainCamera.transform.right) / 2;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            //Back Right
            else if (m2.y < -0.5f && m2.x > 0.5f)
            {
                movement = (-mainCamera.transform.forward + mainCamera.transform.right) / 2;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            //Forward Left
            else if (m2.y > 0.5f && m2.x < -0.5f)
            {
                movement = (mainCamera.transform.forward + -mainCamera.transform.right) / 2;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
            //Back Left
            else if (m2.y < -0.5f && m2.x < -0.5f)
            {
                movement = (-mainCamera.transform.forward + -mainCamera.transform.right) / 2;
                movement.y = 0;
                characterController.Move(moveSpeed * Time.deltaTime * movement);
            }
        }
        if (!health.isDead())
        {
            if (m2.x == 0 && m2.y == 0)
            {
                if (m.y != 0 || m.x != 0)
                {
                    Time.timeScale = 4f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
            }
            else if (m.x == 0 && m.y == 0)
            {
                if (m2.y != 0 || m2.x != 0)
                {
                    Time.timeScale = 4f;
                }

                else
                {
                    Time.timeScale = 1f;
                }
            }
        }
    }
    private void OnEnable()
    {
        playerController.DesktopPlayer.Enable();
        playerController.JoystickPlayer.Enable();
    }

    private void OnDisable()
    {
        playerController.DesktopPlayer.Disable();
        playerController.JoystickPlayer.Disable();
    }
}
