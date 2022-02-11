using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using KModkit;

public class CrazyListenScript : MonoBehaviour
{
    public new KMAudio audio;
    public KMAudio.KMAudioRef audioRef;
    public KMBombInfo bomb;
	public KMBombModule module;

    public MeshRenderer borderColour;
    public KMSelectable[] playButtons;
    public KMSelectable[] submitButtons;
    public TextMesh[] submitText;

    public AudioClip[] intros, quotes, corrects, wrongs;
    private string[] speakerNames = new string[] { "Asew", "weird", "Kilo", "Arceus", "Deader", "CrazyCaleb", "Kabewm", "Depresso", "MásQuéÉlite", "FlompStompton", "Shadow Meow", "Pippy", "Dbros", "Luna", "ScopingLandscape", "Gwen", "Day", "yabba", "Jay", "Boxpone", "Timwi", "ManiaMate", "Obvious", "Eltrick", "GhostSalt", "Whalien", "Rdzanu", "DeeDeeEn", "Logan", "ktane1" };
    private int[] speakerValues = new int[] { 79, 43, 41, 48, 61, 76, 85, 88, 40, 34, 42, 29, 28, 78, 95, 55, 80, 22, 53, 38, 47, 77, 28, 30, 21, 52, 16, 50, 74, 93 };
    private int[] initialNumbers = new int[3];

    private static int moduleIdCounter = 1;
    private int moduleId;
    private bool moduleActivated, inputMode, moduleSolved; // Some helpful booleans

    void Awake()
    {
    	moduleId = moduleIdCounter++;
        for (int i = 0; i < playButtons.Length; i++)
        {
            int j = i;
            playButtons[j].OnInteract += () => { playHandler(j); return false; };
        }
        for (int i = 0; i < submitButtons.Length; i++)
        {
            int j = i;
            submitButtons[j].OnInteract += () => { submitHandler(j); return false; };
        }
    }

    void Start()
    {
        float h = UnityEngine.Random.Range(0f, 1f);
        borderColour.material.color = Color.HSVtoRGB(h, 1f, 0.66f);
    }

    void playHandler(int k)
    {

    }

    void submitHandler(int k)
    {

    }

    void SomeFunctionAfterBombActivates()
    {
        
    }

    void Update() //Runs every frame.
    {

    }

    void GiveStrikeOrSolve()
    {
        //module.HandlePass();
        //module.HandleStrike();
    }
    /*Twitch plays
    #pragma warning disable 414
    private readonly string TwitchHelpMessage = @"";
    #pragma warning restore 414

    IEnumerator ProcessTwitchCommand(string command)
    {
        command = command.ToLowerInvariant().Trim();
        Match m = Regex.Match(command, @"^()$");
        yield return null;
    }
    */

    /*Force Solve Handler
    IEnumerator TwitchHandleForcedSolve()
    {
        yield return null;
    }
    */
}
