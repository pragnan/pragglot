﻿using System;
using System.Threading.Tasks;
using ReactiveUI;

namespace Restaurant.Abstractions.Services
{
    public interface INavigationService
    {
        IViewFor CurrentPage { get; }

        Task NavigateAsync(INavigatableViewModel viewModel);

        Task NavigateAsync(Type viewModelType);

        Task NavigateModalAsync(INavigatableViewModel viewModel);

        Task NavigateModalAsync(Type viewModelType);

        IViewFor ResolveView(INavigatableViewModel vm);
    }
}
