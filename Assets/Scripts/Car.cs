using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private float speed = 200;
    public float s;
    public GameObject carVs;
    public GameObject carVo;

    // Update is called once per frame
    void Update()
    {
        if (carVo.tag == "vo")
        {
            if (carVo.transform.position.x >= -9 && carVo.transform.position.x <= 9) { 
                Vector3 newPosition = new Vector3(-s / speed, carVo.transform.position.y, carVo.transform.position.z);
                carVo.transform.position = newPosition;

            }
            if (carVo.transform.position.x < -9)
            {
                Vector3 newPosition = new Vector3(-9, carVo.transform.position.y, carVo.transform.position.z);
                carVo.transform.position = newPosition;
            }
            if (carVo.transform.position.x > 9)
            {
                Vector3 newPosition = new Vector3(9, carVo.transform.position.y, carVo.transform.position.z);
                carVo.transform.position = newPosition;
            }
        }
        if (carVs.tag == "vs")
        {
            if (carVs.transform.position.x <= 9 && carVs.transform.position.x >= -9)
            {
                Vector3 newPosition = new Vector3(s / speed, carVs.transform.position.y, carVs.transform.position.z);
                carVs.transform.position = newPosition;
            }
            if (carVs.transform.position.x > 9)
            {
                Vector3 newPosition = new Vector3(9, carVs.transform.position.y, carVs.transform.position.z);
                carVs.transform.position = newPosition;
            }
            if (carVs.transform.position.x < -9)
            {
                Vector3 newPosition = new Vector3(-9, carVs.transform.position.y, carVs.transform.position.z);
                carVs.transform.position = newPosition;
            }
        }
    }
}
