using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using System;

public class GameMangaer : MonoBehaviour
{

    public List<GameObject> gameList;

    private int gameindex;

    private event Action<GameObject> GameSwitcher;
    public GameObject game;


}
