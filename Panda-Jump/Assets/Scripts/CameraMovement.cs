using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void Update()
    {
        transform.position = new Vector3(0, player.transform.position.y + 2, -10);
        //transform.position = new Vector3(0, platformParent.transform.GetChild(0).position.y + 2, -10);
    }

}
