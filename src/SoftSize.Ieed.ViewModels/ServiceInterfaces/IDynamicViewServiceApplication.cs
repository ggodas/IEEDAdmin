using System;
using SoftSize.Ieed.ViewModels.ViewModels;

namespace SoftSize.Ieed.ViewModels.ServiceInterfaces
{
    public interface IDynamicViewServiceApplication
    {
        DynamicView RecuperarViewPor(Guid id);
    }
}