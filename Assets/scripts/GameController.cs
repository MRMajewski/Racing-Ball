using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour {


    public Text CrystalCounterText;

	// Use this for initialization
	void Start () {
  

    }
	
	// Update is called once per frame
	void Update () {
        UpdateCrystalCounterText();

    }

    void UpdateCrystalCounterText()
    {
        var crystals = FindObjectsOfType<Crystal>();

        var crystalsCount = crystals.Length;
        var crystalInactive = crystals.Count(Crystal => !Crystal.Active);

        var text = crystalInactive + " / " + crystalsCount;

        CrystalCounterText.text = text;
    }
}
