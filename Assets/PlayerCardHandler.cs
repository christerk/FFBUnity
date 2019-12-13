using Fumbbl.Model.Types;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Fumbbl;

public class PlayerCardHandler : MonoBehaviour
{
    private string ShownPlayerId;

    public Sprite AwayBG;
    public Sprite EmptyPortrait;
    public Sprite HomeBG;
    public SpriteRenderer background;
    public SpriteRenderer portrait;
    public TMPro.TextMeshPro Name;
    public TMPro.TextMeshPro Position;
    public TMPro.TextMeshPro SPP;
    public TMPro.TextMeshPro Level;
    public TMPro.TextMeshPro MA;
    public TMPro.TextMeshPro ST;
    public TMPro.TextMeshPro AG;
    public TMPro.TextMeshPro AV;
    public TMPro.TextMeshPro Skills;
    public bool Home;



    ///////////////////////////////////////////////////////////////////////////
    //  MONOBEHAVIOUR METHODS  ////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////

    void Start()
    {
        Color homeColor = new Color(0.4434f, 0.0376f, 0.0376f, 0.8745f);
        Color awayColor = new Color(0.0392f, 0.1588f, 0.4431f, 0.8745f);
        background.sprite = Home ? HomeBG : AwayBG;
    }



    ///////////////////////////////////////////////////////////////////////////
    //  CUSTOM METHODS  ///////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////

    public void SetPlayer(Player player)
    {
        string id = player?.Id;

        if (!string.Equals(id, ShownPlayerId))
        {
            if (player != null)
            {
                ShownPlayerId = player.Id;
                Name.text = player.Name;
                Position.text = player.Position?.Name;
                MA.text = player.Movement.ToString();
                ST.text = player.Strength.ToString();
                AG.text = player.Agility.ToString();
                AV.text = player.Armour.ToString();
                SPP.text = player.Spp.ToString();
                Skills.text = string.Join("\n", player.Skills);
                Level.text = player.Level;
                background.sprite = player.IsHome ? HomeBG : AwayBG;
                var portraitUrl = player.PortraitURL ?? player.Position.PortraitURL;
                if (portraitUrl != null)
                {
                    portrait.sprite = FFB.Instance.SpriteCache.Get(portraitUrl);
                }
                else
                {
                    portrait.sprite = EmptyPortrait;
                }
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
                ShownPlayerId = null;
            }
        }
    }
}
