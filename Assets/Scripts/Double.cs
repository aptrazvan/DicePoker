using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Double : MonoBehaviour
{
    bool lowClicked;
    public GameObject doubleDice;
    public Button lowButton;
    public Button highButton;
    public Button doubleButton;
    public Camera mainCamera;
    public Camera zoomCamera;
    public GameObject cup;
    public Button rerollButton;
    public Material unselectedMaterial;

    // Start is called before the first frame update
    void Start()
    {
        doubleButton.enabled = false;
        doubleButton.gameObject.SetActive(false);
        highButton.enabled = false;
        highButton.gameObject.SetActive(false);
        lowButton.enabled = false;
        lowButton.gameObject.SetActive(false);
        if (lowButton.GetComponent<ButtonPress>().value == true) {
            lowClicked = true;
        }
        else if (highButton.GetComponent<ButtonPress>().value == true)
        {
            lowClicked = false;
        }

        mainCamera.enabled = true;
        zoomCamera.enabled = false;
        cup.GetComponent<CupShake>().Reposition();
        doubleDice.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = unselectedMaterial;
        doubleDice.GetComponent<DiceRoll>().enabled = true;
        doubleDice.GetComponent<DiceRoll>().Reposition();
        if (lowClicked)
        {
            if (doubleDice.GetComponent<DiceRoll>().upFace <= 3)
                Score.score *= 2;
            else
                Score.score = 0;
        }
        else
        {
            if (doubleDice.GetComponent<DiceRoll>().upFace >= 4)
                Score.score *= 2;
            else
                Score.score = 0;
        }
        rerollButton.GetComponent<ButtonPress>().value = false;
        rerollButton.enabled = false;
        rerollButton.gameObject.SetActive(false);
        this.GetComponent<Double>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
