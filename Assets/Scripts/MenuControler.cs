using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControler : MonoBehaviour
{
    private Camera mainCamera;
    public Transform[] transforms;

    private void Start()
    {
        mainCamera = Camera.main;
        mainCamera.transform.position = new Vector3(transforms[0].position.x, transforms[0].position.y, mainCamera.transform.position.z);
    }

    public void GoToIMenu(int i)
    {
        mainCamera.transform.position = new Vector3(transforms[i].position.x, transforms[i].position.y, mainCamera.transform.position.z);
    }

    public void ExitApplication()
    {
        Application.Quit();
    }
}