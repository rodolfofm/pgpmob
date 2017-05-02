using PGPMob.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace PGPMob.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        readonly IPGPMobApiService pgpMobApiService;
        public MainViewModel(IPGPMobApiService _pgpMobApiService)
        {
            this.pgpMobApiService = _pgpMobApiService;
        }

    }
}
