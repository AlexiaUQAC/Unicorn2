using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue_So : ScriptableObject
{
    public Sprite NPCImage;
    public string NPCName;
    [TextArea(3, 10)]
    public string[] sentences;
}
