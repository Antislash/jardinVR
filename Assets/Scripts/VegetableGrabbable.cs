using HTC.UnityPlugin.Vive;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VegetableGrabbable : MonoBehaviour
{

    private BasicGrabbable script;
    public GameObject showScore;
    public ParticleSystem smoke;

    private bool test = true;
    int num;


    // Use this for initialization
    void Start ()
    {
        num = Int32.Parse(gameObject.tag[gameObject.tag.Length - 1].ToString());
        script = GetComponent<BasicGrabbable>();
        showScore = GameObject.Find("ShowScore");
	}
	
	// Update is called once per frame
	void Update () {
        if (script.dragged && test)
        {
            test = false;
            Debug.Log("brj " + Manager.Instance.length[num]);
            Manager.Instance.nbFruit[num]--;
            if (Manager.Instance.nbFruit[num] == 0)
            {
                Manager.Instance.length[num] = Manager.Instance.tailleFlower[Manager.Instance.flower[num]];
                Manager.Instance.haveFruit[num] = false;
            }
            StartCoroutine(ShowScore());
        }
	}

    IEnumerator ShowScore()
    {
        //Play song
        AudioSource popSound = gameObject.GetComponent<AudioSource>();
        popSound.Play();

        //Smoke
        smoke = Manager.Instance.smoke;

        ParticleSystem smokePop = Instantiate(smoke, transform.position, Quaternion.identity);

        MeshRenderer renderer = gameObject.GetComponent<MeshRenderer>();
        renderer.enabled = false;


        //Show score
        //GameObject g = GameObject.Find("TextScore");
        //TextMesh text = g.GetComponent<TextMesh>();



        //TextMesh t = Instantiate(text, g.transform.position, Quaternion.Euler(new Vector3(g.transform.rotation.x ,g.transform.rotation.y,0)));///*Quaternion.identity*/ g.transform.rotation);
        //t.text = (Manager.Instance.score).ToString();
        //Manager.Instance.score++;

        //// Start function WaitAndPrint as a coroutine
        //yield return new WaitForSeconds(0.2f);

        //t.text = (Manager.Instance.score).ToString();

        //for (int i = 0; i < 20; i++)
        //{
        //    t.transform.position += new Vector3(0.05f, 0.1f, 0);
        //    t.color = new Vector4(t.color.r, t.color.g, t.color.b, t.color.a - 0.05f);
        //    yield return new WaitForSeconds(0.08f);
        //}

        //yield return new WaitForSeconds(0.8f);

        //Destroy(t);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
