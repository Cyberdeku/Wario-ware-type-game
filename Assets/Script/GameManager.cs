using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    public AudioMixerGroup SFXMixer;
    public AudioMixerGroup MusicMixer;
    [SerializeField] AudioClip gameScorePlus;
    [SerializeField] AudioClip gameLifeLost;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] AudioClip winGameEnded;
    [SerializeField] AudioClip DeathSoundtrack;
    [SerializeField] AudioClip WinSoundtrack;
    [SerializeField] AudioSource SFXPlayer;
    [SerializeField] AudioSource MusicPlayer;
    public Image lifeImage;
    public GameObject UI;
    public List<MiniGame> gameList;
    private MiniGame currentGame;
    private ObstacleGenerator obstacleGenerator;

    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI lifetext;
    public int score = 0;
    [SerializeField]
    int life = 3;
    float basetimer = 10f;
    int index;

    public Canvas deathScreen;
    public Canvas winScreen;
    public GameObject psVita;
    public SpriteRenderer psVitaSprite;
    public GameObject explosionPrefab;


    bool isDeathStarted = false;

    public int score4boss;
    public GameObject BossLevel;
    bool bossLaunch = false;
    public GameObject FinalCutsceneCharacters;
    public BossAttack bossAttack;
    public PlayableDirector director;

    private void OnEnable()
    {
        director.stopped += OnDirectorEnded;
    }
    private void Start()
    {
        
        gameList.Shuffle();

        currentGame = gameList[index];
        foreach(MiniGame game in gameList)
        {
            print(game.name);
            game.GameOver += switchGame /*(win) => StartCoroutine(WaitSwitch(win))*/;
            
        }
        currentGame.gameObject.SetActive(true);
    }

    private void Update()
    {

        lifeImage.fillAmount = life / 3f;

        scoretext.text = "Nv." + score.ToString() + "/" + score4boss.ToString();
        lifetext.text = life.ToString();

        if(life <= 0 )
        {
            if (!isDeathStarted)
            {
                StartCoroutine(Death());

            }


        }

        
        if (score >= score4boss)
        {
            if(!bossLaunch)
            {
                
                StartCoroutine(BossStart());

                bossLaunch = true;
            }
            

            /*launch boss battle */
        }

        if(bossAttack.defeated== true)
        {
            LaunchCutscene();
            bossAttack.defeated = false;
        }


    }
    //ending Cutscene
    void OnDirectorEnded(PlayableDirector director)
    {
        StartCoroutine(Win());
    }

    private void switchGame(bool win)
    {

        if (win)
        {
            score++;
            AudioManager(gameScorePlus,SFXMixer);
            print("win");
            print("nextgame");
        }
        else
        {
            life--;
            AudioManager(gameLifeLost, SFXMixer);
            print("-1 life");
            print("nextgame");
        }



        print("index = "+index);

        currentGame.gameObject.SetActive(false);
        //index = ++index % gameList.Count;
        index++;
        if ( index >= gameList.Count )
        {
            index = 0;
            gameList.Shuffle();
        }
        currentGame = gameList[index];
        currentGame.gameObject.SetActive(true);

        print("index = " + index);

        currentGame.timer = basetimer - (score/10);

    }
    IEnumerator WaitSwitch(bool win)
    {
        print("I wait");
        yield return new WaitForSeconds(0.5f);
        print("I waited");
        switchGame(win);

    }


    public IEnumerator Death()
    {

        SFXPlayer.PlayOneShot(DeathSound);
        deathScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        psVita.SetActive(false);
        MusicPlayer.clip = DeathSoundtrack;
        MusicPlayer.Play();
        isDeathStarted = true;  
    }

    IEnumerator BossStart()
    {
        for (int i = 0; i < psVita.transform.childCount; i++)
        {
            print("removed ");
            psVita.transform.GetChild(i).gameObject.SetActive(false);
        }
        for(int i=0; i<25; i++)
        {
            
            Vector3 randomizePosition = new Vector3(UnityEngine.Random.Range(-15, 8.5f), UnityEngine.Random.Range(-8, 4), 0);
            Instantiate(explosionPrefab,randomizePosition,Quaternion.identity);
        }
        //Text saying you beat his minigame so now you have to fight him

        UI.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.8f);
        psVitaSprite.enabled = false;
        yield return new WaitForSeconds(0.5f);
        FinalCutsceneCharacters.SetActive(true);
        BossLevel.SetActive(true);
    }


    private void AudioManager(AudioClip clipToPlay,AudioMixerGroup audioMixerGroup)
    {
        print("a");
        GameObject soundObject = new GameObject("SoundInstance");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clipToPlay;
        audioSource.Play();
        audioSource.outputAudioMixerGroup = audioMixerGroup;
        Destroy(soundObject, clipToPlay.length);
    }
    
    private void LaunchCutscene()
    {
        director.Play();
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(1.5f);
        SFXPlayer.PlayOneShot(winGameEnded);
        winScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        BossLevel.SetActive(false);
        MusicPlayer.clip = WinSoundtrack; //change win soundtrack
        MusicPlayer.Play();

        print("the timeline ended");
    }
}
