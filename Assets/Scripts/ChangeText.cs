using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ChangeText : MonoBehaviour
{

    TextMesh txt;
    int num;

    // Use this for initialization
    void Start()
    {
        txt = gameObject.GetComponent<TextMesh>();
        num = Int32.Parse(gameObject.name[gameObject.name.Length - 1].ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Manager.Instance.isSet[num])
        {
            switch (Manager.Instance.flower[num])
            {
                case Manager.flowerType.Tomate:
                    txt.text = "Tomate";
                    break;
                case Manager.flowerType.Potiron:
                    txt.text = "Potiron";
                    break;
                case Manager.flowerType.Carotte:
                    txt.text = "Carotte";
                    break;
                case Manager.flowerType.Radis:
                    txt.text = "Radis";
                    break;
                case Manager.flowerType.Aubergine:
                    txt.text = "Aubergine";
                    break;
                case Manager.flowerType.Mais:
                    txt.text = "Mais";
                    break;
                default:
                    txt.text = "Plante";
                    break;
            }
            txt.text += " - " + ((float)((float)Manager.Instance.water[num]/ (float)Manager.WATER_LEVEL)*100f).ToString("0") + "% d'eau";
        }
        else
        {
            txt.text = "";
        }
    }
}
