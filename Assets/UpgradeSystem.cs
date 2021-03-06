using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{

    public static bool WrathIsEnabled;
    public static bool ArcadianIsEnabled;
    public static bool AgogeIsEnabled;
    public static bool SpartaIsEnabled;
    public static bool SkiritaiIsEnabled;
    public static bool PeltastIsEnabled;
    public static bool SpringsIsEnabled;
    public static bool JointIsEnabled;
    public static bool GreekFireIsEnabled;
    public static bool ArtilleryIsEnabled;
    public static bool MoatIsEnabled;
    public static bool PitfallIsEnabled;
    public static bool SpikesIsEnabled;
    public static bool FoloiIsEnabled;
    public static bool PozzolanicIsEnabled;
    public static bool SappedIsEnabled;

    public void Start()
    {
        PlayerPrefs.SetInt("WrathActivated", (WrathIsEnabled ? 1 : 0));
        WrathIsEnabled = (PlayerPrefs.GetInt("WrathActivated") != 0);
        WrathIsEnabled = false;
        ArcadianIsEnabled = false;
        AgogeIsEnabled = false;
        SpartaIsEnabled = false;
        SkiritaiIsEnabled = false;
        PeltastIsEnabled = false;
        SpringsIsEnabled = false;
        JointIsEnabled = false;
        GreekFireIsEnabled = false;
        ArtilleryIsEnabled = false;
        MoatIsEnabled = false;
        PitfallIsEnabled = false;
        SpikesIsEnabled = false;
        FoloiIsEnabled = false;
        PozzolanicIsEnabled = false;
        SappedIsEnabled = false;
    }

    public void ActivateWrath()
    {
        WrathIsEnabled = true;


    }

    public void ActivateArcadian()
    {
        ArcadianIsEnabled = true;
    }

    public void ActivateAgoge()
    {
        AgogeIsEnabled = true;
    }

    public void ActivateSparta()
    {
        SpartaIsEnabled = true;
    }

    public void ActivateSkiritai()
    {
        SkiritaiIsEnabled = true;
    }

    public void ActivatePeltast()
    {
        PeltastIsEnabled = true;
    }

    public void ActivateSprings()
    {
        SpringsIsEnabled = true;
    }

    public void ActivateJoint()
    {
        JointIsEnabled = true;
    }

    public void ActivateGreekFire()
    {
        GreekFireIsEnabled = true;
    }

    public void ActivateArtillery()
    {
        ArtilleryIsEnabled = true;
    }

    public void ActivateMoat()
    {
        MoatIsEnabled = true;
    }

    public void ActivatePitfall()
    {
        PitfallIsEnabled = true;
    }

    public void ActivateSpikes()
    {
        SpikesIsEnabled = true;
    }

    public void ActivateFoloi()
    {
        FoloiIsEnabled = true;
    }
    public void ActivatePozzolanic()
    {
        PozzolanicIsEnabled = true;
    }

    public void ActivateSapped()
    {
        SappedIsEnabled = true;
    }

}
