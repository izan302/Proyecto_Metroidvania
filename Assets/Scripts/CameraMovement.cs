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
    [SerializeField] GameObject BoundingBox;
    private float DireccionX;
    private float DireccionY;
    private bool PlayerFuera;
    private Vector3 BoundingBoxSize;
    void Start()
    {
        BoundingBoxSize = BoundingBox.GetComponent<Collider2D>().bounds.size;
    }
    void Update() {

        if(Script.PlayerFuera) {
            Vector3 movePosition = player.position + offset;

            if (player.position.x < transform.position.x) {
                DireccionX = 1;
            }else {
                DireccionX = -1;
            }
            transform.position = Vector3.Lerp(transform.position, movePosition + new Vector3((BoundingBoxSize.x/2)*DireccionX, 0, 0), lerp);


            if (player.position.y < transform.position.y) {
                DireccionY = 1;
            }else {
                DireccionY = -1;
            }
            
        }
    }
}
