using System;
using UnityEngine;

public class TurnBike : MonoBehaviour
{
    public Camera cam;// Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {


        var camTrans = cam.transform;
        var eulerAngles = camTrans.eulerAngles;
        var xTrans = Mathf.Sin(eulerAngles.y * ((float)Math.PI / 180));
        var zTrans = Mathf.Cos(eulerAngles.y * ((float)Math.PI / 180));
        
        var rotation = Quaternion.Euler(0, eulerAngles.y, 0);
        var transform1 = transform;
        transform1.rotation = rotation;

        var position = camTrans.position;
        transform1.position = new Vector3(position.x - 0.5f * xTrans, transform1.position.y, position.z - 0.5f*zTrans);
    }
}
