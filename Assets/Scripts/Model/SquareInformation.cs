using Fumbbl.Ffb.Dto.ModelChanges;
using Fumbbl.Model.Types;
using Fumbbl.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fumbbl.Model
{
    public class SquareInformation
    {
        private int FieldWidth;
        private int FieldHeight;
        public List<Types.PushbackSquare> PushbackSquares { get; private set; }
        public List<Types.TrackNumber> TrackNumbers { get; private set; }
        public List<Types.MoveSquare> MoveSquares { get; private set; }

        private SquareData[] squareData;

        public SquareInformation(int fieldWidth, int fieldHeight)
        {
            FieldWidth = fieldWidth;
            FieldHeight = fieldHeight;
            PushbackSquares = new List<Types.PushbackSquare>();
            TrackNumbers = new List<Types.TrackNumber>();
            MoveSquares = new List<Types.MoveSquare>();

            squareData = new SquareData[FieldWidth * FieldHeight];

            for (int i=0; i<squareData.Length; i++)
            {
                squareData[i] = new SquareData();
            }
        }

        public void Clear()
        {
            foreach (var i in squareData)
            {
                i.Clear();
            }
            PushbackSquares.Clear();
            TrackNumbers.Clear();
            MoveSquares.Clear();
        }

        internal void Add(Types.PushbackSquare square)
        {

            var data = squareData[GetIndex(square.Coordinate)];
            if (data.Set(square))
            {
                data.PushbackSquareIndex = PushbackSquares.Count();
                PushbackSquares.Add(data.PushbackSquare);
            }
        }

        internal void Add(Types.TrackNumber trackNumber)
        {
            var data = squareData[GetIndex(trackNumber.Coordinate)];
            if (data.Set(trackNumber))
            {
                data.TrackNumberIndex = TrackNumbers.Count();
                TrackNumbers.Add(data.TrackNumber);
            }
        }

        internal void Add(Types.MoveSquare moveSquare)
        {
            var data = squareData[GetIndex(moveSquare.Coordinate)];
            if (data.Set(moveSquare))
            {
                data.MoveSquareIndex = MoveSquares.Count();
                MoveSquares.Add(data.MoveSquare);
            }
        }

        internal void Remove(Types.PushbackSquare square)
        {
            var data = squareData[GetIndex(square.Coordinate)];
            if (data.UnsetPushbackSquare())
            {
                PushbackSquares.RemoveAt(data.PushbackSquareIndex);
                for (int i = data.PushbackSquareIndex; i < PushbackSquares.Count; i++)
                {
                    squareData[GetIndex(PushbackSquares[i].Coordinate)].PushbackSquareIndex--;
                }
            }
        }

        internal void Remove(Types.TrackNumber trackNumber)
        {
            var data = squareData[GetIndex(trackNumber.Coordinate)];
            if (data.UnsetTrackNumber())
            {
                TrackNumbers.RemoveAt(data.TrackNumberIndex);
                for (int i=data.TrackNumberIndex; i < TrackNumbers.Count; i++)
                {
                    squareData[GetIndex(TrackNumbers[i].Coordinate)].TrackNumberIndex--;
                }
            }
        }

        internal void Remove(Types.MoveSquare moveSquare)
        {
            var data = squareData[GetIndex(moveSquare.Coordinate)];
            if (data.UnsetMoveSquare())
            {
                MoveSquares.RemoveAt(data.MoveSquareIndex);
                for (int i = data.MoveSquareIndex; i < MoveSquares.Count; i++)
                {
                    squareData[GetIndex(MoveSquares[i].Coordinate)].MoveSquareIndex--;
                }
            }
        }

        internal int GetIndex(Coordinate coordinate)
        {
            return coordinate.Y * FieldWidth + coordinate.X;
        }

        private class SquareData
        {
            public int PushbackSquareIndex;
            public int TrackNumberIndex;
            public int MoveSquareIndex;
            public Types.PushbackSquare PushbackSquare;
            public Types.TrackNumber TrackNumber;
            public Types.MoveSquare MoveSquare;

            public SquareData()
            {
                PushbackSquare = new Types.PushbackSquare() { Active = false };
                TrackNumber = new Types.TrackNumber() { Active = false };
                MoveSquare = new Types.MoveSquare() { Active = false };
            }

            public bool Clear()
            {
                bool active = PushbackSquare.Active || TrackNumber.Active || MoveSquare.Active;
                PushbackSquare.Unset();
                TrackNumber.Unset();
                MoveSquare.Unset();
                return active;
            }

            internal bool Set(Types.PushbackSquare square)
            {
                bool active = PushbackSquare.Active;
                PushbackSquare.Set(square);
                return !active;
            }

            internal bool Set(Types.TrackNumber trackNumber)
            {
                bool active = TrackNumber.Active;
                TrackNumber.Set(trackNumber);
                return !active;
            }

            internal bool Set(Types.MoveSquare moveSquare)
            {
                bool active = MoveSquare.Active;
                MoveSquare.Set(moveSquare);
                return !active;
            }

            internal bool UnsetPushbackSquare()
            {
                bool result = PushbackSquare.Active;
                PushbackSquare.Unset();
                return result;
            }

            internal bool UnsetTrackNumber()
            {
                bool result = TrackNumber.Active;
                TrackNumber.Unset();
                return result;
            }

            internal bool UnsetMoveSquare()
            {
                bool result = MoveSquare.Active;
                MoveSquare.Unset();
                return result;
            }
        }
    }
}
