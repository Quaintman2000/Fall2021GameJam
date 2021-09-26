using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretNodes : MonoBehaviour
{

    //the highlighed color of the block
    public Color hoverColor;
    public Vector3 postionOffSet;
    //the turrent gameobject
    [Header("optional")]
    public GameObject turret;

    //the color of the node
    private Color startColor;
    //will get the sprite incon 
    private SpriteRenderer srend;
    GameManager gameManager;

    private void Start()
    {   //gets the sprite component
        srend = GetComponent<SpriteRenderer>();
        //sets the color of the sprite 
        startColor = srend.material.color;

        gameManager = GameManager.instance;
    }

    public Vector3 GetBuildPostion()
    {
        return transform.position + postionOffSet;
    }
    //when the player mouse clicks do these functions
    void OnMouseDown()
    {
        //will not place a turret if you havent selected one
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        //will check to see if you can buld a turret
        if (!gameManager.CanBuild)
            return;
        //check to see if you can build there. 
        if (turret != null)
        {
            Debug.Log("cant build there");
            return;
        }
        //if the turret can be built build one
        gameManager.BuildTurretOn(this);
    }

    //when the mouse highlights the block
    void OnMouseEnter()
    {
        //will only place a turret if you selected one
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        //will call the build function allowing a turret to be placed
        if (!gameManager.CanBuild)
            return;
        //when you hover over the box with the cursor it will highlight to a diffrent color
        srend.material.color = hoverColor;

    }

    void OnMouseExit()
    {
        //when the cursor is not hoverd over the object go to oringal color
        srend.material.color = startColor;
    }
}


