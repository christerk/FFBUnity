using Fumbbl;
using UnityEngine;

public class ScoreBoardHandler : MonoBehaviour
{
    public TMPro.TextMeshProUGUI HomeScore;
    public TMPro.TextMeshProUGUI AwayScore;
    public TMPro.TextMeshProUGUI HomeTurn;
    public TMPro.TextMeshProUGUI AwayTurn;
    public TMPro.TextMeshProUGUI HalfText;

    // Update is called once per frame
    void Update()
    {
        HomeTurn.text = FFB.Instance.Model.TurnHome.ToString();
        AwayTurn.text = FFB.Instance.Model.TurnAway.ToString();

        HomeScore.text = FFB.Instance.Model.ScoreHome.ToString();
        AwayScore.text = FFB.Instance.Model.ScoreAway.ToString();

        if (FFB.Instance.Model.Half < 2)
        {
            HalfText.text = $"Half {FFB.Instance.Model.Half}";
        }
        else
        {
            HalfText.text = "Overtime";
        }
    }
}
