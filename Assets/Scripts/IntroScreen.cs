using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScreen : MonoBehaviour
{
    public AudioManager audioManager;

    [Header("LogoScreen")]
    public Animator logoFly;
    public Animator logoFadeIn;
    public Animator logoFadeOut;

    [Header("Narrative")]
    public Animator speechBubble1;
    public GameObject speechBubble1Dialogue;
    public Animator speechBubble2;
    public GameObject speechBubble2Dialogue;
    public Animator speechBubble3;
    public GameObject speechBubble3Dialogue;
    public Animator speechBubble4;
    public GameObject speechBubble4Dialogue;
    public Animator narrativeFadeOut;

    [Header("TitleScreen")]
    public Animator titleFadeIn;
    public Animator titleModelFadeIn;
    public Animator spearFly;
    public Animator startText;

    private bool gameCanStart = false;

    void Start()
    {
        logoFly.enabled = false;
        logoFadeIn.enabled = false;
        logoFadeOut.enabled = false;

        speechBubble1.enabled = false;
        speechBubble2.enabled = false;
        speechBubble3.enabled = false;
        speechBubble4.enabled = false;
        narrativeFadeOut.enabled = false;

        titleFadeIn.enabled = false;
        titleModelFadeIn.enabled = false;
        spearFly.enabled = false;
        startText.enabled = false;

        StartCoroutine(IntroductionSequence());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }

        if(gameCanStart)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    IEnumerator IntroductionSequence()
    {
        logoFly.enabled = true;
        logoFly.Play("LogoFly");

        yield return new WaitForSeconds(0.5f);

        audioManager.Play("LogoSound");

        yield return new WaitForSeconds(1f);

        logoFadeIn.enabled = true;
        logoFadeIn.Play("LogoFadeIn");

        yield return new WaitForSeconds(2f);

        logoFadeOut.enabled = true;
        logoFadeOut.Play("LogoScreenFadeOut");

        yield return new WaitForSeconds(2f);

        speechBubble1.enabled = true;
        speechBubble1.Play("SpeechBubble1");

        yield return new WaitForSeconds(1f);

        DialogueTrigger trigger = speechBubble1Dialogue.GetComponent<DialogueTrigger>();
        trigger.TriggerDialogue();

        yield return new WaitForSeconds(4f);

        speechBubble2.enabled = true;
        speechBubble2.Play("SpeechBubble2");

        yield return new WaitForSeconds(1f);

        DialogueTrigger trigger1 = speechBubble2Dialogue.GetComponent<DialogueTrigger>();
        trigger1.TriggerDialogue();

        yield return new WaitForSeconds(6.5f);

        speechBubble3.enabled = true;
        speechBubble3.Play("SpeechBubble3");

        yield return new WaitForSeconds(1f);

        DialogueTrigger trigger2 = speechBubble3Dialogue.GetComponent<DialogueTrigger>();
        trigger2.TriggerDialogue();

        yield return new WaitForSeconds(4.5f);

        speechBubble4.enabled = true;
        speechBubble4.Play("SpeechBubble4");

        yield return new WaitForSeconds(1f);

        DialogueTrigger trigger3 = speechBubble4Dialogue.GetComponent<DialogueTrigger>();
        trigger3.TriggerDialogue();

        yield return new WaitForSeconds(8f);

        narrativeFadeOut.enabled = true;
        narrativeFadeOut.Play("NarrativeFadeOut");
        titleFadeIn.enabled = true;
        titleFadeIn.Play("TitleFadeIn");

        yield return new WaitForSeconds(2f);

        titleModelFadeIn.enabled = true;
        titleModelFadeIn.Play("TitleModelFadeIn");

        yield return new WaitForSeconds(2f);

        spearFly.enabled = true;
        spearFly.Play("SpearFly");
        audioManager.Play("MainTheme");

        yield return new WaitForSeconds(1f);

        startText.enabled = true;
        startText.Play("StartTextFadeIn");

        gameCanStart = true;
    }    
}
