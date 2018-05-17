using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseWaterCan : MonoBehaviour {

    private RaycastHit hit;
    public LayerMask layer;
    public ParticleSystem water;
    private AudioSource waterSound;



    // Use this for initialization
    void Start () {
        waterSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.rotation.eulerAngles.x > 40 && transform.rotation.eulerAngles.x < 300  ) {
            if (!water.isPlaying)
            {
                water.Play();
            }
            if(!waterSound.isPlaying)
            {
                waterSound.Play();
            }
        }
        if((transform.rotation.eulerAngles.x < 40 || transform.rotation.eulerAngles.x > 300)  && water.isPlaying)
        {
            water.Stop();
            waterSound.Stop();
        }
    }
}
