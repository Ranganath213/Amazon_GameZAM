using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace GameEnum
{
    #region GameMeta
    public enum SoundType
    {
        UI_ButttonClick1,
        UI_ButtonClick2,
        UI_Collect1,
        UI_Collect2,
        UI_Win1,
        UI_Win2,
        UI_Lose1,
        UI_Lose2
    }

    public enum MusicType
    {
        Music_Mainmenu=0,
        Music_Tutorial=1,
        Music_Chapter1=2,
        Music_Chapter2=3,
        Music_Chapter3=4,
        Music_Chapter4=5,
        Music_Chapter5=6
        
        
    }
  #endregion

  public enum DayCount
  {
      Day1=0,
      Day2=1,
      Day3=2,
      Day4=3,
      Day5=4
  }

}
