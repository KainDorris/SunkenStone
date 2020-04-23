﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private ResourceManager _resourceManager;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject specialProjectile;
    [SerializeField] private GameObject playerBody;

    public Camera cam;

    private Vector3 mousePos;


    
    // Start is called before the first frame update
    void Start()
    {
        if (player == null) player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _resourceManager = GameObject.Find("Canvas").GetComponent<ResourceManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerHotKeys();
        Shoot();

        

    }
    
    private void PlayerMovement()
    {
        float speed = player.GetSpeed();
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

        if (horizontalInput != 0 && verticalInput != 0)
        {
            player.transform.Translate(direction * ((speed * 0.7f ) * Time.deltaTime));
        }
        else
        {
            player.transform.Translate(direction * (speed * Time.deltaTime));
        }
    }

    private void Shoot(){
        if(Input.GetButtonDown("Fire1")){
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 lookDir = playerBody.transform.position - mousePos;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
            Vector3 angleVector = new Vector3(0f, 0f, angle);
            playerBody.transform.rotation = Quaternion.Euler(angleVector);
            Instantiate(projectile, player.transform.position, playerBody.transform.rotation, player.transform);
        }
        else if (Input.GetButtonDown("Fire2") && _resourceManager.GetResourceCount() > 0)
        {
            _resourceManager.RemoveResource();
            ShootLogic();
        }
    }
    
    

    private void ShootLogic()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 lookDir = playerBody.transform.position - mousePos;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        Vector3 angleVector = new Vector3(0f, 0f, angle);
        playerBody.transform.rotation = Quaternion.Euler(angleVector);
        Instantiate(specialProjectile, player.transform.position, playerBody.transform.rotation, player.transform);
    }


    private void PlayerHotKeys()
    {
        // TODO: Determine Default Keys for Hot Swapping Monsters. For Now: 1 , 2 , 3 are used to allow WSDA Movement.
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            player.SwapMinions(0);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            player.SwapMinions(1);
        } 
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            player.SwapMinions(2);
        }
    }

}
