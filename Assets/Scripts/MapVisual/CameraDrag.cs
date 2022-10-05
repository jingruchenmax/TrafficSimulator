using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    public float posZSpeed=0;
    public float minSize = 10;
    public float maxSize = 20;
    private Vector3 ResetCamera;
    private Vector3 Origin;
    private Vector3 Diference;
    private bool Drag = false;
    private float camSize;
    void Start()
    {
        ResetCamera = Camera.main.transform.position;
        camSize = Camera.main.orthographicSize;
    }
    void LateUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {

            camSize -= Input.GetAxis("Mouse ScrollWheel") * posZSpeed;
            camSize = Mathf.Clamp(camSize, minSize, maxSize);
            Camera.main.orthographicSize = camSize;
            // Camera.main.transform.localPosition= new Vector3(camPostion_x, camPostion_y, distance);
        }
        if (Input.GetMouseButton(2))
        {
            Diference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (Drag == false)
            {
                Drag = true;
                Origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            Drag = false;
        }
        if (Drag == true)
        {
            Camera.main.transform.position = Origin - Diference;
        }
        //RESET CAMERA TO STARTING POSITION WITH RIGHT CLICK
        if (Input.GetMouseButton(1))
        {
            Camera.main.transform.position = ResetCamera;
        }
    }
}