using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA200422
{
    enum Alfaj
    {
        Harcsa, Keszeg, Busa, Ponty,
        Kecsege, Angolna, Amur, Polip,
    }

    public struct Eletter
    {
        public int MinMelyseg { get; set; }
        public int MaxMelyseg { get; set; }

        public Eletter(int minMelyseg, int maxMelyseg)
        {
            if (minMelyseg == maxMelyseg) maxMelyseg++;

            if (minMelyseg > maxMelyseg)
            {
                MinMelyseg = maxMelyseg;
                MaxMelyseg = minMelyseg;
            }
            else
            {
                MinMelyseg = minMelyseg;
                MaxMelyseg = maxMelyseg;
            }
        }
    }

    class Hal
    {
        #region suly
        private float _suly = -1;
        public float Suly
        {
            set 
            {
                if (_suly == -1)
                {
                    if (value < 0.5F || value > 40F)
                        throw new Exception("nem megfelelő érték a hal kezdősúlyának!");
                    _suly = value;
                }
                else
                {
                    if (_suly * 1.1 < value || _suly * 0.9 > value)
                        throw new Exception("ennyivel nem változhat a súlya egy lépésben!");
                    _suly = value;
                }
            }
            get
            {
                if (_suly == -1)
                    throw new Exception("ez az érték még nincs beállítva");
                return _suly;
            }
        }
        #endregion
        #region ragadozo
        private bool _ragadozo;
        private bool _ragadozoBeallitva = false;
        public bool Ragadozo
        {
            set
            {
                if (_ragadozoBeallitva)
                    throw new Exception("a halak nem változtatnak étrendet!");
                _ragadozoBeallitva = true;
                _ragadozo = value;
            }
            get
            {
                if (!_ragadozoBeallitva) throw new Exception("még nincs beállítva");
                return _ragadozo;
            }
        }
        #endregion
        #region eletter
        private Eletter _eletter;
        private bool _eletterBeallitva = false;
        public Eletter Eletter
        {
            set
            {
                if (_eletterBeallitva)
                    throw new Exception("nem változtathat a hal életteret!");
                if (value.MinMelyseg < 0)
                    throw new Exception("nincsenek repülő halak");
                if (value.MinMelyseg > 400 || value.MaxMelyseg > 400)
                    throw new Exception("ilyen mélyen nem élhet a hal");
                if (value.MaxMelyseg < 10)
                    throw new Exception("ennél mélyebbre kell úsznia");
                if (value.MaxMelyseg <= value.MinMelyseg)
                    throw new Exception("a maximum nem lehet kevesebb vagy egyenlő, mint a minimum!");
                _eletterBeallitva = true;
                _eletter = value;
            }
            get
            {
                if (!_eletterBeallitva)
                    throw new Exception("még nem volt rendesen beáálítva!");
                return _eletter;
            }
        }
        #endregion
        #region alfaj
        private Alfaj _alfaj;
        private bool _alfajBellaitva = false;
        public Alfaj Alfaj
        {
            set
            {
                if (_alfajBellaitva)
                    throw new Exception("nem változhat meg a faja!");
                _alfajBellaitva = true;
                _alfaj = value;
            }
            get
            {
                if (!_alfajBellaitva) throw new Exception("még nem volt beállítva!");
                return _alfaj;
            }
        }
        #endregion
    }
}
