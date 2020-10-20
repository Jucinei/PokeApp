using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokeApp.Interfaces
{
    public interface INavigationService
    {
        Task NavigateTo(Page page);
        Task NavigateToBack();
    }
}
