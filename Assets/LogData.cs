using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogData : MonoBehaviour
{

    //The URL to the server - In our case localhost with port number 2475
    private string url = "https://localhost:44361/";

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        // Make a background box
        GUI.Box(new Rect(10, 10, 100, 90), "Loader Menu");

        // Make the first button.
        if (GUI.Button(new Rect(20, 40, 80, 20), "Connect"))
        {

            //when the button is clicked

            //setup url to the ASP.NET webpage that is going to be called
            string customUrl = url + "LogUserScore.aspx";

            //setup a form
            WWWForm form = new WWWForm();

            //Setup the paramaters
            form.AddField("UserID", "47");
            form.AddField("Score", "100");

            //Call the server
            WWW www = new WWW(customUrl, form);
            StartCoroutine(WaitForRequest(www));
        }

    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {
            //write data returned from ASP.NET
            Debug.Log(www.text);

        }
        else
        {
            Debug.Log("WWW Error: " + www.error);
        }
    }

}
