using UnityEngine;

public class MenuHandler : MainHandler
{
    private void Start()
    {
        MenuUIHandler menuUIHandler = (MenuUIHandler)uiHandler;
        menuUIHandler.OnSelectAnimation += SelectCharacterAnimation;
        menuUIHandler.OnChangeScene += ()=> { ChangeScene(1); };
    }

    private void OnDestroy()
    {
        MenuUIHandler menuUIHandler = (MenuUIHandler)uiHandler;
        menuUIHandler.OnSelectAnimation -= SelectCharacterAnimation;
        menuUIHandler.OnChangeScene -= () => { ChangeScene(1); };
    }

    public void SelectCharacterAnimation(int id)
    {
        switch (id)
        {
            case 0:
                _animator.SetTrigger("house");
                break;
            case 1:
                _animator.SetTrigger("macarena");
                break;
            case 2:
                _animator.SetTrigger("hiphop");
                break;
        }

        PlayerPrefs.SetInt("animationSelected", id);
    }
}