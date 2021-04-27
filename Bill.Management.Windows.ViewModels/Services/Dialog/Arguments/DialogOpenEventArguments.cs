using System;

namespace Bill.Management.Windows.ViewModels.Services.Dialog.Arguments
{
    public sealed class DialogOpenEventArguments : EventArgs
    {
        public int Count { get; internal set; }
    }
}