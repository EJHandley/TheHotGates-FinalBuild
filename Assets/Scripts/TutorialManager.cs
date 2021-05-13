using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public Spawner spawner;

    public GameObject tutorial;
    public GameObject narrative;

    [Header("Leonidas Dialogue")]
    public Animator leonidasDialogue;
    public GameObject _leonidasDialogue;

    [Header("Jen Dialogue")]
    public Animator jenDialogue;
    public GameObject _jenDialogue;

    [Header("Papa Dialogue")]
    public Animator papaDialogue;
    public GameObject _papaDialogue;

    [Header("Continues")]
    public GameObject continue1;

    [Header("Tutorial Screens")]
    public GameObject firstTutScreen;
    public GameObject secondTutScreen;
    public GameObject thirdTutScreen;

    private bool firstTutOver = false;
    private bool secondTutOver = false;
    private bool thirdTutOver = false;

    private bool secondTutStarted = false;
    private bool thirdTutStarted = false;
    private bool specialTutStarted = false;

    private void Start()
    {
        leonidasDialogue.enabled = false;
        jenDialogue.enabled = false;
        papaDialogue.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && narrative.activeSelf == false || Input.GetKeyDown(KeyCode.KeypadEnter) && narrative.activeSelf == false)
        {
            tutorial.SetActive(false);
        }

        if (spawner.nextWave == 1 && firstTutOver && !secondTutStarted)
        {
            StartSecondTutorial();
        }

        if (spawner.nextWave == 2 && firstTutOver && secondTutOver && !thirdTutStarted)
        {
            StartThirdTutorial();
        }

        if (!spawner.waveStarted && firstTutOver && secondTutOver && thirdTutOver && !specialTutStarted)
        {
            StartSpecialTutorial();
        }


    }
    public void StartLeonidasDialogue()
    {
        StartCoroutine(LeonidasDialogue());
    }    

    IEnumerator LeonidasDialogue()
    {
        leonidasDialogue.enabled = true;
        leonidasDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueTrigger _trigger = _leonidasDialogue.GetComponent<DialogueTrigger>();
        _trigger.TriggerDialogue();

        yield return new WaitForSeconds(2f);

        continue1.SetActive(true);
    }

    public void StartTutorial()
    {
        StartCoroutine(MainTutorial());
    }

    IEnumerator MainTutorial()
    {
        firstTutScreen.SetActive(true);

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        firstTutScreen.SetActive(false);
        secondTutScreen.SetActive(true);

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        secondTutScreen.SetActive(false);
        thirdTutScreen.SetActive(true);

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        thirdTutScreen.SetActive(false);
        StartFirstDialogue();
    }

    public void StartFirstDialogue()
    {
        StartCoroutine(FirstDialogue());
    }

    IEnumerator FirstDialogue()
    {
        leonidasDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueManager _nextSentence = _leonidasDialogue.GetComponent<DialogueManager>();
        _nextSentence.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        jenDialogue.enabled = true;
        jenDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueTrigger trigger = jenDialogue.GetComponent<DialogueTrigger>();
        trigger.TriggerDialogue();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        papaDialogue.enabled = true;
        papaDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueTrigger trigger1 = papaDialogue.GetComponent<DialogueTrigger>();
        trigger1.TriggerDialogue();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        DialogueManager jenNext = _jenDialogue.GetComponent<DialogueManager>();
        jenNext.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        DialogueManager papaNext = _papaDialogue.GetComponent<DialogueManager>();
        papaNext.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        jenNext.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        papaNext.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        papaNext.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        leonidasDialogue.Play("TutDialogueFadeOut");
        jenDialogue.Play("TutDialogueFadeOut");
        papaDialogue.Play("TutDialogueFadeOut");
        firstTutOver = true;

        yield return new WaitForSeconds(1f);

        StopCoroutine(FirstDialogue());
    }

    public void StartSecondTutorial()
    {
        StartCoroutine(SecondTutorial());
    }    

    IEnumerator SecondTutorial()
    {
        secondTutStarted = true;
        leonidasDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueManager _nextSentence = _leonidasDialogue.GetComponent<DialogueManager>();
        _nextSentence.DisplaySentence();

        yield return new WaitForSeconds(3f);

        jenDialogue.enabled = true;
        jenDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueManager jenNext = _jenDialogue.GetComponent<DialogueManager>();
        jenNext.DisplaySentence();

        yield return new WaitForSeconds(2f);

        papaDialogue.enabled = true;
        papaDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueManager papaNext = _papaDialogue.GetComponent<DialogueManager>();
        papaNext.DisplaySentence();

        yield return new WaitForSeconds(6f);

        leonidasDialogue.Play("TutDialogueFadeOut");
        jenDialogue.Play("TutDialogueFadeOut");
        papaDialogue.Play("TutDialogueFadeOut");
        secondTutOver = true;

        yield return new WaitForSeconds(1f);

        StopCoroutine(SecondTutorial());
    }

    public void StartThirdTutorial()
    {
        StartCoroutine(ThirdTutorial());
    }

    IEnumerator ThirdTutorial()
    {
        thirdTutStarted = true;
        leonidasDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueManager _nextSentence = _leonidasDialogue.GetComponent<DialogueManager>();
        _nextSentence.DisplaySentence();

        yield return new WaitForSeconds(3f);

        jenDialogue.enabled = true;
        jenDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueManager jenNext = _jenDialogue.GetComponent<DialogueManager>();
        jenNext.DisplaySentence();

        yield return new WaitForSeconds(2f);

        papaDialogue.enabled = true;
        papaDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueManager papaNext = _papaDialogue.GetComponent<DialogueManager>();
        papaNext.DisplaySentence();

        yield return new WaitForSeconds(8f);

        leonidasDialogue.Play("TutDialogueFadeOut");
        jenDialogue.Play("TutDialogueFadeOut");
        papaDialogue.Play("TutDialogueFadeOut");
        thirdTutOver = true;

        yield return new WaitForSeconds(1f);

        StopCoroutine(ThirdTutorial());
    }

    public void StartSpecialTutorial()
    {
        StartCoroutine(SpecialTutorial());
    }    

    IEnumerator SpecialTutorial()
    {
        specialTutStarted = true;
        leonidasDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueManager _nextSentence = _leonidasDialogue.GetComponent<DialogueManager>();
        _nextSentence.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        _nextSentence.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        jenDialogue.enabled = true;
        jenDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueManager jenNext = _jenDialogue.GetComponent<DialogueManager>();
        jenNext.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        papaDialogue.enabled = true;
        papaDialogue.Play("TutDialogueFadeIn");

        yield return new WaitForSeconds(1f);

        DialogueManager papaNext = _papaDialogue.GetComponent<DialogueManager>();
        papaNext.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        jenNext.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        papaNext.DisplaySentence();

        yield return null;

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        leonidasDialogue.Play("TutDialogueFadeOut");
        jenDialogue.Play("TutDialogueFadeOut");
        papaDialogue.Play("TutDialogueFadeOut");

        yield return new WaitForSeconds(1f);

        StopCoroutine(SpecialTutorial());
    }
}
