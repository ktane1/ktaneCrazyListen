using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public MeshRenderer[] submitButtonColours;
    public TextMesh[] submitText;
    public Material[] buttonColours;

    public AudioClip[] intros, quotes, corrects, wrongs;
    private static string[] speakerNames = new string[] { "weird", "Kilo", "Arceus", "Deader", "CrazyCaleb", "Kabewm", "Depresso", "MásQuéÉlite", "FlompStompton", "Shadow Meow", "Pippy", "Dbros", "Luna", "ScopingLandscape", "Gwen", "Day", "yabba", "Jay", "Boxpone", "ManiaMate", "Eltrick", "GhostSalt", "Whalien", "Rdzanu", "DeeDeeEn", "Logan" };
    private static int[] speakerValues = new int[] { 43, 41, 48, 61, 76, 85, 88, 40, 34, 42, 29, 78, 95, 55, 80, 22, 53, 38, 77, 28, 30, 21, 52, 16, 50, 74 };
    private static string[] fullQuotes = new string[] { "I swear to god, if you don’t give me edgework right now…", "No, I said the module is Crazy Talk, not Regular Crazy Talk.", "Oh, whoops, we have an early strike now, wanna reset?", "Why is my IP address displayed on the module?", "Oh I don’t think I like that transformation.", "Hold, no not hold the button, just hold on for a sec.", "Are you sure it’s supposed to work like that? Or is the module actually bugged?", "Unpopular opinion: Needies are terribly underrated.", "This isn’t Forget Our Voices. They lied to me.", "Insert quote here from Simon’s Satire.", "Uhh guys, the module’s flashing red here, did I do something wrong?", "The makers of this module are clearly in need of quote ideas right now.", "Press this button today to win a special prize to KTaNE Land, where all the bomb blowers and module masters are found!", "Okay, that’s a wrap, can I have my 5 dollars now?", "There is no submit button. The manual lied. Go outside. Touch grass.", "Hey, I know life’s been rough, but just wanna say that you’ve been doing a good job playing till now :)", "Hello Youtube! Or Twitch! Or whatever streaming site I’m on!", "Oh god darn it not again.", "If you happen to not recognize this beautiful voice, then I guess you’re screwed.", "" };
    private static int[] fullQuoteValues = new int[] { 349, 160, 832, 256, 738, 160, 476, 931, 501, 690, 402, 269, 215, 789, 456, 123, 604, 173, 209, 420 };

    private string[] selectedSpeakers = new string[3];
    private int[] selectedQuotes = new int[3];

    private static int moduleIdCounter = 1;
    private int moduleId;
    private bool inputMode, moduleSolved; // Some helpful booleans

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
        borderColour.material.color = Color.HSVToRGB(h, 1f, 0.7f);
        StringBuilder sb = new StringBuilder();
        string[] speakerNamesDup = speakerNames.ToArray();
        for (int i = 0; i < 3; i++)
        {
            int k = UnityEngine.Random.Range(0, 2);
            submitButtonColours[i].material = buttonColours[k];
            if (k == 0) { sb.Append("Blue, "); } else { sb.Append("Red, "); }
            int rndNumber = UnityEngine.Random.Range(0, 100);
            submitText[i].text = rndNumber < 10 ? "0" + rndNumber.ToString() : rndNumber.ToString();
        }
        sb.Remove(sb.Length - 2, 2);
        Debug.LogFormat("[Crazy Listen #{0}]: The button colours are {1}.", moduleId, sb.ToString());

        sb.Remove(0, sb.Length);
        foreach (TextMesh i in submitText)
        {
            sb.Append(i.text + ", ");
        }
        sb.Remove(sb.Length - 2, 2);
        Debug.LogFormat("[Crazy Listen #{0}]: The button values are {1}.", moduleId, sb.ToString());

        sb.Remove(0, sb.Length);
        for (int i = 0; i < 3; i++)
        {
            int rndSpeaker = UnityEngine.Random.Range(0, speakerNamesDup.Length);
            selectedSpeakers[i] = speakerNamesDup[rndSpeaker];
            sb.Append(speakerNamesDup[rndSpeaker] + ", ");
            speakerNamesDup = speakerNames.Where(val => val != speakerNames[rndSpeaker]).ToArray(); 
        }
        sb.Remove(sb.Length - 2, 2);
        Debug.LogFormat("[Crazy Listen #0]: The speakers behind the play buttons are {1}.", moduleId, sb.ToString());

    }

    void playHandler(int k)
    {
        
    }

    void submitHandler(int k)
    {
        if (moduleSolved)
        {
            return;
        }
        if (!inputMode)
        {
            inputMode = true;
            Debug.LogFormat("[Crazy Listen #0]: One of the submit buttons is pressed! Input mode initiated.", moduleId);
            selectedSpeakers.Shuffle();
            for (int i = 0; i < 3; i++)
            {
                submitText[i].text = "??";
                submitButtonColours[i].material = buttonColours[2];
                int rndQuotes = UnityEngine.Random.Range(0, fullQuotes.Length);
                selectedQuotes[i] = rndQuotes;
                if (rndQuotes == selectedQuotes.Length - 1)
                {
                    Debug.LogFormat("[Crazy Listen #0]: For play button #{1}, {2} speaks their own custom quote.", moduleId, i + 1, selectedSpeakers[i]);
                }
                else
                {
                    Debug.LogFormat("[Crazy Listen #0]: For play button #{1}, {2} speaks the quote \"{3}\"", moduleId, i + 1, selectedSpeakers[i], fullQuotes[selectedQuotes[i]]);
                }
            }
        }
    }

    void submitMode()
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
