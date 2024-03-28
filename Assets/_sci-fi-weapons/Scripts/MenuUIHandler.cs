using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIHandler : UIHandler
{
    public Action<int> OnSelectAnimation;

    public List<Button> buttonsAnimation;
    public Button buttonSelectAnimation;

   public void SelectAnimation(int id)
    {
        OnSelectAnimation?.Invoke(id);
    }
}
