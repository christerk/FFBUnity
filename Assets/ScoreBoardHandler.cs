using Fumbbl;
using UnityEngine;

public class ScoreBoardHandler : MonoBehaviour
{
    public TMPro.TextMeshProUGUI AwayScore;
    public TMPro.TextMeshProUGUI AwayTurn;
    public TMPro.TextMeshProUGUI HalfText;
    public TMPro.TextMeshProUGUI HomeScore;
    public TMPro.TextMeshProUGUI HomeTurn;

    #region MonoBehaviour Methods

    // Update is called once per frame
    private void Update()
    {
        HomeTurn.text = FFB.Instance.Model.TurnHome.ToString();
        AwayTurn.text = FFB.Instance.Model.TurnAway.ToString();

        HomeScore.text = FFB.Instance.Model.ScoreHome.ToString();
        AwayScore.text = FFB.Instance.Model.ScoreAway.ToString();

        int half = FFB.Instance.Model.Half;

        if (half <= 0)
        {
            HalfText.text = "Starting";
        }
        else if (half < 3)
        {
            HalfText.text = $"Half {FFB.Instance.Model.Half}";
        }
        else
        {
            HalfText.text = "Overtime";
        }
    }
    #endregion
}
