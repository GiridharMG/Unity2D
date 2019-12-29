using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject {
    [TextArea(14, 10)] [SerializeField] string storyState;
    [SerializeField] State[] nextStates;

    public string GetStoryState()
    {
        return storyState;
    }
    public State[] GetNextStates()
    {
        return nextStates;
    }

}
