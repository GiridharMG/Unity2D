using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordGameControl : MonoBehaviour {
    [SerializeField] Text titleText;
    [SerializeField] Text storyAndRules;
    [SerializeField] State startingState;
    State state;
   	// Use this for initialization
	void Start () {
        titleText.text = ("Word Puzal Adventure Game");
        //storyAndRules.text = ("1.\tYou are an private ditective and you got a case to\n\tsolve.\n2.\tCarefully choose an option and search for the\n\tcriminal" +
        //	" to solve a case.\n3.\tThe criminal's next target is the minister's house.\n4.\tIf you miss him and you will in jail thinking that you\n\tare" +
        //	" helping criminal.");
        state = startingState;
        storyAndRules.text = state.GetStoryState();
        
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(state.name);
        ManageStatesWithKeys();
    }
   
    void ManageStatesWithKeys()
    {
        if (state.name.Equals("StartingState"))
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                state = state.GetNextStates()[0];
                storyAndRules.text = state.GetStoryState();
            }
        }
        else if (state.name.Equals("GamePlay"))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                state = state.GetNextStates()[0];
                storyAndRules.text = state.GetStoryState();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                state = state.GetNextStates()[1];
                storyAndRules.text = state.GetStoryState();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                state = state.GetNextStates()[2];
                storyAndRules.text = state.GetStoryState();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                state = state.GetNextStates()[3];
                storyAndRules.text = state.GetStoryState();
            }
        }
        else if (!state.name.Equals("Result"))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                state = state.GetNextStates()[0];
                storyAndRules.text = state.GetStoryState();
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                state = state.GetNextStates()[1];
                storyAndRules.text = state.GetStoryState();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                state = state.GetNextStates()[0];
                storyAndRules.text = state.GetStoryState();
            }
        }
    }
}
