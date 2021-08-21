using UnityEngine;

public class IncreaseRoundsMouse : MonoBehaviour
{
    private TrackEditor _trackEditor;

    private void Awake()
    {
        _trackEditor = FindObjectOfType<TrackEditor>();
    }

    void Update()
    {
        Vector2 wheel = Input.mouseScrollDelta;

        if (wheel.y > 0)
        {
            string round = (int.Parse(_trackEditor.round.text) + 1).ToString();
            _trackEditor.OnRoundChanged(round);
            _trackEditor.round.text = round;
        }
        else if (wheel.y < 0)
        {
            if (int.Parse(_trackEditor.round.text) > 1)
            {
                string round = (int.Parse(_trackEditor.round.text) - 1).ToString();
                _trackEditor.OnRoundChanged(round);
                _trackEditor.round.text = round;
            }
                
        }
    }
}