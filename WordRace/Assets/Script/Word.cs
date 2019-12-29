using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Word : MonoBehaviour {

    [SerializeField] Text timer;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] InputField input;
    [SerializeField] AudioClip tryAgain;
    [SerializeField] AudioClip youWin;

    Color[] colors = {new Color(255, 160, 122), new Color(250, 128, 114),
                      new Color(233, 150, 122), new Color(240, 128, 128),
                      new Color(205, 092, 092), new Color(220, 020, 060),
                      new Color(178, 034, 034), new Color(255, 255, 224),
                      new Color(255, 250, 205), new Color(255, 127, 080),
                      new Color(255, 099, 071), new Color(255, 069, 000),
                      new Color(255, 215, 000), new Color(255, 165, 000),
                      new Color(255, 140, 000), new Color(250, 250, 210),
                      new Color(255, 239, 213), new Color(255, 228, 181),
                      new Color(255, 218, 185), new Color(238, 232, 170),
                      new Color(240, 230, 140), new Color(095, 158, 160),
                      Color.yellow, Color.white, Color.red, Color.magenta,
                      Color.grey, Color.green, Color.gray, Color.cyan,Color.blue};
    string[] words = { "alow", "auto", "able", "ache", "aged", "ally", "aces", "apps", "ammo", "army",
                        "baby", "ball", "bads", "bank", "best", "bind", "bags", "bite", "bomb", "both",
                        "cabs", "calf", "call", "cell", "city", "code", "cook", "cool", "cold", "crop",
                        "dare", "dark", "dead", "dead", "demo", "dice", "dogs", "data", "down", "drag",
                        "each", "eggs", "ears", "easy", "eats", "egos", "evil", "eyes", "eche", "echo",
                        "face", "fact", "fall", "flip", "four", "free", "full", "font", "food", "fund",
                        "gang", "game", "girl", "gold", "grid", "glob", "good", "grow", "grip", "guns",
                        "hats", "hand", "head", "hold", "hack", "home", "hips", "hang", "hall", "hill",
                        "idle", "idea", "info", "into", "ions", "inch", "iffy", "icon", "ices", "init",
                        "jack", "jams", "just", "junk", "john", "join", "joke", "jobs", "jump", "jeep",
                        "kite", "kind", "know", "keep", "kept", "kiss", "kivi", "knew", "knop", "kart",
                        "lace", "lake", "late", "loop", "land", "leep", "lamp", "lady", "left", "legs",
                        "mass", "must", "mode", "made", "make", "mark", "milk", "mind", "math", "mist",
                        "noon", "none", "noun", "node", "nerd", "nite", "nope", "navy", "note", "null",
                        "oops", "oral", "oaks", "obey", "oils", "okay", "open", "only", "onto", "over",
                        "pace", "pack", "pigs", "pray", "ping", "post", "past", "peek", "pour", "poor",
                        "quid", "quit", "quiz", "qaid", "quod", "quip", "quey", "quad", "quin", "qoph",
                        "race", "rats", "room", "road", "ramp", "rare", "rows", "rich", "rice", "risk",
                        "safe", "scar", "sure", "soap", "soil", "soft", "sync", "stud", "silk", "soon",
                        "tail", "temp", "team", "time", "till", "tone", "tabs", "tape", "trip", "ties",
                        "user", "uber", "used", "uses", "upon", "unit", "ugly", "umbo", "undo", "ugli",
                        "vail", "vain", "varb", "vary", "viva", "vows", "void", "volt", "vote", "vest",
                        "wait", "wake", "wave", "wife", "wifi", "week", "weak", "wide", "wild", "wind",
                        "yack", "year", "yawn", "yoga", "yurt", "yard", "your", "yoyo", "yank", "yang",
                        "zoom", "zoon", "zone", "zeal", "zest", "zero", "zips", "zest", "zeta", "zits"};
    int index;
    int count = 5;

	// Use this for initialization
	void Start () {
        StartCoroutine(CallWordCoroutine());
        //while (count > 0)
        StartCoroutine(CallTimerCoroutine());
    }

    IEnumerator CallTimerCoroutine()
    {
        while (count > -1)
        {
            yield return StartCoroutine(TimerCoroutine());
        }
    }

    IEnumerator CallWordCoroutine()
    {
        while (index<words.Length)
        {
            input.text = "";
            yield return StartCoroutine(WordCoroutine());
        }
    }

    IEnumerator TimerCoroutine()
    {
        timer.text = count.ToString();
        yield return new WaitForSeconds(1);
        count--;
    }

    IEnumerator WordCoroutine()
    {
        text.text = words[index].ToUpper();
        text.color = colors[Random.Range(0, colors.Length)];
        yield return new WaitForSeconds(3);
        if (input.text.ToLower().Equals(text.text.ToLower()))
        {
            GetComponent<AudioSource>().clip = youWin;
            FindObjectOfType<CountScore>().Score += 5;
        }
        else
        {
            GetComponent<AudioSource>().clip = tryAgain;
            FindObjectOfType<LifeCounter>().UpdateLife();
        }
        count = 3;
        GetComponent<AudioSource>().Play();
        index++;
    }

}
