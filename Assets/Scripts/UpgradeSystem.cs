using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSystem : MonoBehaviour
{
    private int isTrue = 1;
    private int isFalse = 0;

    [Header("Special Currency Economy")]
    public TMP_Text specialCurrencyCounterText;

    #region Upgrade Costs
    private int wrathUpgradeCost = 1;
    private int arcadianUpgradeCost = 1;
    private int agogeUpgradeCost = 2;
    private int spartaUpgradeCost = 2;
    private int skiritaiUpgradeCost = 2;
    private int peltastUpgradeCost = 2;
    private int springsUpgradeCost = 3;
    private int jointUpgradeCost = 3;
    private int greekFireUpgradeCost = 3;
    private int artilleryUpgradeCost = 3;
    private int moatUpgradeCost = 1;
    private int pitfallUpgradeCost = 1;
    private int spikesUpgradeCost = 2;
    private int foloiUpgradeCost = 2;
    private int pozzolanicUpgradeCost = 3;
    private int sappedUpgradeCost = 3;
    #endregion

    #region Upgrade Bools
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
    #endregion

    #region Button References
    [Header("Upgrade Bools")]
    public Button wrathButton;
    public Button arcadianButton;
    public Button agogeButton;
    public Button spartaButton;
    public Button skiritaiButton;
    public Button peltastButton;
    public Button springsButton;
    public Button jointButton;
    public Button greekFireButton;
    public Button artilleryButton;
    public Button moatButton;
    public Button pitfallButton;
    public Button spikesButton;
    public Button foloiButton;
    public Button pozzolanicButton;
    public Button sappedButton;
    #endregion

    public void Start()
    {
        #region Arcadian Spearman PlayerPref References
        int wrathActivated = PlayerPrefs.GetInt("WrathActivated", isFalse);
        if (wrathActivated == isTrue)
        {
            WrathIsEnabled = true;
        }
        else
        {
            WrathIsEnabled = false;
        }

        int arcadianActivated = PlayerPrefs.GetInt("ArcadianActivated", isFalse);
        if (arcadianActivated == isTrue)
        {
            ArcadianIsEnabled = true;
        }
        else
        {
            ArcadianIsEnabled = false;
        }
        #endregion

        #region Spartan Hoplites PlayerPref References
        int agogeActivated = PlayerPrefs.GetInt("AgogeActivated", isFalse);
        if (agogeActivated == isTrue)
        {
            AgogeIsEnabled = true;
        }
        else
        {
            AgogeIsEnabled = false;
        }

        int spartaActivated = PlayerPrefs.GetInt("ForSpartaActivated", isFalse);
        if (spartaActivated == isTrue)
        {
            SpartaIsEnabled = true;
        }
        else
        {
            SpartaIsEnabled = false;
        }
        #endregion

        #region Helot Archers PlayerPref References
        int skiritaiActivated = PlayerPrefs.GetInt("SkiritaiActivated", isFalse);
        if (skiritaiActivated == isTrue)
        {
            SkiritaiIsEnabled = true;
        }
        else
        {
            SkiritaiIsEnabled = false;
        }

        int peltastActivated = PlayerPrefs.GetInt("PeltastActivated", isFalse);
        if (peltastActivated == isTrue)
        {
            PeltastIsEnabled = true;
        }
        else
        {
            PeltastIsEnabled = false;
        }
        #endregion

        #region Ballistae PlayerPref References
        int springsActivated = PlayerPrefs.GetInt("SpringsActivated", isFalse);
        if (springsActivated == isTrue)
        {
            SpringsIsEnabled = true;
        }
        else
        {
            SpringsIsEnabled = false;
        }

        int jointActivated = PlayerPrefs.GetInt("JointActivated", isFalse);
        if (jointActivated == isTrue)
        {
            JointIsEnabled = true;
        }
        else
        {
            JointIsEnabled = false;
        }
        #endregion

        #region Catapult PlayerPref References
        int greekFireActivated = PlayerPrefs.GetInt("GreekFireActivated", isFalse);
        if (greekFireActivated == isTrue)
        {
            GreekFireIsEnabled = true;
        }
        else
        {
            GreekFireIsEnabled = false;
        }

        int artilleryActivated = PlayerPrefs.GetInt("AtilleryActivated", isFalse);
        if (artilleryActivated == isTrue)
        {
            ArtilleryIsEnabled = true;
        }
        else
        {
            ArtilleryIsEnabled = false;
        }
        #endregion

        #region Ditches PlayerPref References
        int moatActivated = PlayerPrefs.GetInt("MoatActivated", isFalse);
        if (moatActivated == isTrue)
        {
            MoatIsEnabled = true;
        }
        else
        {
            MoatIsEnabled = false;
        }

        int pitfallActivated = PlayerPrefs.GetInt("PitfallActivated", isFalse);
        if (pitfallActivated == isTrue)
        {
            PitfallIsEnabled = true;
        }
        else
        {
            PitfallIsEnabled = false;
        }
        #endregion

        #region Wooden Wall PlayerPref References
        int spikesActivated = PlayerPrefs.GetInt("SpikesActivated", isFalse);
        if (spikesActivated == isTrue)
        {
            SpikesIsEnabled = true;
        }
        else
        {
            SpikesIsEnabled = false;
        }

        int foloiActivated = PlayerPrefs.GetInt("FoloiActivated", isFalse);
        if (foloiActivated == isTrue)
        {
            FoloiIsEnabled = true;
        }
        else
        {
            FoloiIsEnabled = false;
        }
        #endregion

        #region Stone Wall PlayerPref References
        int pozzolanicActivated = PlayerPrefs.GetInt("PozzolanicActivated", isFalse);
        if (pozzolanicActivated == isTrue)
        {
            PozzolanicIsEnabled = true;
        }
        else
        {
            PozzolanicIsEnabled = false;
        }

        int sappedActivated = PlayerPrefs.GetInt("SappedActivated", isFalse);
        if (sappedActivated == isTrue)
        {
            SappedIsEnabled = true;
        }
        else
        {
            SappedIsEnabled = false;
        }
        #endregion
    }

    public void Update()
    {
        #region Arcadian Spearman Button Updates
        if (WrathIsEnabled && !ArcadianIsEnabled || ArcadianIsEnabled && !WrathIsEnabled)
        {
            wrathButton.interactable = false;
            arcadianButton.interactable = false;
        }
        else
        {
            wrathButton.interactable = true;
            arcadianButton.interactable = true;
        }
        #endregion

        #region Spartan Hoplites Button Updates
        if (AgogeIsEnabled && !SpartaIsEnabled || SpartaIsEnabled && !AgogeIsEnabled)
        {
            agogeButton.interactable = false;
            spartaButton.interactable = false;
        }
        else
        {
            agogeButton.interactable = true;
            spartaButton.interactable = true;
        }
        #endregion

        #region Helot Archers Button Updates
        if (SkiritaiIsEnabled && !PeltastIsEnabled || PeltastIsEnabled && !SkiritaiIsEnabled)
        {
            skiritaiButton.interactable = false;
            peltastButton.interactable = false;
        }
        else
        {
            skiritaiButton.interactable = true;
            peltastButton.interactable = true;
        }
        #endregion

        #region Ballistae Button Updates
        if (SpringsIsEnabled && !JointIsEnabled || JointIsEnabled && !SpringsIsEnabled)
        {
            springsButton.interactable = false;
            jointButton.interactable = false;
        }
        else
        {
            springsButton.interactable = true;
            jointButton.interactable = true;
        }
        #endregion

        #region Catapult Button Updates
        if (GreekFireIsEnabled && !ArtilleryIsEnabled || ArtilleryIsEnabled && !GreekFireIsEnabled)
        {
            greekFireButton.interactable = false;
            artilleryButton.interactable = false;
        }
        else
        {
            greekFireButton.interactable = true;
            artilleryButton.interactable = true;
        }
        #endregion

        #region Ditches Button Updates
        if (MoatIsEnabled && !PitfallIsEnabled || PitfallIsEnabled && !MoatIsEnabled)
        {
            moatButton.interactable = false;
            pitfallButton.interactable = false;
        }
        else
        {
            moatButton.interactable = true;
            pitfallButton.interactable = true;
        }
        #endregion

        #region Wooden Wall Button Updates
        if (SpikesIsEnabled && !FoloiIsEnabled || FoloiIsEnabled && !SpikesIsEnabled)
        {
            spikesButton.interactable = false;
            foloiButton.interactable = false;
        }
        else
        {
            spikesButton.interactable = true;
            foloiButton.interactable = true;
        }
        #endregion

        #region Stone Wall Button Updates
        if (PozzolanicIsEnabled && !SappedIsEnabled || SappedIsEnabled && !PozzolanicIsEnabled)
        {
            pozzolanicButton.interactable = false;
            sappedButton.interactable = false;
        }
        else
        {
            pozzolanicButton.interactable = true;
            sappedButton.interactable = true;
        }
        #endregion

        PlayerStats.SpecialCurrency = PlayerPrefs.GetInt("SpecialCurrency");
        specialCurrencyCounterText.text = Mathf.Round(PlayerStats.SpecialCurrency) + "";

        // Temporary Input to Test Econ
        if(Input.GetKeyDown("space"))
        {
            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") + 1);
        }
        if(Input.GetKeyDown("e"))
        {
            PlayerPrefs.SetInt("SpecialCurrency", 0);
        }
    }

    #region Arcadian Spearman Upgrade Methods
    public void ActivateWrath()
    {
        if(wrathUpgradeCost <= PlayerStats.SpecialCurrency)
        {
            WrathIsEnabled = true;
            PlayerPrefs.SetInt("WrathActivated", 1);
            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - wrathUpgradeCost);
        }
    }

    public void ActivateArcadian()
    {
        if (arcadianUpgradeCost <= PlayerStats.SpecialCurrency)
        {
            ArcadianIsEnabled = true;
            PlayerPrefs.SetInt("ArcadianActivated", 1);
            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - arcadianUpgradeCost);
        }
    }

    public void ResetArcadianUpgrades()
    {
        if (WrathIsEnabled || ArcadianIsEnabled)
        {
            PlayerPrefs.SetInt("WrathActivated", 0);
            WrathIsEnabled = false;

            PlayerPrefs.SetInt("ArcadianActivated", 0);
            ArcadianIsEnabled = false;

            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") + 1);
        }
    }
    #endregion

    #region Spartan Hoplites Upgrade Methods
    public void ActivateAgoge()
    {
        if (agogeUpgradeCost <= PlayerStats.SpecialCurrency)
        {
            AgogeIsEnabled = true;
            PlayerPrefs.SetInt("AgogeActivated", 1);
            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - agogeUpgradeCost);
        }
    }

    public void ActivateSparta()
    {
        if (spartaUpgradeCost <= PlayerStats.SpecialCurrency)
        {
            SpartaIsEnabled = true;
            PlayerPrefs.SetInt("ForSpartaActivated", 1);
            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - spartaUpgradeCost);
        }
    }

    public void ResetSpartanUpgrades()
    {
        if (AgogeIsEnabled || SpartaIsEnabled)
        {
            PlayerPrefs.SetInt("AgogeActivated", 0);
            AgogeIsEnabled = false;

            PlayerPrefs.SetInt("ForSpartaActivated", 0);
            SpartaIsEnabled = false;

            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") + 2);
        }
    }
    #endregion

    #region Helot Archers Upgrade Methods
    public void ActivateSkiritai()
    {
        SkiritaiIsEnabled = true;
        PlayerPrefs.SetInt("SkiritaiActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - skiritaiUpgradeCost);
    }

    public void ActivatePeltast()
    {
        PeltastIsEnabled = true;
        PlayerPrefs.SetInt("PeltastActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - peltastUpgradeCost);
    }

    public void ResetHelotUpgrades()
    {
        if (SkiritaiIsEnabled || PeltastIsEnabled)
        {
            PlayerPrefs.SetInt("SkiritaiActivated", 0);
            SkiritaiIsEnabled = false;

            PlayerPrefs.SetInt("PeltastActivated", 0);
            PeltastIsEnabled = false;

            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") + 2);
        }
    }
    #endregion

    #region Ballisate Upgrade Methods
    public void ActivateSprings()
    {
        SpringsIsEnabled = true;
        PlayerPrefs.SetInt("SpringsActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - springsUpgradeCost);
    }

    public void ActivateJoint()
    {
        JointIsEnabled = true;
        PlayerPrefs.SetInt("JointActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - jointUpgradeCost);
    }

    public void ResetBallistaeUpgrades()
    {
        if (SpringsIsEnabled || JointIsEnabled)
        {
            PlayerPrefs.SetInt("SpringsActivated", 0);
            SpringsIsEnabled = false;

            PlayerPrefs.SetInt("JointActivated", 0);
            JointIsEnabled = false;

            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") + 3);
        }
    }
    #endregion

    #region Catapult Upgrade Methods
    public void ActivateGreekFire()
    {
        GreekFireIsEnabled = true;
        PlayerPrefs.SetInt("GreekFireActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - greekFireUpgradeCost);
    }

    public void ActivateArtillery()
    {
        ArtilleryIsEnabled = true;
        PlayerPrefs.SetInt("ArtilleryActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - artilleryUpgradeCost);
    }

    public void ResetCatapultUpgrades()
    {
        if (GreekFireIsEnabled || ArtilleryIsEnabled)
        {
            PlayerPrefs.SetInt("GreekFireActivated", 0);
            GreekFireIsEnabled = false;

            PlayerPrefs.SetInt("ArtilleryActivated", 0);
            ArtilleryIsEnabled = false;

            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") + 3);
        }
    }
    #endregion

    #region Ditches Upgrade Methods
    public void ActivateMoat()
    {
        MoatIsEnabled = true;
        PlayerPrefs.SetInt("MoatActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - moatUpgradeCost);
    }

    public void ActivatePitfall()
    {
        PitfallIsEnabled = true;
        PlayerPrefs.SetInt("PitfallActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - pitfallUpgradeCost);
    }

    public void ResetDitchUpgrades()
    {
        if (MoatIsEnabled || PitfallIsEnabled)
        {
            PlayerPrefs.SetInt("MoatActivated", 0);
            MoatIsEnabled = false;

            PlayerPrefs.SetInt("PitfallActivated", 0);
            PitfallIsEnabled = false;

            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") + 1);
        }
    }
    #endregion

    #region Wooden Wall Upgrade Methods
    public void ActivateSpikes()
    {
        SpikesIsEnabled = true;
        PlayerPrefs.SetInt("SpikesActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - spikesUpgradeCost);
    }

    public void ActivateFoloi()
    {
        FoloiIsEnabled = true;
        PlayerPrefs.SetInt("FoloiActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - foloiUpgradeCost);
    }

    public void ResetWoodenWallUpgrades()
    {
        if (SpikesIsEnabled || FoloiIsEnabled)
        {
            PlayerPrefs.SetInt("SpikesActivated", 0);
            SpikesIsEnabled = false;

            PlayerPrefs.SetInt("FoloiActivated", 0);
            FoloiIsEnabled = false;

            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") + 2);
        }
    }
    #endregion

    #region Stone Wall Upgrade Methods
    public void ActivatePozzolanic()
    {
        PozzolanicIsEnabled = true;
        PlayerPrefs.SetInt("PozzolanicActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - pozzolanicUpgradeCost);
    }

    public void ActivateSapped()
    {
        SappedIsEnabled = true;
        PlayerPrefs.SetInt("SappedActivated", 1);
        PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") - sappedUpgradeCost);
    }

    public void ResetStoneWallUpgrades()
    {
        if (PozzolanicIsEnabled || SappedIsEnabled)
        {
            PlayerPrefs.SetInt("PozzolanicActivated", 0);
            PozzolanicIsEnabled = false;

            PlayerPrefs.SetInt("SappedActivated", 0);
            SappedIsEnabled = false;

            PlayerPrefs.SetInt("SpecialCurrency", PlayerPrefs.GetInt("SpecialCurrency") + 3);
        }
    }
    #endregion

    #region Reset All Upgrades Method
    public void ResetAllUpgrades()
    {
        ResetArcadianUpgrades();
        ResetSpartanUpgrades();
        ResetHelotUpgrades();
        ResetBallistaeUpgrades();
        ResetCatapultUpgrades();
        ResetDitchUpgrades();
        ResetWoodenWallUpgrades();
        ResetStoneWallUpgrades();
    }
    #endregion
}