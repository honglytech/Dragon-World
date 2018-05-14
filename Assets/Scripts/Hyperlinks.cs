using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Hyperlinks is a class that controls hyperlink in Legal section under about page.
public class Hyperlinks : MonoBehaviour {

    // First attribute to the first image in about page.
    public void OpenHyperlinkOne()
    {
        Application.OpenURL("https://www.pinterest.co.uk/pin/391039180118906812/?autologin=true");
    }

    // Second attribute to the second image in about page.
    public void OpenHyperlinkTwo()
    {
        Application.OpenURL("https://dashinvaine.deviantart.com/art/Dragon-and-Captive-reloaded-129209195");
    }
}
