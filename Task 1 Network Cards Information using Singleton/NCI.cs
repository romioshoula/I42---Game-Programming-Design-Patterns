using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace GameDesignPatterns_Task1
{
    class NCI
    {
        string _manufactor;
        long _MACadress;
        public CardType _cardType;
        private static NCI card = null;

        public NCI(string m, long mac, CardType CardType)
        {
            _manufactor = m;
            _MACadress = mac;
            _cardType = CardType;
        }

        public static NCI GetNCI(string manufactor, long MAC, CardType cardtype)
        {
            if (card == null)
            {
                card = new NCI(manufactor, MAC, cardtype);
            }
            else
            {
                card._manufactor = manufactor;
                card._MACadress = MAC;
                card._cardType = cardtype;
            }
            return card;
        }

        public override string ToString()
        {
            return String.Format($"The Card Information Is: {_manufactor} --- {_MACadress} --- {_cardType}");
        }

    }

    public enum CardType
    {
        Ethernet = 1,
        TokenRinf = 2
    }
}
