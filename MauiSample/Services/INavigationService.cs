using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSample.Services
{
    public interface INavigationService
    {
        Task LaunchPage(Page page);
        void LaunchPageRoot(Page page);
    }
}
