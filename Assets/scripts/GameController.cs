using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {


    public Text CrystalCounterText;
    public Text CountdownText;
    public Text EndOfGameText;

    public string NextlevelName;

    public AudioClip WinSound;
    public AudioClip LoseSound;

    // Use this for initialization
    void Start () {

        UpdateCrystalCounterText();
        FixLighting();
        EndOfGameText.enabled = false;
        StartCoroutine(CountdownCoroutine());

    
    }

    void FixLighting()
    {
        RenderSettings.ambientLight = Color.white; // ustawienia oświetlenia
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
    }

    // Update is called once per frame
    void Update ()
    {
    }

   
    IEnumerator CountdownCoroutine() //korutyna odliczania do startu
    {
        SetIfBallCanMove(false); //kulka nie może się ruszać
        CountdownText.enabled = true; //tekst z odliczaniem

        for(int i=5;i>0;i--) //odliczanie
        {
            CountdownText.text = i.ToString();
            yield return new WaitForSeconds(1f); //czekanie sekundy
        }

   
        CountdownText.text = "START!";
        SetIfBallCanMove(true); // kulka może się ruszać
        yield return new WaitForSeconds(1f);

        CountdownText.enabled = false; // wyłączamy tekst

    }

    void SetIfBallCanMove (bool canMove)
    {
       var ball = FindObjectOfType<Sphere>();
        ball.CanMove = canMove;

        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }


    public void UpdateCrystalCounterText()
    {
        var crystals = FindObjectsOfType<Crystal>(); //podliczamy wszystkie kryształy i wartość dajemy do tablicy

        var crystalsCount = crystals.Length; // zwracamy długość tablicy tzn ilość kryształów
        var crystalInactive = crystals.Count(Crystal => !Crystal.Active); //ilość nieaktywnym kryształów

        var text = crystalInactive + " / " + crystalsCount; // wyświetlany tekst licznika

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
        StartCoroutine(EndOfGameCoroutine(win));
        
    }


    IEnumerator EndOfGameCoroutine(bool win)
    {
        SetIfBallCanMove(false);

        EndOfGameText.enabled = true;
        EndOfGameText.text = win ? "WIN!" : "LOSE!";

        var audioSource=GetComponent<AudioSource>();

        audioSource.clip = win ? WinSound : LoseSound;

        audioSource.Play();

        if (win)
        {
            yield return new WaitForSeconds(3f);

            if (NextlevelName == "")
                Application.Quit();
            else
                SceneManager.LoadScene(NextlevelName);
        }


    }

}
