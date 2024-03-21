//class Animal { }
//class Chien { }

//class Chat { }

using System;
using System.Linq;

using UnityEngine;

enum Day{    Lundi,    Mardi,    Mercredi,    Jeudi,    Vendredi,    Samedi,    Dimanche,}

enum Couleur{ blond,brun, green, yellow, blue, red, cyan, magenta, black, ginger,}

enum Typesofgames { FPS,RPG,TPS,RTS}
[Serializable]
class Pupil
{
    #region FIELDS
    public int age;
    public float height;
    public string[] Names;
    public Day birthDay;
    public Couleur[] hairColor;
    public Couleur favoriteColor;
    public int stamina = 20;
    public int mood = 20;
    public Typesofgames[] favorites;
    public int satiété = 20;
    #endregion

    #region METHODS
    public void Work()
    {
        stamina-- ;
        satiété--;

        Debug.Log(Names[0] + " worked");
    }
    public void Play(Typesofgames type)
    {
        if(favorites.Contains(type))
        {
            mood = mood + 5;

            Debug.Log(Names[0] + " played favorite game");
        }
        else
        {
            mood++;

            Debug.Log(Names[0] + " played a game");
        }

        mood = mood + 1;
        satiété--;
    }
    public void Rest()
    {
        stamina++ ;
        satiété--;


        Debug.Log(Names[0] + " rested");
    }
    #endregion
    public void Sleep()
    {
        stamina += 10;
        mood++;
        satiété = satiété - 5;

        Debug.Log(Names[0] + " sleeped");
    }

    public void Eat()
    {
        satiété = satiété + 13;

        Debug.Log(Names[0] + " ate");
    }
}


class Clavier
{

}