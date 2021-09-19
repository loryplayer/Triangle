using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player,triangle;

    private void LateUpdate()
    {
        Vector3 newPosition = player.position;
        var transform1 = transform;
        newPosition.y = transform1.position.y;
        transform1.position = newPosition;
        triangle.position = new Vector3(newPosition.x,newPosition.y-100,newPosition.z);
        triangle.rotation=Quaternion.Euler(90f,player.eulerAngles.y,0f);
    }


}
