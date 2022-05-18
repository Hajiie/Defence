using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewObject", menuName = "New Object/Object")]
public class Object : ScriptableObject
{
    public enum ObjectType
    {
        Closet,
        Drawer,
        DeskDrawer,
        Bed
    }
    public string objectName;
    public ObjectType objectType;
    public Sprite objectImage;

}
