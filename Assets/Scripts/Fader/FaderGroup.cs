using System.Collections.Generic;
using System.Linq;

namespace EnterKratos.Fader
{
    public class FaderGroup : FaderBase
    {
        private List<Fader> _faders;

        private void Start()
        {
            _faders = GetComponentsInChildren<Fader>().ToList();
        }

        // ReSharper disable once Unity.RedundantEventFunction
        private void OnEnable()
        {
            // This is needed to enable the checkbox on the component.
            // Although the enabled state is not evaluated in this component, it is evaluated in the Fader component.
        }

        public void FadeOut(Fader caller)
        {
            foreach (var fader in _faders.Where(f => f != caller))
            {
                fader.FadeOut(true);
            }
        }
    }
}