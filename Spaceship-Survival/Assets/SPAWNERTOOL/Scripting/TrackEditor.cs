using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackEditor : MonoBehaviour
{
    public RectTransform timeLine;

    public InputField round;
    public InputField roundTime;
    public InputField roundTracks;
    public Toggle attachToSeconds;


    private const float TimeXCell = 5;
    public float CellYSize = 111.4703f;
    public float CellXSize = 22.29406F;

    [HideInInspector] public float roundTimeN;
    [HideInInspector] public int roundTracksN;

    private GameObject copy;
    public GameObject block;

    public MoveableBlock selected { get; private set; }

    private SaveLoadSpawner _saveLoadSpawner;
    public int lastRound = -1;

    private void OnEnable()
    {
        _saveLoadSpawner = FindObjectOfType<SaveLoadSpawner>();
        lastRound = int.Parse(round.text);
    }

    public void SetSelected(MoveableBlock moveable)
    {
        if (selected == moveable)
            return;

        if (moveable.currentState != MoveableBlock.State.init)
        {
            if (selected != null)
                selected.transform.GetChild(0).gameObject.SetActive(false);

            moveable.transform.GetChild(0).gameObject.SetActive(true);

            selected = moveable;
            InspectorFields.Instance.spawnPointID.text = selected._spawningEnemy.spawnPointID.ToString();
            InspectorFields.Instance.timeToStartSpawning.text = selected._spawningEnemy.timeToStartSpawning.ToString();
            InspectorFields.Instance.howManyEnemies.text = selected._spawningEnemy.howManyEnemies.ToString();
            InspectorFields.Instance.enemyTypeDropdown.value = (int) selected._spawningEnemy.enemyType;
            InspectorFields.Instance.timeBetweenSpawn.text = selected._spawningEnemy.timeBetweenSpawn.ToString();
        }
    }

    void Start()
    {
        ChangeSize(float.Parse(roundTime.text), int.Parse(roundTracks.text));
        roundTracksN = int.Parse(roundTracks.text);
        roundTimeN = float.Parse(roundTime.text);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.C))
        {
            copy = selected.gameObject;
        }

        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.V))
        {
            GameObject copied = Instantiate(copy, selected.transform.position, Quaternion.identity, timeLine);
            MoveableBlock mb = copied.GetComponent<MoveableBlock>();

            mb._spawningEnemy.spawnPointID = selected._spawningEnemy.spawnPointID;
            mb._spawningEnemy.timeToStartSpawning = selected._spawningEnemy.timeToStartSpawning;
            mb._spawningEnemy.howManyEnemies = selected._spawningEnemy.howManyEnemies;
            mb._spawningEnemy.enemyType = selected._spawningEnemy.enemyType;
            mb._spawningEnemy.timeBetweenSpawn = selected._spawningEnemy.timeBetweenSpawn;
        }

        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Destroy(selected.gameObject);
        }
    }

    private void ChangeSize(float roundTime = 0.0f, int roundTracks = 0)
    {
        float x, y;

        if (roundTime >= 0.001f)
        {
            x = roundTime / TimeXCell * CellYSize;
        }
        else
        {
            x = timeLine.sizeDelta.x;
        }

        if (roundTracks != 0)
        {
            y = roundTracks * CellYSize;
        }
        else
        {
            y = timeLine.sizeDelta.y;
        }

        timeLine.sizeDelta = new Vector2(x, y);
    }

    public void OnRoundChanged(string round)
    {
        int temp;
        if (int.TryParse(round, out temp))
        {
            if (lastRound != -1)
            {
                _saveLoadSpawner.Save(lastRound);
            }

            lastRound = temp;

            ClearBlocks();

            _saveLoadSpawner.Load(temp);
        }
    }

    public void ClearBlocks()
    {
        MoveableBlock[] mbs = FindObjectsOfType<MoveableBlock>();

        foreach (var VARIABLE in mbs)
        {
            if (VARIABLE.currentState != MoveableBlock.State.init)
                Destroy(VARIABLE.gameObject);
        }
    }

    public void OnRoundTimeChanged(string time)
    {
        float x;

        time = time.Replace('.', ',');

        if (float.TryParse(time, out x))
        {
            ChangeSize(x);
            roundTimeN = x;
        }
        else
        {
            Debug.Log("Incorrect Round");
        }
    }

    public void OnRoundTracksChanged(string round)
    {
        int x;

        if (int.TryParse(round, out x))
        {
            ChangeSize(0, x);
            roundTracksN = x;
        }
        else
        {
            Debug.Log("Incorrect Round");
        }
    }

    public Vector2 ReturnGridPosition(Vector2 rectPosition)
    {
        Vector2 position = new Vector2();
        var timeLinePosition = timeLine.position;

        rectPosition.y -= timeLinePosition.y;
        position.y = (Mathf.CeilToInt(rectPosition.y / CellYSize) - 1) * CellYSize;
        position.y += 48.40106f + 7.33413f;
        position.y += timeLinePosition.y;

        if (attachToSeconds.isOn)
        {
            rectPosition.x -= timeLinePosition.x;
            position.x = (Mathf.CeilToInt(rectPosition.x / CellXSize) - 1) * CellXSize;
            position.x -= 11.14709f * 2;
            position.x += timeLinePosition.x;
        }
        else
        {
            position.x = rectPosition.x;
        }

        return position;
    }

    public static bool Overlaps(RectTransform rectTransform1, RectTransform rectTransform2)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform1.GetWorldCorners(corners);
        Rect rec = new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);

        rectTransform2.GetWorldCorners(corners);
        Rect rec2 = new Rect(corners[0].x, corners[0].y, corners[2].x - corners[0].x, corners[2].y - corners[0].y);

        if (rec.Overlaps(rec2))
        {
            return true;
        }

        return false;
    }

    public void CalculateTime(RectTransform blockRect)
    {
        float time;
        float positionX = blockRect.position.x;

        positionX -= timeLine.position.x;

        if (attachToSeconds.isOn)
        {
            time = Mathf.Round(positionX / CellXSize);
        }
        else
        {
            time = positionX / CellXSize;
        }

        selected._spawningEnemy.timeToStartSpawning = time;
        InspectorFields.Instance.timeToStartSpawning.text = time.ToString();
    }

    public void CalculateTrack(RectTransform blockRect)
    {
        int track;
        float positionY = blockRect.position.y;

        positionY -= timeLine.position.y;

        track = Mathf.CeilToInt(positionY / CellYSize);


        selected._spawningEnemy.currentTrack = track;
    }


    public void SaveRound(RoundsData roundsData, int round)
    {
        MoveableBlock[] mbs = FindObjectsOfType<MoveableBlock>();


        if (mbs.Length == 0)
            return;

        var spawn = roundsData.rounds[round];
        spawn.spawningEnemies.Clear();

        foreach (var blocks in mbs)
        {
            if (blocks.currentState != MoveableBlock.State.init)
                spawn.spawningEnemies.Add(blocks._spawningEnemy);
        }

        spawn.totalTracks = roundTracksN;
        spawn.totalRoundTime = roundTimeN;

        roundsData.rounds[round] = spawn;
    }

    public void LoadRound(RoundsData roundsData, int round)
    {
        if (roundsData.rounds.Count <= round)
        {
            for (int i = 0; roundsData.rounds.Count <= round; i++)
            {
                roundsData.rounds.Add(new EnemyRound(new List<SpawningEnemy>()));
            }
        }

        if (roundsData.rounds[round].totalRoundTime >= 1)
        {
            OnRoundTimeChanged(roundsData.rounds[round].totalRoundTime.ToString());
            roundTime.text = roundsData.rounds[round].totalRoundTime.ToString();
        }

        if (roundsData.rounds[round].totalTracks >= 1)
        {
            string tracks = roundsData.rounds[round].totalTracks.ToString();
            
            roundTracks.text = tracks;
            OnRoundTracksChanged(tracks);
        }

        foreach (var blocks in roundsData.rounds[round].spawningEnemies)
        {
            GameObject newBlock = Instantiate(block, timeLine);
            MoveableBlock mb = newBlock.GetComponent<MoveableBlock>();
            mb.currentState = MoveableBlock.State.moved;
            SetSelected(mb);

            InspectorFields.Instance.OnSpawnPointID(blocks.spawnPointID.ToString());
            InspectorFields.Instance.OnTimeToStartSpawning(blocks.timeToStartSpawning.ToString());

            float trackPosition;
            trackPosition = (blocks.currentTrack - 1) * CellYSize;
            trackPosition += 48.40106f + 7.33413f;

            mb.myRect.localPosition = new Vector2(mb.myRect.localPosition.x
                , trackPosition);

            CalculateTrack(mb.myRect);

            InspectorFields.Instance.OnHowManyEnemies(blocks.howManyEnemies.ToString());
            InspectorFields.Instance.OnEnemyType((int) blocks.enemyType);
            InspectorFields.Instance.OnTimeBetweenSpawn(blocks.timeBetweenSpawn.ToString());
        }
    }
}