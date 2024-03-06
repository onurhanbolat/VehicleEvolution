using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene : MonoBehaviour
{
    public static scene Current;
    public void sifirla()
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        PlayerPrefs.DeleteAll();
    }
    public void LoadScene(string Level0)
    {
        GameObject.FindWithTag("menuSesi").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(Level0);
    }
    public void sifirlaNoSound()
    {
        PlayerPrefs.DeleteAll();
    }
    public void LoadSceneNoSound(string Level0)
    {
        SceneManager.LoadScene(Level0);
    }

}
