using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public float healt;
    public float maxHealth;
    //public int lives = 3;

    private void Awake()
    {
        healt = maxHealth;
    }

    void Update()
    {
        checkHealth();
    }

    //private void kill()
    //{
    //    if(healt == 0)
    //    {
    //        SceneManager.LoadSceneAsync(2);
    //    }
    //}

    private void checkHealth()
    {
        //healt = maxHealth;
        //if (healt <= 0)
        //{
        //    lives--;
        //    if (lives > 0)
        //    {
        //        healt = maxHealth;
        //    }
        //    else
        //    {
        //        //SceneManager.LoadSceneAsync(2);
        //        StartCoroutine(WaitBeforeSceneChange());
        //    }
        //}
    }

    //private IEnumerator WaitBeforeSceneChange()
    //{
    //    yield return new WaitForSeconds(2.0f);
    //    SceneManager.LoadSceneAsync(2);
    //}
}
