using System;
using UnityEngine;

public class collisionGardenBed : MonoBehaviour
{

    public GameObject plant, hole, carot, eggplant, radis, corn, tomato, pumpkin;
    private GameObject currentObject;
    private Vector3 plantPosition, plantPosition1, plantPosition2;
    private string num;
    private bool alreadyCreated = false;
    public AudioSource collisionSound;

    // Use this for initialization
    void Start()
    {   
        plantPosition = transform.position + new Vector3(0, 0.8f, 0);
        plantPosition1 = transform.position + new Vector3(1.8f, 0.8f, 0.3f);
        plantPosition2 = transform.position + new Vector3(-1.8f, 0.8f, -0.3f);
        num = gameObject.name[gameObject.name.Length - 1].ToString();
        switch (Manager.Instance.flower[Int32.Parse(num)])
        {
            case Manager.flowerType.Tomate:
                currentObject = tomato;
                break;
            case Manager.flowerType.Potiron:
                currentObject = pumpkin;
                break;
            case Manager.flowerType.Carotte:
                currentObject = carot;
                break;
            case Manager.flowerType.Radis:
                currentObject = radis;
                break;
            case Manager.flowerType.Aubergine:
                currentObject = eggplant;
                break;
            case Manager.flowerType.Mais:
                currentObject = corn;
                break;
            default:
                currentObject = plant;
                break;
        }

        collisionSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Shovel" && !alreadyCreated)
        {
            collisionSound.Play();
            alreadyCreated = true;
            currentObject.tag = "plant_" + num;
            Manager.Instance.isSet[Int32.Parse(num)] = true;
            //On instancie les trous
            Instantiate(hole, plantPosition, Quaternion.identity);
            Instantiate(hole, plantPosition1, Quaternion.identity);
            Instantiate(hole, plantPosition2, Quaternion.identity);
            //On instancie les plantes
            Instantiate(currentObject, plantPosition, Quaternion.identity);
            Instantiate(currentObject, plantPosition1, Quaternion.identity);
            Instantiate(currentObject, plantPosition2, Quaternion.identity);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        int num = Int32.Parse(gameObject.name[gameObject.name.Length - 1].ToString());
        Manager.Instance.incrementWater(num);
    }


}
