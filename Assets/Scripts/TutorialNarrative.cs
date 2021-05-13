using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNarrative : MonoBehaviour
{
    public TutorialManager tutorial;

    [Header("First Narrative Screen")]
    public Animator firstSpeechBubble;
    public GameObject firstDialogue;
    public Animator secondSpeechBubble;
    public GameObject secondDialogue;
    public Animator thirdSpeechBubble;
    public GameObject thirdDialogue;
    public Animator fourthSpeechBubble;
    public GameObject fourthDialogue;
    public Animator firstFadeOut;

    [Header("Second Narrative Screen")]
    public Animator _firstSpeechBubble;
    public GameObject _firstDialogue;
    public Animator _secondSpeechBubble;
    public GameObject _secondDialogue;
    public Animator _thirdSpeechBubble;
    public GameObject _thirdDialogue;
    public Animator _fourthSpeechBubble;
    public GameObject _fourthDialogue;
    public Animator secondFadeOut;

    [Header("Third Narrative Screen")]
    public Animator speechBubble;
    public GameObject finalDialogue;
    public Animator narrativeFadeOut;

    public GameObject narrativeCanvas;

    private void Start()
    {
        firstSpeechBubble.enabled = false;
        secondSpeechBubble.enabled = false;
        thirdSpeechBubble.enabled = false;
        fourthSpeechBubble.enabled = false;

        firstFadeOut.enabled = false;

        _firstSpeechBubble.enabled = false;
        _secondSpeechBubble.enabled = false;
        _thirdSpeechBubble.enabled = false;
        _fourthSpeechBubble.enabled = false;

        secondFadeOut.enabled = false;

        speechBubble.enabled = false;
        narrativeFadeOut.enabled = false;

        StartCoroutine(PlayTutorialNarrative());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            tutorial.StartLeonidasDialogue();
            narrativeCanvas.SetActive(false);
        }
    }

    IEnumerator PlayTutorialNarrative()
    {
        firstSpeechBubble.enabled = true;
        firstSpeechBubble.Play("SpeechBubbleLeft");

        yield return new WaitForSeconds(1f);

        DialogueTrigger trigger1 = firstDialogue.GetComponent<DialogueTrigger>();
        trigger1.TriggerDialogue();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        secondSpeechBubble.enabled = true;
        secondSpeechBubble.Play("SpeechBubbleRight");

        yield return new WaitForSeconds(1f);

        DialogueTrigger trigger2 = secondDialogue.GetComponent<DialogueTrigger>();
        trigger2.TriggerDialogue();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        thirdSpeechBubble.enabled = true;
        thirdSpeechBubble.Play("SpeechBubbleLeft");

        yield return new WaitForSeconds(1f);

        DialogueTrigger trigger3 = thirdDialogue.GetComponent<DialogueTrigger>();
        trigger3.TriggerDialogue();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        fourthSpeechBubble.enabled = true;
        fourthSpeechBubble.Play("SpeechBubbleRight");

        yield return new WaitForSeconds(1f);

        DialogueTrigger trigger4 = fourthDialogue.GetComponent<DialogueTrigger>();
        trigger4.TriggerDialogue();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        firstFadeOut.enabled = true;
        firstFadeOut.Play("NarrativeFadeOut");

        yield return new WaitForSeconds(2f);

        //NEXT CANVAS

        _firstSpeechBubble.enabled = true;
        _firstSpeechBubble.Play("SpeechBubbleLeft");

        yield return new WaitForSeconds(1f);

        DialogueTrigger _trigger1 = _firstDialogue.GetComponent<DialogueTrigger>();
        _trigger1.TriggerDialogue();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        _secondSpeechBubble.enabled = true;
        _secondSpeechBubble.Play("SpeechBubbleRight");

        yield return new WaitForSeconds(1f);

        DialogueTrigger _trigger2 = _secondDialogue.GetComponent<DialogueTrigger>();
        _trigger2.TriggerDialogue();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        _thirdSpeechBubble.enabled = true;
        _thirdSpeechBubble.Play("SpeechBubbleLeft");

        yield return new WaitForSeconds(1f);

        DialogueTrigger _trigger3 = _thirdDialogue.GetComponent<DialogueTrigger>();
        _trigger3.TriggerDialogue();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        _fourthSpeechBubble.enabled = true;
        _fourthSpeechBubble.Play("SpeechBubbleRight");

        yield return new WaitForSeconds(1f);

        DialogueTrigger _trigger4 = _fourthDialogue.GetComponent<DialogueTrigger>();
        _trigger4.TriggerDialogue();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        secondFadeOut.enabled = true;
        secondFadeOut.Play("NarrativeFadeOut");

        yield return new WaitForSeconds(2f);

        //NEXT CANVAS

        speechBubble.enabled = true;
        speechBubble.Play("SpeechBubbleCentre");

        yield return new WaitForSeconds(1f);

        DialogueTrigger finalTrigger = finalDialogue.GetComponent<DialogueTrigger>();
        finalTrigger.TriggerDialogue();

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        narrativeFadeOut.enabled = true;
        narrativeFadeOut.Play("NarrativeFadeOut");

        yield return new WaitForSeconds(3f);

        tutorial.StartLeonidasDialogue();
        narrativeCanvas.SetActive(false);
    }
}
