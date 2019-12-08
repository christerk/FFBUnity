using Fumbbl;
using Fumbbl.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fumbbl.Model;
using static Fumbbl.Model.Types.BlockDie;

public class BlockDiceHandler : MonoBehaviour
{
    public Sprite SkullSprite;
    public Sprite BothDownSprite;
    public Sprite PushSprite;
    public Sprite PushPowSprite;
    public Sprite PowSprite;

    public GameObject BlockDiePrefab;

    private ViewObjectList<BlockDie> BlockDice;

    public Transform ContentObject;

    private Vector2 FullSize = new Vector2(40, 40);
    private Vector2 SmallSize = new Vector2(30, 30);
    private Vector2 SpacerSize = new Vector2(12, 30);

    // Start is called before the first frame update
    void Start()
    {
        BlockDice = new ViewObjectList<BlockDie>(
            die =>
            {
                GameObject obj = Instantiate(BlockDiePrefab);
                var image = obj.GetComponent<Image>();
                image.sprite = GetSpriteForRoll(die.Roll);
                obj.transform.SetParent(ContentObject);
                obj.transform.localScale = Vector3.one;
                obj.name = die.Roll.Type.ToString();
                die.GameObject = obj;
            },
            die =>
            {
                Destroy(die.GameObject);
            }
        );
    }

    // Update is called once per frame
    void Update()
    {
        BlockDice.Refresh(FFB.Instance.Model.BlockDice, die =>
        {
            var image = die.GameObject.GetComponentInChildren<Image>();
            var color = image.color;
            if (die.Roll.Type != DieType.None)
            {
                color.a = die.Active ? 1f : 0.5f;
            }
            else
            {
                color.a = 0f;
            }
            image.color = color;
            die.GameObject.transform.localScale = Vector3.one;
            var trn = die.GameObject.GetComponent<RectTransform>();
            if (die.Roll.Type != DieType.None)
            {
                trn.sizeDelta = die.Active ? FullSize : SmallSize;
            }
            else
            {
                trn.sizeDelta = SpacerSize;
            }
        });
    }

    private Sprite GetSpriteForRoll(Fumbbl.Model.Types.BlockDie roll)
    {
        switch (roll.Type)
        {
            case DieType.None: return null;
            case DieType.Skull: return SkullSprite;
            case DieType.BothDown: return BothDownSprite;
            case DieType.PowPush: return PushPowSprite;
            case DieType.Pow: return PowSprite;
            default: return PushSprite;
        }
    }
}
