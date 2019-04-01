using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class Save_script : MonoBehaviour
{
    //public static Level_Main_script obj = new Level_Main_script();
    //public static Stream stream;
    //public static BinaryFormatter formatter;

    //public static void Save()
    //{
    //    stream = File.Open("data.xml", FileMode.Create);
    //    formatter = new BinaryFormatter();

    //    formatter.Serialize(stream, obj);
    //    stream.Close();

    //    obj = null;
    //}

    //public static void Load()
    //{
    //    stream = File.Open("data.xml", FileMode.Open);
    //    formatter = new BinaryFormatter();

    //    obj = (Level_Main_script)formatter.Deserialize(stream);
    //    stream.Close();
    //    obj.Start();
    //}
    //static string savegameName = "Game";

    //public static void Save(Level_Main_script saveGame)
    //{

    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream file = File.Create("C:/Savegames/" + savegameName + ".sav"); 
    //    bf.Serialize(file, saveGame);
    //    file.Close();
    //    Debug.Log("Saved Game: " + savegameName);

    //}

    //public static void Load(string gameToLoad)
    //{
    //    BinaryFormatter bf = new BinaryFormatter();
    //    FileStream file = File.Open("C:/Savegames/" + gameToLoad + ".gd", FileMode.Open);
    //    Level_Main_script loadedGame = (Level_Main_script)bf.Deserialize(file);
    //    file.Close();
    //    Debug.Log("Loaded Game: " + savegameName);

    //}
}
