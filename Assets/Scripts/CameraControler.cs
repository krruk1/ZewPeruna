using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderTickness = 10f;
    public float scrollSpeed = 500f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderTickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime , Space.World);
        }
        if(Input.GetKey("s") || Input.mousePosition.y <= 0 + panBorderTickness )
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderTickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= 0 + panBorderTickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * scrollSpeed * Time.deltaTime;

        transform.position = pos;

    }
}
