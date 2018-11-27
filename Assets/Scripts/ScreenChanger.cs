using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChanger : MonoBehaviour
{
    private static GameObject _gameMaster = null;

    public static GameObject gameMaster
    {
        get
        {
            return _gameMaster;
        }
    }

    // Use this for initialization
    public Animator animator;

    private int levelToLoad;

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

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void FadeToLevel(int LevelBuildIndex)
    {
        levelToLoad = LevelBuildIndex;
        animator.SetTrigger("Fade_out");
    }

    public void FadeToNextLevel()
    {
        levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        animator.SetTrigger("Fade_out");
    }

    public void OnFadeEnd()
    {
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Single);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level != 0)
        {
            animator.SetTrigger("Fade_in");
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}