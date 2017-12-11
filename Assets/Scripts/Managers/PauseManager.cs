using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour
{
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    public Canvas changeLevelCanvas;

    private Canvas canvas;
    
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = !canvas.enabled;
            if (changeLevelCanvas.enabled)
            {
                changeLevelCanvas.enabled = false;
            }
            else
            {
                Pause();
            }
        }
    }
    
    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Lowpass();
    }
    
    public void ToggleChangeLevelMenu(bool flag)
    {
        changeLevelCanvas.enabled = flag;
        canvas.enabled = !flag;
    }

    public void LoadLevel(string levelName)
    {
        Pause();
        SceneManager.LoadScene(levelName);
    }

    void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(0.01f);
        }
        else
        {
            unpaused.TransitionTo(0.01f);
        }
    }
    
    public void Quit()
    {
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else 
        Application.Quit();
        #endif
    }
}
