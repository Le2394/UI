using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerList", menuName = "ScriptableObjects/PlayerList", order = 1)]
public class PlayerList : ScriptableObject
{
    public List<string> playerNames = new List<string>();
}
