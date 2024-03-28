using UnityEngine;

public class GameHandler : MainHandler
{
    [SerializeField] private PlayerHandler playerHandler;
    private GameUIHandler uiGameHandler;

    void Start()
    {
        uiGameHandler = (GameUIHandler)uiHandler;
        uiGameHandler.OnChangeScene += () => { ChangeScene(0); };
        playerHandler.Weapon.OnUpdateAmmo += OnShoot;

        LoadCharacterAnimation();
    }

    private void OnShoot(int currentAmmo, int totalAmmo)
    {
        uiGameHandler.SetAmmo(currentAmmo, totalAmmo);
    }

    public void LoadCharacterAnimation()
    {
        int id = PlayerPrefs.GetInt("animationSelected", 0);

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
    }
}