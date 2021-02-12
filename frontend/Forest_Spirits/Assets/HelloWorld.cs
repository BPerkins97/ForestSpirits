using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ForestSpirits;
using PersistenceNamespace;
using UnityEngine.UI;

public class HelloWorld : MonoBehaviour
{
    public Text mytext = null;
    public Button someButton = null;

    private HelloWorldBusiness business;
    private Persistence persistence = new Persistence();

    public HelloWorld ()
    {
        business = new HelloWorldBusiness(persistence);
    }


    public void changeText()
    {
        mytext.text = business.getMessage();       
    }

    void Update()
    {
        
    }

    void Start()
    {
        someButton.onClick.AddListener(changeText);
        // instantiate button from prefab
        //GameObject go = (GameObject)Instantiate(Resources.Load("Button"));
        // get button component from game object
        //Button myBtn = go.GetComponent<Button>();
        // get button text component in children and set the text property
        //mytext = myBtn.GetComponentInChildren<Text>();
    }
}
