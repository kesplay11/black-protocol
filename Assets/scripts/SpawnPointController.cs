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

        spawnPoint.rotation = Quaternion.Euler(xRot, yRot, 0f);
    }
}
