using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using TMPro;
using UnityEngine.UIElements;
using System;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;
    [SerializeField] Vector3 offset;
    [SerializeField] float lerp;
    private Vector3 velocidad = Vector3.zero;
    [SerializeField] PlayerMovement Script;
    private float Direccion;
    private bool PlayerFuera;
    void Start()
    {
        
    }
    void Update() {

        if(Script.PlayerFuera) {
            Vector3 movePosition = player.position + offset;
            //transform.position = Vector3.SmoothDamp(transform.position, movePosition, ref velocidad, damping);
            if (player.position.x < transform.position.x) {
                Direccion = 1;
            }else {
                Direccion = -1;
            }

            transform.position = Vector3.Lerp(transform.position, movePosition + new Vector3(6f*Direccion, 0, 0), lerp);
        }
    }
    void FixedUpdate()
    {
        
    }

    
}
