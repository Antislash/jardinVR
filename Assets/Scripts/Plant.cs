using UnityEngine;
using System;
using System.Collections.Generic;

public class Plant : MonoBehaviour
{
    public GameObject carot, eggplant, radis, corn, tomato, pumpkin;
    private GameObject currentObject;
    private int num;
    private Vector3[] posObject;
    private Quaternion[] rotObject;

    // Use this for initialization
    void Start()
    {
        num = Int32.Parse(gameObject.tag[gameObject.tag.Length - 1].ToString());

        transform.localScale = new Vector3(0,0,0);

        switch (Manager.Instance.flower[num])
        {
            case Manager.flowerType.Tomate:
                posObject = new Vector3[3];
                posObject[0] = transform.position + new Vector3(0f, 0.95f, -1f);
                posObject[1] = transform.position + new Vector3(-0.36f, 1.34f, 0.8f);
                posObject[2] = transform.position + new Vector3(0.57f, 2.1f, -0.7f);
                rotObject = new Quaternion[3];
                rotObject[0] = Quaternion.Euler(-80, 0, 0);
                rotObject[1] = Quaternion.Euler(-60, 0, 0);
                rotObject[2] = Quaternion.Euler(-110, 0, 0);
                currentObject = tomato;
                break;
            case Manager.flowerType.Potiron:
                posObject = new Vector3[1];
                posObject[0] = transform.position + new Vector3(0f, 0.27f, 0f);
                rotObject = new Quaternion[1];
                rotObject[0] = Quaternion.Euler(-20, 0, 0);
                currentObject = pumpkin;
                break;
            case Manager.flowerType.Carotte:
                posObject = new Vector3[1];
                posObject[0] = transform.position;
                rotObject = new Quaternion[1];
                rotObject[0] = Quaternion.identity;
                currentObject = carot;
                break;
            case Manager.flowerType.Radis:
                posObject = new Vector3[1];
                posObject[0] = transform.position;
                rotObject = new Quaternion[1];
                rotObject[0] = Quaternion.identity;
                currentObject = radis;
                break;
            case Manager.flowerType.Aubergine:
                posObject = new Vector3[3];
                posObject[0] = transform.position + new Vector3(0f, 0.82f, -1f);
                posObject[1] = transform.position + new Vector3(-0.735f, 1.56f, 0.8f);
                posObject[2] = transform.position + new Vector3(0.51f, 2.44f, -0.7f);
                rotObject = new Quaternion[3];
                rotObject[0] = Quaternion.Euler(-90, 0, 0);
                rotObject[1] = Quaternion.Euler(-90, 0, 0);
                rotObject[2] = Quaternion.Euler(-90, 0, 0);
                currentObject = eggplant;
                break;
            case Manager.flowerType.Mais:
                posObject = new Vector3[3];
                posObject[0] = transform.position + new Vector3(-0.13f, 0.98f, -0.1f);
                posObject[1] = transform.position + new Vector3(-0.07f, 2.18f, -0.1f);
                posObject[2] = transform.position + new Vector3(-0.2f, 3.6f, 0f);
                rotObject = new Quaternion[3];
                rotObject[0] = Quaternion.Euler(-10, 0, 10);
                rotObject[1] = Quaternion.Euler(-15, 0, 0);
                rotObject[2] = Quaternion.Euler(0, 0, 15);
                currentObject = corn;
                break;
            default:
                posObject = new Vector3[0];
                break;
        }
        currentObject.tag = "plant_" + num;
    }

    // Update is called once per frame
    void Update()
    {
        if(Manager.Instance.length[num] < Manager.Instance.tailleFlower[Manager.Instance.flower[num]])
            transform.localScale = new Vector3(Manager.Instance.length[num], Manager.Instance.length[num], Manager.Instance.length[num]);
        if (Manager.Instance.length[num] >= Manager.Instance.tailleFlower[Manager.Instance.flower[num]] && !Manager.Instance.haveFruit[num])
        {
            Debug.Log("create");
            for (int i = 0; i < posObject.Length; i++)
            {
                Instantiate(currentObject, posObject[i], rotObject[i]);
                Manager.Instance.nbFruit[num] += 1;
            }
            if(Manager.Instance.nbFruit[num] > posObject.Length * 2)
            {
                Manager.Instance.haveFruit[num] = true;
            }
        }
    }
}
