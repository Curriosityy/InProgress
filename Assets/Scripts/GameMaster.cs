using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    private static GameObject _gameMaster = null;

    [SerializeField]
    private AudioSource playerSource;

    [SerializeField]
    private AudioSource backgroundSource;

    public Slider BGSlider;
    public Slider FXSlider;

    public static GameObject gameMaster
    {
        get
        {
            return _gameMaster;
        }
    }

    public AudioSource PlayerSource
    {
        get
        {
            return playerSource;
        }
    }

    public AudioSource BackgroundSource
    {
        get
        {
            return backgroundSource;
        }
    }

    private void Awake()
    {
        if (_gameMaster == null)
        {
            _gameMaster = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private Camera cam;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (!PlayerPrefs.HasKey("FXValue"))
        {
            PlayerPrefs.SetFloat("FXValue", 1f);
            PlayerPrefs.Save();
        }
        if (!PlayerPrefs.HasKey("BGValue"))
        {
            PlayerPrefs.SetFloat("BGValue", 1f);
            PlayerPrefs.Save();
        }
        backgroundSource.volume = PlayerPrefs.GetFloat("BGValue");
        playerSource.volume = PlayerPrefs.GetFloat("FXValue");
        cam = Camera.main;
    }

    private void OnLevelWasLoaded(int level)
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.position = cam.transform.position;
    }
}