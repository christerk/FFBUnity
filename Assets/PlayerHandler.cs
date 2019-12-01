using Fumbbl;
using Fumbbl.Model.Types;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private GameObject Background;
    private GameObject Outline;
    private GameObject Prone;
    private GameObject Stunned;
    private Renderer BackgroundRenderer;

    public Player Player;

    void Start()
    {
        Background = this.transform.GetChild(0).gameObject;
        Outline = this.transform.GetChild(1).gameObject;
        Prone = this.transform.GetChild(2).gameObject;
        Stunned = this.transform.GetChild(3).gameObject;

        BackgroundRenderer = Background.GetComponent<Renderer>();
    }

    void Update()
    {
        bool active = string.Equals(FFB.Instance.Model.ActingPlayer.PlayerId, Player.Id);
        Outline.SetActive(active);

        var state = Player.PlayerState;

        bool fade = false;
        if (state != null && !active)
        {
            fade = state.IsBeingDragged || (state.IsStanding && !state.IsActive) || (state.IsProne && !state.IsActive);
        }

        Color color = BackgroundRenderer.material.color;
        color.a = fade ? 0.6f : 1f;
        BackgroundRenderer.material.color = color;

        Prone.SetActive(state.IsProne);
        Stunned.SetActive(state.IsStunned);
    }
}
