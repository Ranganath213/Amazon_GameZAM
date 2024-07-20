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
    public enum AvailableStatus
    {
        Locked = 0,
        Unlocked = 1
    }
    public enum ObjectiveStatus
    {
        D0 = 0,
        C1 = 1,
        B1 = 2,
        A1 = 3,
        A0 = 4

    }
    public enum Ads
    {
        BannerAds = 0,
        InterstialAds = 1,
        RewardAds = 2
    }

    #endregion GameMeta

    #region InGame

    public enum PlayerStatus
    {
        Alive = 0,
        Revive = 1,
        Dead = 2
    }

    public enum EnemyRobotType
    {
        Shooter=0,
        Checker=1
    }

    #endregion InGame
    #region  Inventory
    public enum ItemType
    {
        None = 0,
        Consumable = 1,
        Crafting = 2
    }
    public enum ConsumableItem
    {
        None = 0,
        HealthPortion = 1,
        SleepingDart = 2,
        TakeDown = 3,
        SmokeBomb = 4
    }
    public enum CraftingItem
    {
        None = 0,
        Sugar = 1,
        Potassion = 2,
        Carbon = 3,
        Tissue = 4,
        Syringe = 5,
        Chloroform = 6

    }
    #endregion Inventory

    #region ToolTips Inupts

    public enum ToolTips_Input
    {
        I = 0,
        E = 1,
        Esc = 2,
        Others = 3
    }

    public enum TootTips_Type
    {
        Press = 0,
        Hold = 1,
        Tap = 2
    }

    #endregion

    #region Interface

    /// <summary>
    /// The AI Prefabs whivh Uses Switch interface
    /// </summary>
    public enum ONandOff
    {
        Off = 0,
        On = 1

    }
    public enum SwitchType
    {
        General = 0,
        Door = 1,
        Laser = 2,
        Other = 100

    }

    public enum SwitchUse
    {
        Activation = 0,
        Mobility = 1,
        Acti_Mobi = 2
    }
    #endregion Interface

    #region Weapons

    public enum Weapons
    {
        None = 0,
        SmokeBomb = 1,
        SleepDart = 2,

    }

    #endregion Weapons

}
