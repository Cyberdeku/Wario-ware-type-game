using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EDH : MonoBehaviour
{
    [SerializeField] List<Pupil> pupils;
    [SerializeField] float frequency = 1f;
    float t = 0;
    int i = 0;

    void FixedUpdate()
    {
        t -= Time.fixedDeltaTime;
        if (t > 0)
            return;

        t = frequency;
        

        print("-----------------------------" +"day " + i+ "-----------------------------");
        foreach (var e in pupils)
        {
            if (Random.Range(0, 10) <= 1)
                e.Work();
            else
                e.Play(getRandomTypeVideoGame());
        }
        foreach (var e in pupils)
        {
            int number = Random.Range(0, 3);
            if (number == 0)
                e.Eat();
            else if (number == 1)
                e.Sleep();
            else
                e.Rest();
        }

        List<Pupil> elevesPerdu = new();
        foreach (var e in pupils)
        {


            Debug.Log(e.Names[0] + " stamina = " + e.stamina + " satiété =  " + e.satiété + " mood = " + e.mood ) ;

            if (e.satiété <= 0 || e.stamina <= 0)
                elevesPerdu.Add(e);




            if (pupils.Count == 1)
            {
                print(e.Names[0] + " win");
                print("party ended");
                Time.timeScale = 0;
            }
        }

        foreach (var e in elevesPerdu)
        {
            Debug.LogError(e.Names[0] + " a perdu");
           pupils.Remove(e);
        }
        i++;

        if(pupils.Count == 0 )
        {
            print("party ended");
            Time.timeScale = 0;

        }
    }

    Typesofgames getRandomTypeVideoGame()
    {
        return (Typesofgames)Random.Range(0, 4);
    }
}
