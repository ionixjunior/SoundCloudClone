using System;
using System.Reactive.Linq;

namespace SoundCloudClone.ViewModels
{
    public class SearchViewModel
    {
        public event EventHandler<string> SearchTextChanged;

        public SearchViewModel()
        {
            Observable
                .FromEventPattern<string>(
                    x => SearchTextChanged += x,
                    x => SearchTextChanged -= x)
                .Throttle(TimeSpan.FromSeconds(1))
                .Select(x => x.EventArgs)
                .Subscribe(OnSearchTextChanged);
        }

        private void OnSearchTextChanged(string text)
        {
            // TODO IMPLEMENTAR A CONSULTA NA API
            System.Diagnostics.Debug.WriteLine($"Buscando view evento o texto {text}");
        }

        public void SearchBy(string text) => SearchTextChanged.Invoke(this, text);
    }
}
