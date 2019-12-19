using Fumbbl.Lib;
using Fumbbl.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Fumbbl.View
{
    public class PlayersView : ViewObjectList<Player>
    {
        public FieldHandler Handler { get; }
        private GameObject DugoutHome => Handler.DugoutHome;
        private GameObject DugoutAway => Handler.DugoutAway;
        private GameObject Field => Handler.Field;
        private GameObject AbstractIconPrefab => Handler.AbstractIconPrefab;
        private GameObject PlayerIconPrefab => Handler.PlayerIconPrefab;

        public PlayersView(FieldHandler handler) : base(null, null, null)
        {
            Handler = handler;
            Constructor = Construct;
            Updater = Update;
            Destructor = Destruct;
        }

        private void Update(ViewObject<Player> p)
        {
            bool active = false;
            if (p.ModelObject.Coordinate != null && p.GameObject != null)
            {
                var state = p.ModelObject.PlayerState;
                int moveToDugout = -1;
                if (state.IsReserve || state.IsExhausted || state.IsMissing)
                {
                    // Reserves box
                    moveToDugout = 0;
                }
                else if (state.IsKnockedOut)
                {
                    // KO Box
                    moveToDugout = 1;
                }
                else if (state.IsBadlyHurt || state.IsSeriousInjury || state.IsRip || state.IsBanned)
                {
                    // Cas Box
                    moveToDugout = 2;
                }

                if (moveToDugout >= 0)
                {
                    GameObject dugout = p.ModelObject.IsHome ? DugoutHome : DugoutAway;

                    Transform box = dugout.transform.GetChild(moveToDugout);
                    p.GameObject.transform.SetParent(box);

                    p.GameObject.transform.localPosition = Handler.ToDugoutCoordinates(p.ModelObject.Coordinate.Y);
                }
                else
                {
                    var pos = Handler.FieldToWorldCoordinates(p.ModelObject.Coordinate.X, p.ModelObject.Coordinate.Y, 1);

                    p.GameObject.transform.localPosition = pos;
                    p.GameObject.transform.SetParent(Field.transform);
                }
                active = true;
            }

            if (p.GameObject != null)
            {
                p.GameObject.SetActive(active);
            }
        }

        private GameObject Construct(Player p)
        {
            GameObject obj;

            if (FFB.Instance.Settings.Graphics.AbstractIcons)
            {
                obj = PlayerIcon.GeneratePlayerIconAbstract(p, AbstractIconPrefab);
            }
            else
            {
                obj = PlayerIcon.GeneratePlayerIcon(p, PlayerIconPrefab, AbstractIconPrefab);
            }
            obj.transform.SetParent(Field.transform);
            return obj;
        }

        private void Destruct(ViewObject<Player> p)
        {
            GameObject.Destroy(p.GameObject);
        }


    }
}
