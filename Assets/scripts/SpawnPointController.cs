using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointController : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform playerBody;
    public Transform cameraTransform;


void LateUpdate()
{
    float yRot = playerBody.eulerAngles.y;
    float xRot = cameraTransform.localEulerAngles.x;

    // 🚨 Posible interferencia con la cámara
    // spawnPoint.rotation = Quaternion.Euler(xRot, yRot, 0f);
}
}
