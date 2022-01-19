using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HackingCameraMovement : MonoBehaviour
{
    public float scaler = -.5f;
    public float mouseScaler = -.5f;

    public Camera _this;
    // Start is called before the first frame update
    void Start()
    {
        _this = transform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Translate(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * scaler);
        }
        

        _this.orthographicSize = Mathf.Clamp(
            _this.orthographicSize + (Input.mouseScrollDelta.y * mouseScaler),
            4f,
            10f);
    }
}
