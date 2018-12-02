using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenChanger : MonoBehaviour
{
    // Use this for initialization
    public Animator animator;

    private int levelToLoad;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void FadeToLevel(int LevelBuildIndex)
    {
        if (PlayerPrefs.GetInt("LevelReached") < LevelBuildIndex)
        {
            PlayerPrefs.SetInt("LevelReached", LevelBuildIndex);
        }
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
        animator.SetTrigger("Fade_in");
    }

    // Update is called once per frame
    private void Update()
    {
    }
}