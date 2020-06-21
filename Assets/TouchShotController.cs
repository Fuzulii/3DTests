using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TouchShotController : MonoBehaviour
{
    public Animator sceneTransitionAnimator;
    bool _canSceneTransition = false;
    AsyncOperation async;
    void Start()
    {
        PlayTransitionAnimation();
    }

    void Update()
    {
        if(_canSceneTransition){
            async.allowSceneActivation = true;
            _canSceneTransition = false;
        }
    }

    public void PlayTransitionAnimation(){
        sceneTransitionAnimator.gameObject.SetActive(true);
        sceneTransitionAnimator.Play("MenuTransition");
        DOVirtual.DelayedCall(1f, () => {
            sceneTransitionAnimator.gameObject.SetActive(false);
        });
    }

    public void ResetClicked(){
        sceneTransitionAnimator.gameObject.SetActive(true);
        sceneTransitionAnimator.Play("MenuTransitionReverse");
        DOVirtual.DelayedCall(1f, () => {
            _canSceneTransition = true;
        });
        StartSceneTransition("TouchShot");
    }

    public void MainMenuClicked(){
        sceneTransitionAnimator.gameObject.SetActive(true);
        sceneTransitionAnimator.Play("MenuTransitionReverse");
        DOVirtual.DelayedCall(1f, () => {
            _canSceneTransition = true;
        });
        StartSceneTransition("MainMenu");
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
