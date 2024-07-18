using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    

    public float Ymouse, Xmouse;
    public float sens;
    float Xrot;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Ymouse = Input.GetAxis("Mouse Y") * Time.deltaTime * sens;
        Xmouse = Input.GetAxis("Mouse X") * Time.deltaTime * sens;
        Xrot -= Ymouse;
      Xrot = Mathf.Clamp(Xrot, -4f, 4f);
        transform.localRotation = Quaternion.Euler(0f, Xrot * -1f, 0f);
    }
}
