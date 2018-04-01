using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour {


    public Text CrystalCounterText;
    public Text CountdownText;
    public Text EndOfGameText;

    // Use this for initialization
    void Start () {

        UpdateCrystalCounterText();
        EndOfGameText.enabled = false;
        StartCoroutine(CountdownCoroutine());

    
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    IEnumerator CountdownCoroutine()
    {
        FindObjectOfType<Sphere>().CanMove = false;
        CountdownText.enabled = true;

        for(int i=5;i>0;i--)
        {
            CountdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        CountdownText.text = "START!";
        FindObjectOfType<Sphere>().CanMove = true;
        yield return new WaitForSeconds(1f);

        CountdownText.enabled = false;

    }

    public void UpdateCrystalCounterText()
    {
        var crystals = FindObjectsOfType<Crystal>();

        var crystalsCount = crystals.Length;
        var crystalInactive = crystals.Count(Crystal => !Crystal.Active);

        var text = crystalInactive + " / " + crystalsCount;

        CrystalCounterText.text = text;
    }

       public void CheckIfEndOfGame()
    {
        var endOfGame = FindObjectsOfType<Crystal>().All(crystal => !crystal.Active);

        if (!endOfGame) return;

        EndOfGame(true);

    }

    public void EndOfGame(bool win)
    {
        EndOfGameText.enabled = true;
        EndOfGameText.text = win ? "WIN!" : "LOSE!";
    }

}
