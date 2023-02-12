using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YouDiedCountdown : MonoBehaviour
{
    [SerializeField] float time = 7f;
    
        private void Awake()
        {
            StartCoroutine(KillTheCanvas());
        }
    
        IEnumerator KillTheCanvas()
        {
            for (float i = time; i > 0; i--)
            {
                yield return new WaitForSeconds(1f);
            }
            SceneManager.LoadScene(0);
        }
}
