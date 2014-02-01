using System;
using LibiadaCore.Classes.Root;

namespace LibiadaMusic.ScoreModel
{
    public class Key : IBaseObject // знаки при ключе в такте (диез, бемоль)
    {
        private int fifths; // bemoles(-), diez(+) (ex. -6 : 6 bemoles);
        private string mode; // major/minor

        public Key(int fifths, string mode = "")
        {
            this.fifths = fifths;
            this.mode = mode;
        }


        public IBaseObject Clone()
        {
            var temp = new Key(fifths, mode);
            return temp;
        }

        public override bool Equals(object obj)
        {
            if ((fifths == ((Key) obj).fifths) && (mode == ((Key) obj).mode))
            {
                return true;
            }
            return false;
        }
    }
}
