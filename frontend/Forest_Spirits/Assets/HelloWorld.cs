using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ForestSpirits;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    public Text co2Level = null;
    public Button baumBauen = null;

    private BaumPflanzenUseCase baum;

    public void changeText()
    {
        baum.pflanzeBaum(1);
    }


    void Update()
    {
        
    }

    void Start()
    {
        Co2LevelAnzeigeInUnity co2Display = new Co2LevelAnzeigeInUnity(co2Level);
        baum = new BaumPflanzenUseCase(co2Display);
        baumBauen.onClick.AddListener(changeText);
        // instantiate button from prefab
        //GameObject go = (GameObject)Instantiate(Resources.Load("Button"));
        // get button component from game object
        //Button myBtn = go.GetComponent<Button>();
        // get button text component in children and set the text property
        //mytext = myBtn.GetComponentInChildren<Text>();
    }
}

public class Co2LevelAnzeigeInUnity : Co2Anzeige {
    private Text co2LevelDisplay;

    public Co2LevelAnzeigeInUnity (Text co2LevelDisplay)
    {
        this.co2LevelDisplay = co2LevelDisplay;
    }

    public void zeigeCo2Level(int co2Level)
    {
        co2LevelDisplay.text = "" + co2Level;
    }

    public void zeigeWinAn()
    {
        co2LevelDisplay.text = "Fuckers";
    }
}