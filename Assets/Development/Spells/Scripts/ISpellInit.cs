using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spells
{
    public interface ISpellInit
    {
        public void Init(SOSpell spellData);
    }
}
