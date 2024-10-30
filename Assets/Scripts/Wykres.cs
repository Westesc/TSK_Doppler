using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wykres : MonoBehaviour
{
    
    public GameObject source;
    public GameObject observator;
    public float vo;
    public Doppler doppler;

    public float fo;
    public float vs;
    public float fs;


    // Update is called once per frame
    void Update()
    {
        fo = doppler.getfo();
        fs = doppler.getfs();
        vo = doppler.getvo();
        vs = doppler.getvs();
        source.transform.localScale =new Vector3(1.0f, vs*7/50,1.0f);
        observator.transform.localScale = new Vector3(1.0f, vo * 7 / 50, 1.0f);
        source.transform.localPosition = new Vector3(60-500+fs/(58), 40-300, 10.0f);
        observator.transform.localPosition = new Vector3(60 - 500 + fo / (58), 40 - 300, 10.0f);
    }
}
