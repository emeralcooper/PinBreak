using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlock : Block
{
    [SerializeField] Vector2 visibilityRangeInSecs = new Vector2(3,3);
    [SerializeField] Vector2 invisibiltyRangeInSecs = new Vector2(3,3);

    BoxCollider2D myBoxCollider2D;
    SpriteRenderer mySpriteRenderer;

    private bool flashingStarted;

    private void Start()
    {
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!flashingStarted)
        {
            StartBlockFlashing();
            flashingStarted = true;
        }
    }

    private void StartBlockFlashing()
    {
        StartCoroutine(DisableBlock());
    }

    private IEnumerator EnableBlock()
    {

        myBoxCollider2D.enabled = true;
        mySpriteRenderer.enabled = true;
        yield return new WaitForSeconds(UnityEngine.Random.Range(visibilityRangeInSecs.x, visibilityRangeInSecs.y));
        StartCoroutine(DisableBlock());
    }

    private IEnumerator DisableBlock()
    {
        myBoxCollider2D.enabled = false;
        mySpriteRenderer.enabled = false;
        yield return new WaitForSeconds(UnityEngine.Random.Range(invisibiltyRangeInSecs.x, invisibiltyRangeInSecs.y));
        StartCoroutine(EnableBlock());
    }
}
