using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Animator sceneTransitionAnimator;
    bool _canSceneTransition = false;
    AsyncOperation async;
    void Start()
    {
        PlayTransitionAnimation();
    }

    public void PlayTransitionAnimation(){
        sceneTransitionAnimator.gameObject.SetActive(true);
        sceneTransitionAnimator.Play("MenuTransition");
        DOVirtual.DelayedCall(1f, () => {
            sceneTransitionAnimator.gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(_canSceneTransition){
            async.allowSceneActivation = true;
            _canSceneTransition = false;
        }
    }

    public void TouchShotClicked(){
        sceneTransitionAnimator.gameObject.SetActive(true);
        sceneTransitionAnimator.Play("MenuTransitionReverse");
        DOVirtual.DelayedCall(1f, () => {
            _canSceneTransition = true;
        });
        StartSceneTransition("TouchShot");
    }

    public void StartSceneTransition(string sceneName){
        StartCoroutine(SceneTransition(sceneName));    
    }

    IEnumerator SceneTransition(string sceneName){
         async = SceneManager.LoadSceneAsync(sceneName);
         async.allowSceneActivation = false;
         yield return null;
    }
    
}
