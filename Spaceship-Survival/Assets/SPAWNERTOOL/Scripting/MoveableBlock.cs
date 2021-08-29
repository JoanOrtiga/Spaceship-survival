using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveableBlock : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    private static Dictionary<EnemyType, Color> enemyTypeColoring = new Dictionary<EnemyType, Color>()
    {
        {EnemyType.NOT_DEFINED, Color.white},
        {EnemyType.CRAZY, Color.cyan},
        {EnemyType.KAMIKAZE, Color.yellow},
        {EnemyType.SNIPER, Color.green},
        //{EnemyType.small, Color.magenta},
    };
    
    private TrackEditor _trackEditor;
    [HideInInspector] public RectTransform myRect;
    private RectTransform editorWindowRect;
    private RectTransform timelineRect;

    public SpawningEnemy _spawningEnemy;

    private Image image;
    private Text text;
    
    public enum State
    {
        init,
        moved,
        moving
    }

    public State currentState = State.init;

    private Vector2 lastPosition;

    private void OnEnable()
    {
        _trackEditor = FindObjectOfType<TrackEditor>();

        _spawningEnemy = new SpawningEnemy(1);

        editorWindowRect = GameObject.Find("EditorWindow").GetComponent<RectTransform>();
        myRect = GetComponent<RectTransform>();
        timelineRect = GameObject.Find("TimeLine").GetComponent<RectTransform>();

        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (currentState == State.moved)
        {
            if (!editorWindowRect.rect.Overlaps(myRect.rect))
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentState == State.init)
        {
            GameObject x = Instantiate(gameObject, transform.parent);

            transform.SetParent(timelineRect);
        }
        else if (currentState == State.moved)
        {
            lastPosition = myRect.localPosition;
        }

        currentState = State.moving;

        myRect.position = _trackEditor.ReturnGridPosition(eventData.position);
        
        _trackEditor.SetSelected(this);
        _trackEditor.CalculateTime(myRect);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!TrackEditor.Overlaps(timelineRect, myRect))
        {
            Destroy(gameObject);
        }

        _trackEditor.CalculateTime(myRect);
        _trackEditor.CalculateTrack(myRect);
        
        currentState = State.moved;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _trackEditor.SetSelected(this);
    }

    public void ChangeEnemyType(EnemyType newState)
    {
        image.color = enemyTypeColoring[newState];
        text.text = newState.ToString();
    }
}