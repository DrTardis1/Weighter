using System.ComponentModel;

namespace Weighter.Core
{
    public interface IThemeService
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public AppTheme Theme { get; set; }
    }
}
